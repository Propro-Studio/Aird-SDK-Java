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

namespace AirdSDK.Beans
{
    /**
     * General information about the MS instrument.
     */
    public class Instrument
    {
        //设备仪器厂商
        public string manufacturer;

        //电离方式 Ionisation Method
        public string ionisation;

        //仪器分辨率 The Instrument Resolution
        public string resolution;

        //设备类型
        public string model;

        //来源 source
        public List<string> source = new List<string>();

        //分析方式
        public List<string> analyzer = new List<string>();

        //探测器
        public List<string> detector = new List<string>();

        public InstrumentProto ToProto()
        {
            InstrumentProto proto = new InstrumentProto()
            {
                Manufacturer = this.manufacturer,
                Ionisation = this.ionisation,
                Resolution = this.resolution,
                Model = this.model,
                // 将 List<string> 转换为 repeated 字段
                Source = { this.source },
                Analyzer = { this.analyzer },
                Detector = { this.detector }
            };
            return proto;
        }
    }
}