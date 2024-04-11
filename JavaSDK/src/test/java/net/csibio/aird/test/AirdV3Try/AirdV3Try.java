package net.csibio.aird.test.AirdV3Try;

import com.alibaba.fastjson2.JSON;
import net.csibio.aird.bean.BlockIndex;
import net.csibio.aird.bean.DDAMs;
import net.csibio.aird.bean.DDAPasefMs;
import net.csibio.aird.bean.common.Spectrum;
import net.csibio.aird.compressor.ByteTrans;
import net.csibio.aird.compressor.bytecomp.ZstdWrapper;
import net.csibio.aird.compressor.intcomp.BinPackingWrapper;
import net.csibio.aird.compressor.intcomp.DeltaZigzagVBWrapper;
import net.csibio.aird.compressor.sortedintcomp.DeltaWrapper;
import net.csibio.aird.compressor.sortedintcomp.IntegratedBinPackingWrapper;
import net.csibio.aird.parser.DDAParser;
import net.csibio.aird.parser.DDAPasefParser;
import net.csibio.aird.util.ArrayUtil;
import net.csibio.aird.util.FileSizeUtil;
import org.junit.Test;

import java.util.*;

public class AirdV3Try {

//    static String indexPath = "E:\\MzmineTest\\PXD033904_PASEF\\Aird\\20220302_tims1_nElute_8cm_DOl_Phospho_7min_rep1_Slot1-94_1_1811.json";
//    static String indexPath = "E:\\ComboCompTest\\Aird\\DDA-Sciex-MTBLS733-SampleA_1.json";

    static String indexPath = "F:\\37-test.json";

    static int MB = 1024 * 1024;
    static int KB = 1024;

    @Test
    public void test2() throws Exception {
        DDAPasefParser parser = new DDAPasefParser(indexPath);
        double rtStart = 2000;
        double rtEnd = 4000;
        long startTime = System.currentTimeMillis();
        List<DDAPasefMs> allSpectra = parser.getSpectraByRtRange(rtStart, rtEnd, false);
        System.out.println("读取耗时："+(System.currentTimeMillis() - startTime));
        BlockIndex ms1Index = parser.getMs1Index();
        Double[] rts = new Double[ms1Index.getRts().size()];
        ms1Index.getRts().toArray(rts);

        int start = Arrays.binarySearch(rts, rtStart);
        if (start < 0) {
            start = -start - 1;
        }
        int end = Arrays.binarySearch(rts, rtEnd);
        if (end < 0) {
            end = -end - 2;
        }

        long compressedMzs = 0;
        long compressedInts = 0;
        long compressedMobilities = 0;
        for (int i = start; i <= end; i++) {
            compressedMzs += ms1Index.getMzs().get(i);
            compressedInts += ms1Index.getInts().get(i);
            compressedMobilities += ms1Index.getMobilities().get(i);
        }

        System.out.println("总计质谱图" + allSpectra.size());
        System.out.println("Aird压缩后mz大小" + FileSizeUtil.getSizeLabel(compressedMzs));
        System.out.println("Aird压缩后Intensity大小" + FileSizeUtil.getSizeLabel(compressedInts));
        System.out.println("Aird压缩后Mobility大小" + FileSizeUtil.getSizeLabel(compressedMobilities));

        compressedMzs = 0;
        compressedInts = 0;
        compressedMobilities = 0;
        double[] mobi = parser.getMobiDict();
        HashMap<Double, Integer> dict = new HashMap<>();
        for (int i = 0; i < mobi.length; i++) {
            dict.put(mobi[i], i);
        }
        for (DDAPasefMs ddaPasefMs : allSpectra) {
            Spectrum spectrum = ddaPasefMs.getSpectrum();
            System.out.println(JSON.toJSONString(spectrum.getMzs()));
            int[] mobiInts = ByteTrans.mobiToInt(spectrum.getMobilities(), dict);
            System.out.println(JSON.toJSONString(mobiInts));
            int[] newMobiInts =  new DeltaZigzagVBWrapper().encode(mobiInts);

            compressedMobilities += new ZstdWrapper().encode(ByteTrans.intToByte(newMobiInts)).length;
        }

        System.out.println("新Aird压缩后mz大小" + FileSizeUtil.getSizeLabel(compressedMzs));
        System.out.println("新Aird压缩后Intensity大小" + FileSizeUtil.getSizeLabel(compressedInts));
        System.out.println("新Aird压缩后Mobility大小" + FileSizeUtil.getSizeLabel(compressedMobilities));
    }

    @Test
    public void test3() throws Exception {
        DDAParser parser = new DDAParser(indexPath);
        long start = System.currentTimeMillis();
        List<DDAMs> allSpectra = parser.getSpectraByRtRange(0, 1000, false);
        System.out.println(allSpectra.size());
        System.out.println("耗时：" + (System.currentTimeMillis() - start));
    }

    @Test
    public void test() throws Exception {
        DDAParser parser = new DDAParser(indexPath);
        List<DDAMs> ms1List = parser.readAllToMemory();

        int compact = 8;
        int originMzSize = 0;
        int originIntSize = 0;
        int compactMzSize = 0;
        int compactIntSize = 0;

        int[] compactMzArray = new int[0];
        double[] compactIntArray = new double[0];

        ArrayList<Integer> mzIndex = new ArrayList<>();
        ArrayList<Double> mzRates = new ArrayList<>();
        ArrayList<Integer> intIndex = new ArrayList<>();
        ArrayList<Double> intRates = new ArrayList<>();

        ArrayList<Integer> indexList = new ArrayList<>();
        ArrayList<Integer> pointList = new ArrayList<>();
        for (int i = 0; i < ms1List.size(); i++) {
            indexList.add(i);
            pointList.add(ms1List.get(i).getSpectrum().getMzs().length);
        }
        System.out.println(JSON.toJSON(indexList));
        System.out.println(JSON.toJSON(pointList));
        int k = 0;
        System.out.println("共有质谱图" + ms1List.size() + "张");
        for (int i = 0; i < ms1List.size(); i++) {
            if (i > ms1List.size() - 1) {
                break;
            }

            if (i != 0 && i % compact == 0) {
                compactMzSize = new ZstdWrapper().encode(ByteTrans.intToByte(compactMzArray)).length;
                compactIntSize = new ZstdWrapper().encode(ByteTrans.doubleToByte(compactIntArray)).length;
                double mzRate = (originMzSize - compactMzSize) * 1.0 / originMzSize;
                double intRate = (originIntSize - compactIntSize) * 1.0 / originIntSize;
                System.out.println("mz压缩增益：" + mzRate);
                System.out.println("int压缩增益：" + intRate);
                k++;
                mzIndex.add(k);
                intIndex.add(k);
                mzRates.add(mzRate);
                intRates.add(intRate);
                compactMzArray = new int[0];
                compactIntArray = new double[0];
                originMzSize = 0;
                originIntSize = 0;
            }
            double[] mzArray = ms1List.get(i).getSpectrum().getMzs();
            double[] intensityArray = ms1List.get(i).getSpectrum().getInts();
            byte[] byteMz = compressMz(mzArray);
            byte[] byteInt = compressInt(intensityArray);
            originMzSize += byteMz.length;
            originIntSize += byteInt.length;
            compactMzArray = ArrayUtil.mergeArrays(compactMzArray, bpMz(mzArray));
            compactIntArray = ArrayUtil.mergeArrays(compactIntArray, mzArray);
        }

//        compactMzSize = new ZstdWrapper().encode(ByteTrans.intToByte(compactMzArray)).length;
//        compactIntSize = compressInt(compactIntArray).length;
//        double mzRate = (originMzSize - compactMzSize) * 1.0 / originMzSize;
//        double intRate = (originIntSize - compactIntSize) * 1.0 / originIntSize;
//        System.out.println("mz压缩增益：" + mzRate);
//        System.out.println("int压缩增益：" + intRate);
//        k++;
//        mzIndex.add(k);
//        intIndex.add(k);
//        mzRates.add(mzRate);
//        intRates.add(intRate);
//        compactMzArray = new int[0];
//        compactIntArray = new double[0];
//        originMzSize = 0;
//        originIntSize = 0;

        System.out.println(JSON.toJSON(mzIndex));
        System.out.println(JSON.toJSON(mzRates));
        System.out.println(mzRates.stream().mapToDouble(Double::doubleValue).average());
        System.out.println(JSON.toJSON(intIndex));
        System.out.println(JSON.toJSON(intRates));


    }

    public int[] bpMz(double[] array) {
        int[] intArray = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            intArray[i] = (int) Math.round(array[i] * 100000);
        }
        return new DeltaWrapper().encode(intArray);
    }

    public byte[] compressMz(double[] array) {
        int[] intArray = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            intArray[i] = (int) Math.round(array[i] * 100000);
        }
        return new ZstdWrapper().encode(ByteTrans.intToByte(new IntegratedBinPackingWrapper().encode(intArray)));
    }

    public byte[] compressInt(double[] array) {
        int[] intArray = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            intArray[i] = (int) Math.round(array[i]);
        }
        return new ZstdWrapper().encode(ByteTrans.intToByte(new BinPackingWrapper().encode(intArray)));
    }
}
