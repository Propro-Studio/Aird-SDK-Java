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
using AirdSDK.Beans.Common;
using AirdSDK.Utils;

namespace AirdSDK.Parser;

public class DDAParser : BaseParser
{
    public DDAParser(string indexFilePath) : base(indexFilePath)
    {
    }

    public DDAParser(string indexFilePath, AirdInfo airdInfo) : base(indexFilePath, airdInfo)
    {
    }


    /**
     * DDA只有一个MS1 BlockIndex,因此是归属于DDAParser的特殊算法
     *
     * @return
     */
    public BlockIndex GetMs1Index()
    {
        if (airdInfo != null && airdInfo.indexList != null && airdInfo.indexList.Count > 0)
        {
            return airdInfo.indexList[0];
        }

        return null;
    }

    public List<BlockIndex> GetAllMs2Index()
    {
        if (airdInfo != null && airdInfo.indexList != null && airdInfo.indexList.Count > 0)
        {
            return airdInfo.indexList.GetRange(1, airdInfo.indexList.Count);
        }

        return null;
    }

    /**
    * key为parentNum
    *
    * @return
    */
    public Dictionary<int, BlockIndex> GetMs2IndexMap()
    {
        if (airdInfo != null && airdInfo.indexList != null && airdInfo.indexList.Count > 0)
        {
            List<BlockIndex> ms2IndexList = airdInfo.indexList.GetRange(1, airdInfo.indexList.Count);
            var results = new Dictionary<int, BlockIndex>();
            foreach (var index in ms2IndexList)
            {
                results.Add(index.getParentNum(), index);
            }

            return results;
        }

        return null;
    }

    /**
    * DDA文件采用一次性读入内存的策略 DDA reader using the strategy of loading all the information into the memory
    *
    * @return DDA文件中的所有信息, 以MsCycle的模型进行存储 the mz-intensity pairs read from the aird. And store as
    * MsCycle in the memory
    * @throws Exception exception when reading the file
    */
    public List<DDAMs> ReadAllToMemory()
    {
        BlockIndex ms1Index = GetMs1Index(); //所有的ms1谱图都在第一个index中
        Dictionary<double, Spectrum> ms1Map = GetSpectra(ms1Index);
        List<double> ms1RtList = new List<double>(ms1Map.Keys);
        List<DDAMs> ms1List = BuildDdaMsList(ms1RtList,0,ms1RtList.Count, ms1Index, ms1Map, true);
        return ms1List;
    }

    /**
    * key为rt, value为对应谱图
    *
    * @return
    */
    public Dictionary<double, Spectrum> GetMs1SpectraMap()
    {
        BlockIndex ms1Index = GetMs1Index();
        return GetSpectra(ms1Index);
    }

    /**
    * @param rtStart
    * @param rtEnd
    * @return
    */
    public List<DDAMs> GetSpectraByRtRange(double rtStart, double rtEnd, bool includeMS2)
    {
        BlockIndex ms1Index = GetMs1Index();
        double[] rts = new double[ms1Index.rts.Count];
        rts = ms1Index.rts.ToArray();
        //如果范围不在已有的rt数组范围内,则直接返回empty map
        if (rtStart > rts[rts.Length - 1] || rtEnd < rts[0])
        {
            return null;
        }

        int start = ms1Index.rts.BinarySearch(rtStart);
        if (start < 0)
        {
            start = -start - 1;
        }

        int end = ms1Index.rts.BinarySearch(rtEnd);
        if (end < 0)
        {
            end = -end - 2;
        }

        Dictionary<double, Spectrum> ms1Map = new Dictionary<double, Spectrum>();
        for (int i = start; i <= end; i++)
        {
            ms1Map.Add(rts[i], GetSpectrumByIndex(ms1Index, i));
        }

        List<DDAMs> ms1List = BuildDdaMsList(ms1Index.rts, start, end + 1, ms1Index, ms1Map, includeMS2);
        return ms1List;
    }

    private List<DDAMs> BuildDdaMsList(List<double> rtList, int start, int end, BlockIndex ms1Index, Dictionary<double, Spectrum> ms1Map,
        bool includeMS2)
    {
        List<DDAMs> ms1List = new List<DDAMs>();
        Dictionary<int, BlockIndex> ms2IndexMap = null;
        if (includeMS2)
        {
            ms2IndexMap = GetMs2IndexMap();
        }

        for (int i = start; i < end; i++)
        {
            DDAMs ms1 = new DDAMs(rtList[i], ms1Map[rtList[i]]);
            DDAUtil.InitFromIndex(airdInfo, ms1, ms1Index, i);
            if (includeMS2)
            {
                BlockIndex ms2Index = ms2IndexMap[ms1.num];
                if (ms2Index != null)
                {
                    Dictionary<double, Spectrum> ms2Map = GetSpectra(ms2Index.startPtr, ms2Index.endPtr, ms2Index.rts,
                        ms2Index.mzs, ms2Index.ints);
                    List<double> ms2RtList = new List<double>(ms2Map.Keys);
                    List<DDAMs> ms2List = new List<DDAMs>();
                    for (int j = 0; j < ms2RtList.Count; j++)
                    {
                        DDAMs ms2 = new DDAMs(ms2RtList[j], ms2Map[ms2RtList[j]]);
                        DDAUtil.InitFromIndex(airdInfo, ms2, ms2Index, j);
                        ms2List.Add(ms2);
                    }

                    ms1.ms2List = ms2List;
                }
            }

            ms1List.Add(ms1);
        }

        return ms1List;
    }
}