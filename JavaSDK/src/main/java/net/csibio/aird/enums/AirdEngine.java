/*
 * Copyright (c) 2020 CSi Biotech
 * AirdSDK and AirdPro are licensed under Mulan PSL v2.
 * You can use this software according to the terms and conditions of the Mulan PSL v2.
 * You may obtain a copy of Mulan PSL v2 at:
 *          http://license.coscl.org.cn/MulanPSL2
 * THIS SOFTWARE IS PROVIDED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO NON-INFRINGEMENT, MERCHANTABILITY OR FIT FOR A PARTICULAR PURPOSE.
 * See the Mulan PSL v2 for more details.
 */

package net.csibio.aird.enums;

/**
 * Activation Method
 */
public enum AirdEngine {

    /**
     * CID Activation Method
     */
    RowCompression("RowCompression", 0),

    /**
     * HCD Activation Method
     */
    ColumnCompression("ColumnCompression", 1),

    ;

    /**
     * Activation Name
     */
    private final String name;

    /**
     * Activation Description
     */
    private final int code;

    /**
     * 构造函数
     *
     * @param name engine name
     * @param code engine code
     */
    AirdEngine(String name, int code) {
        this.code = code;
        this.name = name;
    }

    /**
     * @return the name
     */
    public String getName() {
        return name;
    }

    /**
     * @return the code
     */
    public int getCode() {
        return code;
    }
}
