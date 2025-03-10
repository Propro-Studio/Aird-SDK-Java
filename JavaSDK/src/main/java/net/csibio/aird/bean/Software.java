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
public class Software {

    /**
     * 软件名称 The software name
     */
    String name;

    /**
     * 软件版本号 The software version
     */
    String version;

    /**
     * 软件类型 The software function type
     */
    String type;

    public static Software fromProto(AirdInfo.SoftwareProto proto) {
        if (proto == null) {
            return null;
        }

        Software software = new Software();
        software.setName(proto.getName());
        software.setVersion(proto.getVersion());
        software.setType(proto.getType());

        return software;
    }
}
