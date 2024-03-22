package net.csibio.aird.util;

import net.csibio.aird.bean.common.RawFileInfo;

import java.io.File;
import java.text.DecimalFormat;
import java.util.TreeMap;

public class FileSizeUtil {
    public static TreeMap<String, Long> sum(String folder) throws Exception {
        File root = new File(folder);
        TreeMap<String, Long> sizeMap = new TreeMap<>();
        File[] files = root.listFiles();
        if (files == null) {
            return sizeMap;
        }
        for (File file : files) {
            RawFileInfo raw = FileUtil.buildRawInfo(file.getPath());
            if (raw != null) {
                sizeMap.merge(raw.getFileName(), raw.getFileSize(), Long::sum);
            }
        }
        return sizeMap;
    }

    public static String getSizeLabel(long size) {
        if (size == 0) {
            return "0";
        }

        if (size < 1024) {
            return size + " Byte";
        }

        DecimalFormat df = new DecimalFormat("#.##");
        if (size < 1024 * 1024) {
            return df.format(size / 1024d) + "KB";
        }

        if (size < 1024 * 1024 * 1024) {
            return df.format(size / 1024d / 1024) + "MB";
        }

        return df.format(size / 1024d / 1024 / 1024) + "GB";
    }
}
