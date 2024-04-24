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

import java.util.ArrayList;
import java.util.List;

@Data
public class ChromatogramIndex {

    /**
     * the total chromatograms count, exclude the TIC and BPC chromatograms
     */
    Long totalCount;

    /**
     * acquisitionMethod
     */
    String type;

    /**
     * 1:MS1;2:MS2
     */
    List<String> ids;

    /**
     * 用于MRM的化合物名称
     */
    List<String> compounds;

    /**
     * the block start position in the file
     * 在文件中的开始位置
     */
    Long startPtr;

    /**
     * the block end position in the file
     * 在文件中的结束位置
     */
    Long endPtr;

    /**
     * Every Chromatogram's activator in the block
     * 所有该块中的activator列表
     */
    List<String> activators;

    /**
     * Every Chromatogram's energy in the block
     * 所有该块中的energy列表
     */
    List<Float> energies;

    /**
     * Every Chromatogram's polarity in the block
     * 所有该块中的polarity列表
     */
    List<String> polarities;

    /**
     * The precursor ion list
     */
    List<WindowRange> precursors;

    /**
     * The product ion list
     */
    List<WindowRange> products;

    /**
     * spectrum num list
     * 谱图序列号
     */
    List<Integer> nums;

    /**
     * rts for chromatogram
     */
    List<Integer> rts;

    /**
     * 一个块中所有子谱图的intensity的压缩后的大小列表
     */
    List<Integer> ints;

    /**
     * Features of every index
     * 用于存储KV键值对
     */
    String features;

    public static ChromatogramIndex fromProto(net.csibio.aird.bean.proto.AirdInfo.ChromatogramIndexProto proto) {
        if (proto == null) {
            return null;
        }

        ChromatogramIndex index = new ChromatogramIndex();
        index.setTotalCount(proto.getTotalCount());
        index.setType(proto.getType());

        // 处理 ids 列表
        List<String> ids = new ArrayList<>();
        ids.addAll(proto.getIdsList());
        index.setIds(ids);

        // 处理 compounds 列表
        List<String> compounds = new ArrayList<>();
        compounds.addAll(proto.getCompoundsList());
        index.setCompounds(compounds);

        // ... 以此类推，处理其他列表字段 ...

        // 处理 precursors 列表
        List<WindowRange> precursors = new ArrayList<>();
        for (net.csibio.aird.bean.proto.WindowRange.WindowRangeProto protoPrecursor : proto.getPrecursorsList()) {
            precursors.add(WindowRange.fromProto(protoPrecursor));
        }
        index.setPrecursors(precursors);

        // 处理 products 列表
        List<WindowRange> products = new ArrayList<>();
        for (net.csibio.aird.bean.proto.WindowRange.WindowRangeProto protoProduct : proto.getProductsList()) {
            products.add(WindowRange.fromProto(protoProduct));
        }
        index.setProducts(products);

        // 设置其他字段
        index.setStartPtr(proto.getStartPtr());
        index.setEndPtr(proto.getEndPtr());
        index.setActivators(new ArrayList<>(proto.getActivatorsList()));
        index.setEnergies(new ArrayList<>(proto.getEnergiesList()));
        index.setPolarities(new ArrayList<>(proto.getPolaritiesList()));
        index.setNums(new ArrayList<>(proto.getNumsList()));
        index.setRts(new ArrayList<>(proto.getRtsList()));
        index.setInts(new ArrayList<>(proto.getIntsList()));
        index.setFeatures(proto.getFeatures());

        return index;
    }
}
