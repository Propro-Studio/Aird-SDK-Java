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

@Data
public class MobiInfo {

    /**
     * start position in the aird for mobi array
     */
    long dictStart;

    /**
     * end position in the aird for mobi array
     */
    long dictEnd;

    /**
     * ion mobility unit
     */
    String unit;

    /**
     * ion mobility value
     */
    Double value;

    /**
     * ion mobility type, see MobilityType
     */
    String type;

    public static MobiInfo fromProto(AirdInfo.MobiInfoProto proto) {
        if (proto == null) {
            return null;
        }

        MobiInfo mobiInfo = new MobiInfo();
        mobiInfo.dictStart = proto.getDictStart();
        mobiInfo.dictEnd = proto.getDictEnd();
        mobiInfo.unit = proto.getUnit();
        mobiInfo.value = proto.getValue();
        mobiInfo.type = proto.getType();

        return mobiInfo;
    }
}
