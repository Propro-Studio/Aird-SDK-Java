/*
 * Copyright (c) 2020 CSi Biotech
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

package net.csibio.aird.compressor.bytecomp;

import com.github.luben.zstd.Zstd;
import com.github.luben.zstd.ZstdDictCompress;
import com.github.luben.zstd.ZstdDictDecompress;
import net.csibio.aird.enums.ByteCompType;

import java.util.Arrays;

public class ZstdWrapper implements ByteComp {

    @Override
    public String getName() {
        return ByteCompType.Zstd.getName();
    }

    @Override
    public byte[] encode(byte[] input) {
        return Zstd.compress(input);
    }

    @Override
    public byte[] decode(byte[] input) {
        int size = (int) Zstd.getFrameContentSize(input);
        byte[] array = new byte[size];

        try {
            Zstd.decompress(array, input);
        } catch (Exception e) {
            e.printStackTrace();
        }
        return array;
    }

    @Override
    public byte[] decode(byte[] input, int offset, int length) {
        try {
            return decode(Arrays.copyOfRange(input, offset, offset + length));
        } catch (Exception e) {
            e.printStackTrace();
            return null;
        }
    }

    public byte[] encode(byte[] input, byte[] dict) {
        return Zstd.compress(input, new ZstdDictCompress(dict, 3));
    }

    public byte[] decode(byte[] input, byte[] dict) {
        int size = (int) Zstd.getFrameContentSize(input);
        return Zstd.decompress(input, new ZstdDictDecompress(dict), size);
    }

    public byte[] decode(byte[] input, int offset, int length, byte[] dict) {
        return decode(Arrays.copyOfRange(input, offset, offset + length), dict);
    }
}
