﻿/*
 * Copyright (c) 2020 CSi Studio
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

using AirdSDK.Beans;
using System.Collections.Generic;
using System.IO;
using AirdSDK.Beans.Common;

namespace AirdSDK.Parser;

public class DIAPasefParser : BaseParser
{
    public DIAPasefParser(string indexFilePath) : base(indexFilePath)
    {
    }

    public DIAPasefParser(string indexFilePath, AirdInfo airdInfo) : base(indexFilePath, airdInfo)
    {
    }

    /**
     * the main interface for getting all the spectrums of a block.
     *
     * @param index block index
     * @return all the spectrums
     */
    public Dictionary<double, Spectrum> GetSpectra(BlockIndex index)
    {
        return GetSpectra(index.startPtr, index.endPtr, index.rts, index.mzs, index.ints, index.mobilities);
    }

    /**
     * 从aird文件中获取某一条记录 查询条件: 1.起始坐标 2.全rt列表 3.mz块体积列表 4.intensity块大小列表 5.rt
     * <p>
     * Read a spectrum from aird with multiple query criteria. Query Criteria: 1.Start Point 2.rt list
     * 3.mz block size list 4.intensity block size list 5.rt
     *
     * @param startPtr   起始位置 the start point of the target spectrum
     * @param rtList     全部时刻列表 all the retention time list
     * @param mzOffsets  mz数组长度列表 mz size block list
     * @param intOffsets int数组长度列表 intensity size block list
     * @param rt         获取某一个时刻原始谱图 the retention time of the target spectrum
     * @return 某个时刻的光谱信息 the spectrum of the target retention time
     */
    public Spectrum GetSpectrumByRt(long startPtr, List<double> rtList, List<int> mzOffsets, List<int> intOffsets,
        double rt)
    {
        int position = rtList.IndexOf(rt);
        return GetSpectrumByIndex(startPtr, mzOffsets, intOffsets, position);
    }

    /**
     * 根据序列号查询光谱
     *
     * @param index 索引序列号
     * @return 该索引号对应的光谱信息
     */
    public Spectrum GetSpectrum(int index)
    {
        List<BlockIndex> indexList = airdInfo.indexList;
        for (int i = 0; i < indexList.Count; i++)
        {
            BlockIndex blockIndex = indexList[i];
            if (blockIndex.nums.Contains(index))
            {
                int targetIndex = blockIndex.nums.IndexOf(index);
                return GetSpectrumByIndex(blockIndex, targetIndex);
            }
        }

        return null;
    }

    /**
     * 从一个完整的Swath Block块中取出一条记录 查询条件: 1. block索引号 2. rt
     * <p>
     * Read a spectrum from aird with block index and target rt
     *
     * @param index block index
     * @param rt    retention time of the target spectrum
     * @return the target spectrum
     */
    public Spectrum GetSpectrumByRt(BlockIndex index, double rt)
    {
        List<double> rts = index.rts;
        int position = rts.IndexOf(rt);
        return GetSpectrumByIndex(index, position);
    }

    /**
     * @param blockIndex 块索引
     * @param index      块内索引值
     * @return 对应光谱数据
     */
    public Spectrum GetSpectrumByIndex(BlockIndex blockIndex, int index)
    {
        return GetSpectrumByIndex(blockIndex.startPtr, blockIndex.mzs, blockIndex.ints, blockIndex.mobilities, index);
    }
}