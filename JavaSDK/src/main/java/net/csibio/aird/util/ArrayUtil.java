/*
 * Copyright (c) 2020 CSi Biotech
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

package net.csibio.aird.util;

import net.csibio.aird.structure.SortInt;
import org.apache.commons.lang3.ArrayUtils;
import org.apache.commons.math3.util.Pair;

import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

/**
 * Array Util
 */
public class ArrayUtil {

    /**
     * @param originalArray 原数组 original array
     * @param currentLayer  当前层数 current layer
     * @return 排序后的int数组 the sorted integer array
     */
    public static SortInt[] transToSortIntArray(int[] originalArray, int currentLayer) {
        SortInt[] sortInts = new SortInt[originalArray.length];
        for (int i = 0; i < originalArray.length; i++) {
            sortInts[i] = new SortInt(originalArray[i], currentLayer);
        }
        return sortInts;
    }

    /**
     * convert float array to double array
     *
     * @param array array to convert
     * @return converted array
     */
    public static double[] f2d(float[] array) {
        if (array == null) {
            return null;
        }
        double[] newArray = new double[array.length];
        for (int i = 0; i < array.length; i++) {
            newArray[i] = array[i];
        }
        return newArray;
    }

    /**
     * convert double array to float array
     *
     * @param array double array
     * @return the converted data
     */
    public static float[] d2f(double[] array) {
        if (array == null) {
            return null;
        }
        float[] newArray = new float[array.length];
        for (int i = 0; i < array.length; i++) {
            newArray[i] = (float) array[i];
        }
        return newArray;
    }

    /**
     * convert double array to int array with target precision
     *
     * @param array     double array
     * @param precision the target precision
     * @return the converted data
     */
    public static int[] d2i(double[] array, double precision) {
        if (array == null) {
            return null;
        }
        int[] newArray = new int[array.length];
        for (int i = 0; i < array.length; i++) {
            newArray[i] = (int) (array[i] * precision);
        }
        return newArray;
    }

    /**
     * @param sortInts         已经排序的int数组 the sorted integer array
     * @param totalLayersCount 堆叠占位数,例如2层堆叠需要1位表示(即0和1),4层堆叠需要2位数表示(即00,01,10,11)
     * @return 恢复堆叠数组为正常数组
     */
    public static Pair<int[], byte[]> transToOriginArrayAndLayerNote(SortInt[] sortInts, int totalLayersCount) {

        int[] mz = new int[sortInts.length];
        Integer layerNote = 0b00;

        byte[] layerNoteBytes = new byte[(int) (Math.ceil(sortInts.length / 8d * totalLayersCount))];
        int count = 0;
        int addWhenMatch = 8;
        int currentByteLocation = 0;

        for (int i = 0; i < sortInts.length; i++) {
            mz[i] = sortInts[i].getNumber();
            layerNote = layerNote << totalLayersCount;
            layerNote |= sortInts[i].getLayer();
            count += totalLayersCount;

            if (count < addWhenMatch) {
                continue;
            }

            if (count == addWhenMatch) {
                layerNoteBytes[currentByteLocation] = layerNote.byteValue();
            } else {
                layerNoteBytes[currentByteLocation] = Integer.valueOf(layerNote >> (count - addWhenMatch)).byteValue();
                layerNote = layerNote << (32 - (count - addWhenMatch)) >>> (32 - (count - addWhenMatch));
            }
            currentByteLocation++;
            count -= addWhenMatch;
        }
        //最后补齐
        if (count != 0) {
            layerNoteBytes[currentByteLocation] = layerNote.byteValue();
        }
        return new Pair<>(mz, ArrayUtils.subarray(layerNoteBytes, 0, currentByteLocation + 1));
    }

    /**
     * Gets the average value of the difference between adjacent numbers in the array
     *
     * @param array target array
     * @return the average value
     */
    public static long avgDelta(int[] array) {
        long delta = 0;
        for (int i = 0; i < array.length - 1; i++) {
            if ((array[i + 1] - array[i]) == 0) {
                delta++;
            }
        }
        return delta;
    }

    /**
     * Convert Double list to double list
     *
     * @param list the list to convert
     * @return the converted data
     */
    public static double[] toDoublePrimitive(List<Double> list) {
        double[] array = new double[list.size()];
        for (int i = 0; i < list.size(); i++) {
            array[i] = list.get(i);
        }
        return array;
    }

    public static int[] toIntPrimitive(List<Integer> list) {
        int[] array = new int[list.size()];
        for (int i = 0; i < list.size(); i++) {
            array[i] = list.get(i);
        }
        return array;
    }

    /**
     * convert the Float type into float type
     *
     * @param floatSet target set
     * @return float array
     */
    public static float[] toPrimitive(Set<Float> floatSet) {
        if (floatSet.size() == 0) {
            return null;
        }
        float[] fArray = new float[floatSet.size()];
        int i = 0;
        for (Float aFloat : floatSet) {
            fArray[i] = aFloat;
            i++;
        }

        return fArray;
    }

    /**
     * judge whether the given double array is equal
     *
     * @param a double array A
     * @param b double array B
     * @return is the two arrays same
     */
    public static boolean isSame(double[] a, double[] b) {
        if (a.length != b.length) {
            return false;
        }
        for (int i = 0; i < a.length; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }

    /**
     * judge whether the given float array is equal
     *
     * @param a float array A
     * @param b float array B
     * @return is the two arrays same
     */
    public static boolean isSame(float[] a, float[] b) {
        if (a.length != b.length) {
            return false;
        }
        for (int i = 0; i < a.length; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }

    /**
     * judge whether the given byte array is equal
     *
     * @param a byte array A
     * @param b byte array B
     * @return is the two arrays same
     */
    public static boolean isSame(byte[] a, byte[] b) {
        if (a.length != b.length) {
            return false;
        }
        for (int i = 0; i < a.length; i++) {
            if (a[i] != b[i]) {
                return false;
            }
        }
        return true;
    }

    public static HashMap<Integer, Integer> toMap(int[] a, int[] b) {
        if (a.length != b.length) {
            return null;
        }
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int i = 0; i < a.length; i++) {
            map.put(a[i], b[i]);
        }
        return map;
    }

    public static double[] mergeArrays(double[] arr1, double[] arr2) {
        double[] mergedArray = new double[arr1.length + arr2.length];
        System.arraycopy(arr1, 0, mergedArray, 0, arr1.length);
        System.arraycopy(arr2, 0, mergedArray, arr1.length, arr2.length);
        return mergedArray;
    }

    public static int[] mergeArrays(int[] arr1, int[] arr2) {
        int[] mergedArray = new int[arr1.length + arr2.length];
        System.arraycopy(arr1, 0, mergedArray, 0, arr1.length);
        System.arraycopy(arr2, 0, mergedArray, arr1.length, arr2.length);
        return mergedArray;
    }
}
