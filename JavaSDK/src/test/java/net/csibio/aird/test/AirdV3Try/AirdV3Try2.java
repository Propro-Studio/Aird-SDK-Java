package net.csibio.aird.test.AirdV3Try;

import net.csibio.aird.bean.BlockIndex;
import net.csibio.aird.bean.DDAMs;
import net.csibio.aird.compressor.ByteTrans;
import net.csibio.aird.compressor.bytecomp.ZstdWrapper;
import net.csibio.aird.compressor.intcomp.VarByteWrapper;
import net.csibio.aird.parser.DDAParser;
import org.junit.Test;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class AirdV3Try2 {

        static String indexPath = "E:\\ComboCompTest\\Aird\\DDA-Sciex-MTBLS733-SampleA_1.json";
//    static String indexPath = "E:\\ComboCompTest\\Aird\\DDA-Thermo-MTBLS733-SA1.json";

    @Test
    public void test() throws Exception {
        DDAParser parser = new DDAParser(indexPath);
        List<DDAMs> ms1List = parser.readAllToMemory();

        ArrayList[] buckets = new ArrayList[3000];

        BlockIndex index = parser.getAirdInfo().getIndexList().get(0);
        System.out.println("Aird中ms1块-mz大小：" + index.getMzs().stream().mapToInt(Integer::intValue).sum() / 1024 / 1024 + "MB");
        System.out.println("Aird中ms1块-intensity大小：" + index.getInts().stream().mapToInt(Integer::intValue).sum() / 1024 / 1024 + "MB");

        for (int i = 0; i < ms1List.size(); i++) {
            HashMap<Integer, ArrayList<Double>> bucketMap = groupArray(ms1List.get(i).getSpectrum().getMzs(), ms1List.get(i).getSpectrum().getInts());
            bucketMap.forEach((key, value) -> {
                ArrayList<Integer> bucket = buckets[key];
                ArrayList<Integer> mz = bpMz(value, 10);
                if (bucket == null) {
                    bucket = mz;
                } else {
                    bucket.addAll(mz);
                }
                buckets[key] = bucket;
            });
        }

        long totalSize = 0l;
        for (int i = 0; i < buckets.length; i++) {
            ArrayList<Integer> bucket = buckets[i];
            if (bucket == null) {
                continue;
            }
            int[] intArray = bucket.stream().mapToInt(Integer::intValue).toArray();
            totalSize += new ZstdWrapper().encode(ByteTrans.intToByte(new VarByteWrapper().encode(intArray))).length;
        }
        System.out.println("压缩后大小：" + totalSize / 1024 / 1024 + "MB");
    }

    public static HashMap<Integer, ArrayList<Double>> groupArray(double[] mzArray, double[] intensityArray) {
        HashMap<Integer, ArrayList<Double>> result = new HashMap<>();

        for (int i = 0; i < mzArray.length; i++) {
            int intPart = (int) (mzArray[i]);
            int groupKey = intPart;

            if (!result.containsKey(groupKey)) {
                result.put(groupKey, new ArrayList<>());
            }

            result.get(groupKey).add(intensityArray[i]);
        }

        return result;
    }

    public static HashMap<Integer, ArrayList<Double>> groupArray(double[] mzArray) {
        HashMap<Integer, ArrayList<Double>> result = new HashMap<>();

        for (double value : mzArray) {
            int intPart = (int) (value);
            int groupKey = intPart;

            if (!result.containsKey(groupKey)) {
                result.put(groupKey, new ArrayList<>());
            }

            result.get(groupKey).add(value);
        }

        return result;
    }

    public ArrayList<Integer> bpMz(ArrayList<Double> array, int precision) {
        int[] intArray = new int[array.size()];
        for (int i = 0; i < array.size(); i++) {
            intArray[i] = (int) Math.round(array.get(i) * precision);
        }
        ArrayList<Integer> mzs = new ArrayList<>();
        for (int i = 0; i < intArray.length; i++) {
            mzs.add(intArray[i]);
        }

        return mzs;
    }
}
