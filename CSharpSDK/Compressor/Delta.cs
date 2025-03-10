﻿/*
 * Copyright (c) 2020 CSi Studio
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2. 
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2 
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.  
 * See the Mulan PSL v2 for more details.
 */

namespace AirdSDK.Compressor;

public class Delta
{
    /**
    * Apply differential coding (in-place).
    *
    * @param data data to be modified
    */
    public static int[] delta(int[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }
        int[] res = new int[data.Length];
        res[0] = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            res[i] = data[i] - data[i - 1];
        }

        return res;
    }

    /**
     * Undo differential coding (in-place). Effectively computes a prefix sum.
     *
     * @param data to be modified.
     */
    public static int[] recover(int[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }
        int[] res = new int[data.Length];
        res[0] = data[0];
        for (int i = 1; i < data.Length; ++i)
        {
            res[i] = data[i] + res[i - 1];
        }

        return res;
    }

    /**
    * Apply differential coding (in-place).
    *
    * @param data data to be modified
    */
    public static long[] delta(long[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }
        long[] res = new long[data.Length];
        res[0] = data[0];
        for (int i = 1; i < data.Length; i++)
        {
            res[i] = data[i] - data[i - 1];
        }

        return res;
    }

    /**
     * Undo differential coding (in-place). Effectively computes a prefix sum.
     *
     * @param data to be modified.
     */
    public static long[] recover(long[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }
        long[] res = new long[data.Length];
        res[0] = data[0];
        for (int i = 1; i < data.Length; ++i)
        {
            res[i] = data[i] + res[i - 1];
        }

        return res;
    }
}