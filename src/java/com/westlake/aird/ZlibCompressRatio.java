package com.westlake.aird;

import com.westlake.aird.api.AirdParser;
import com.westlake.aird.bean.MzIntensityPairs;
import com.westlake.aird.bean.SwathIndex;
import com.westlake.aird.huffman.HuffmanCode;
import com.westlake.aird.huffman.Wrapper;
import com.westlake.aird.util.AirdScanUtil;
import com.westlake.aird.util.CompressUtil;
import org.tukaani.xz.FilterOptions;
import org.tukaani.xz.LZMA2Options;
import org.tukaani.xz.XZOutputStream;

import java.io.*;
import java.nio.ByteBuffer;
import java.nio.FloatBuffer;
import java.util.*;
import java.util.concurrent.atomic.AtomicInteger;
import java.util.concurrent.atomic.AtomicLong;

public class ZlibCompressRatio {


    public static void main(String[] args) {
//        File indexFile = new File("E:\\data\\HYE124_5600_64_Var\\HYE124_TTOF5600_64var_lgillet_L150206_007.json");
//        File indexFile = new File("D:\\Propro\\projet\\data\\HYE110_TTOF6600_32fix_lgillet_I160308_001.json");
//        File indexFile = new File("D:\\Propro\\projet\\data\\C20181205yix_HCC_DIA_N_38A.json");
        File indexFile = new File("D:\\Propro\\projet\\data\\HYE124_TTOF5600_64var_lgillet_L150206_007.json");
//        File indexFile = new File("E:\\data\\SGSNew\\napedro_L120224_010_SW.json");
//        File indexFile = new File("E:\\metabolomics\\宣武医院 10-19 raw data\\NEG-Convert\\QXA01DNNEG20190627_DIAN1019VWHUMAN_HUMAN_PLASMA1_01.json");
        AtomicInteger rtCount = new AtomicInteger(0);
        AtomicLong mzCount = new AtomicLong(0);

        // {intensitySize, compressedIntensitySize, XzIntensitySize}
        AtomicLong intensitySize = new AtomicLong(0);
        AtomicLong zlibCompressedSize = new AtomicLong(0);
        AtomicLong xzCompressedSize = new AtomicLong(0);

        AtomicLong zlibTime = new AtomicLong(0);
        AtomicLong xzTime = new AtomicLong(0);


        AtomicInteger iter = new AtomicInteger(1);
        System.out.println(indexFile.getAbsolutePath());
        AirdParser airdParser = new AirdParser(indexFile.getAbsolutePath());
        List<SwathIndex> swathIndexList = airdParser.getAirdInfo().getIndexList();
        swathIndexList.forEach(index -> {
            System.out.println("正在扫描:" + iter + "/" + swathIndexList.size());
            index.getRts().parallelStream().forEach(rt -> {
                //intensity -> zlib     mz -> fastpfor
                MzIntensityPairs pairs = airdParser.getSpectrum(index, rt);

                byte[] ms2Intensity = transToByte(pairs.getIntensityArray());

                long start = System.currentTimeMillis();
                byte[] ms2IntensityCompressed = CompressUtil.zlibCompress(ms2Intensity);
                long end = System.currentTimeMillis();
                zlibTime.addAndGet(end - start);

                start = System.currentTimeMillis();
                byte[] ms2IntensityXZ = xzCompress(ms2Intensity, 1);
                end = System.currentTimeMillis();
                xzTime.addAndGet(end - start);

                intensitySize.addAndGet(ms2Intensity.length) ;
                zlibCompressedSize.addAndGet(ms2IntensityCompressed.length) ;
                xzCompressedSize.addAndGet(ms2IntensityXZ.length) ;

            });
            rtCount.addAndGet(index.getRts().size());
            iter.addAndGet(1);

        });

        System.out.println(String.format("ms2 int: %f MBs ", intensitySize.get()/1024f/1024f));
        System.out.println(String.format("ms2 zlib: %f MBs, %f percent reduced, in %d s", zlibCompressedSize.get()/1024f/1024f,100*(1.0-(double)zlibCompressedSize.get()/ intensitySize.get()), zlibTime.get()/1000));
        System.out.println(String.format("ms2 xz: %f MBs, %f percent reduced, in %d s", xzCompressedSize.get()/1024f/1024f,100*(1.0-(double)xzCompressedSize.get()/ intensitySize.get()), xzTime.get()/1000));
    }

    public static byte[] transToByte(float[] target) {
        FloatBuffer fbTarget = FloatBuffer.wrap(target);
        ByteBuffer bbTarget = ByteBuffer.allocate(fbTarget.capacity() * 4);
        bbTarget.asFloatBuffer().put(fbTarget);
        return bbTarget.array();
    }

    public static byte[] xzCompress(byte[] target, int level)  {
        ByteArrayOutputStream bos = new ByteArrayOutputStream();
        try {
            XZOutputStream xzOutputStream = new XZOutputStream(bos, new LZMA2Options(level));
            xzOutputStream.write(target);
        }catch (IOException e){
            e.printStackTrace();
        }
        return bos.toByteArray();
    }

}
