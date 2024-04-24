/*
 * Copyright (c) 2020 CSi Biotech
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

package net.csibio.aird.bean;

import lombok.Data;
import net.csibio.aird.bean.proto.AirdInfo;

import java.util.ArrayList;
import java.util.List;

@Data
public class Instrument {

    /**
     * 设备仪器厂商 Instrument manufacturer
     */
    String manufacturer;

    /**
     * 电离方式 Ionisation Method
     */
    String ionisation;

    /**
     * 仪器分辨率 The Instrument Resolution
     */
    String resolution;

    /**
     * 设备类型 Instrument Model
     */
    String model;

    /**
     * 来源 source
     */
    List<String> source;

    /**
     * 分析方式 Analyzer
     */
    List<String> analyzer;

    /**
     * 探测器 Detector
     */
    List<String> detector;

    public static Instrument fromProto(AirdInfo.InstrumentProto proto) {
        if (proto == null) {
            return null;
        }

        Instrument instrument = new Instrument();
        instrument.setManufacturer(proto.getManufacturer());
        instrument.setIonisation(proto.getIonisation());
        instrument.setResolution(proto.getResolution());
        instrument.setModel(proto.getModel());

        // 处理 source 列表
        List<String> sourceList = new ArrayList<>(proto.getSourceList());
        instrument.setSource(sourceList);

        // 处理 analyzer 列表
        List<String> analyzerList = new ArrayList<>(proto.getAnalyzerList());
        instrument.setAnalyzer(analyzerList);

        // 处理 detector 列表
        List<String> detectorList = new ArrayList<>(proto.getDetectorList());
        instrument.setDetector(detectorList);

        return instrument;
    }
}
