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
public class ParentFile {

    /**
     * 文件名称 The parent file name
     */
    String name;

    /**
     * 文件位置 The parent file location
     */
    String location;

    /**
     * 文件类型 The parent file type. Usually refers to the suffix of the file
     */
    String formatType;

    public static ParentFile fromProto(AirdInfo.ParentFileProto proto) {
        if (proto == null) {
            return null;
        }

        ParentFile parentFile = new ParentFile();
        parentFile.setName(proto.getName());
        parentFile.setLocation(proto.getLocation());
        parentFile.setFormatType(proto.getFormatType());

        return parentFile;
    }
}
