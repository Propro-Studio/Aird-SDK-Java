/*
 * Copyright (c) 2020 CSi Studio
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

using System.Collections.Generic;
using System.Linq;

namespace AirdSDK.Beans
{
    public class ChromatogramIndex
    {
        /**
         * the total chromatograms count, exclude the TIC and BPC chromatograms
         */
        public long totalCount = 0;

        /**
         * acquisitionMethod
         */
        public string type;

        /**
         * 1:MS1;2:MS2
         */
        public List<string> ids = new();

        /**
         * 化合物名称列表
         */
        public List<string> compounds = new();
        
        /**
         * the block start position in the file
         * 在文件中的开始位置
         */
        public long startPtr;

        /**
         * the block end position in the file
         * 在文件中的结束位置
         */
        public long endPtr;

        /**
         * Every Chromatogram's activator in the block
         * 所有该块中的activator列表
         */
        public List<string> activators = new();

        /**
         * Every Chromatogram's energy in the block
         * 所有该块中的energy列表
         */
        public List<float> energies = new();

        /**
         * Every Chromatogram's polarity in the block
         * 所有该块中的polarity列表
         */
        public List<string> polarities = new();

        /**
         * The precursor ion list
         */
        public List<WindowRange> precursors = new();

        /**
         * The product ion list
         */
        public List<WindowRange> products = new();

        /**
         * chromatogram num list
         * 谱图序列号
         */
        public List<int> nums = new();

        /**
         * 一个块中所有子图的rt的压缩后的大小列表
         */
        public List<int> rts = new();

        /**
         * 一个块中所有子图的intensity的压缩后的大小列表
         */
        public List<int> ints = new();

        /**
         * Features of every index
         * 用于存储KV键值对
         */
        public string features;


        public ChromatogramIndex()
        {
        }
        
        
        public ChromatogramIndexProto ToProto()
        {
            ChromatogramIndexProto proto = new ChromatogramIndexProto
            {
                TotalCount = this.totalCount,
                Ids = { this.ids },
                Compounds = { this.compounds },
                StartPtr = this.startPtr,
                EndPtr = this.endPtr,
                // 假设 WindowRange 类也有一个 ToProto 方法
                Precursors = { this.precursors.Select(p => p.ToProto()) },
                Products = { this.products.Select(p => p.ToProto()) },
                Nums = { this.nums },
                Rts = { this.rts },
                Ints = { this.ints },
                Activators = { this.activators },
                Energies = { this.energies },
                Polarities = { this.polarities }
            };

            if (type != null)
            {
                proto.Type = type;
            }  
            if (features != null)
            {
                proto.Features = features;
            }
            return proto;
        }
    }
}