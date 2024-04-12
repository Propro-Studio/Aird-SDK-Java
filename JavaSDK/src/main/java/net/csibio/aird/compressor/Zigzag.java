package net.csibio.aird.compressor;

public class Zigzag {

    /**
     * Apply differential coding (in-place).
     *
     * @param data data to be modified
     */
    public static int[] encode(int[] data) {
        int[] res = new int[data.length];
        for (int i = 1; i < data.length; i++) {
            res[i] = (data[i] << 1) ^ (data[i] >> 31);
        }
        return res;
    }

    /**
     * Undo differential coding (in-place). Effectively computes a prefix sum.
     *
     * @param data to be modified.
     */
    public static int[] decode(int[] data) {
        int[] res = new int[data.length];
        for (int i = 1; i < data.length; i++) {
            res[i] = (data[i] >>> 1) ^ -(data[i] & 1);
        }
        return res;
    }
}
