package net.csibio.aird.bean;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
public class ColumnIndex {

    Integer level;

    /**
     * the column start position in the file
     * 在文件中的开始位置
     */
    Long startPtr;

    /**
     * the column end position in the file
     * 在文件中的结束位置
     */
    Long endPtr;

    /**
     * 对应的前体范围，在DDA模式中本字段为空，因为DDA文件的二级数据块没有逻辑连续性，在面向列存储的场景下无意义
     * 在DIA模式下，如果level==1则本字段为空，如果level==2则本字段为对应的前体范围
     */
    WindowRange range;

    Long startMzListPtr;
    Long endMzListPtr;

    Long startRtListPtr;
    Long endRtListPtr;

    Long startSpectraIdListPtr;
    Long endSpectraIdListPtr;

    Long startIntensityListPtr;
    Long endIntensityListPtr;

    int[] mzs; //矩阵横坐标

    int[] rts; //矩阵纵坐标

    int[] spectraIds; //spectraId的数组文件坐标delta值

    int[] intensities; //强度数组坐标delta

    long[] anchors; //坐标插值,用于减少mzIndex定位时的耗时

    public static ColumnIndex fromProto(net.csibio.aird.bean.proto.ColumnInfo.ColumnIndexProto indexProto){
        ColumnIndex index = new ColumnIndex();
        index.setLevel(indexProto.getLevel());
        index.setStartPtr(indexProto.getStartPtr());
        index.setEndPtr(indexProto.getEndPtr());
        index.setStartMzListPtr(indexProto.getStartMzListPtr());
        index.setEndMzListPtr(indexProto.getEndMzListPtr());
        index.setStartRtListPtr(indexProto.getStartRtListPtr());
        index.setEndRtListPtr(indexProto.getEndRtListPtr());
        index.setStartSpectraIdListPtr(indexProto.getStartSpectraIdListPtr());
        index.setEndSpectraIdListPtr(indexProto.getEndSpectraIdListPtr());
        index.setStartIntensityListPtr(indexProto.getStartIntensityListPtr());
        index.setEndIntensityListPtr(indexProto.getEndIntensityListPtr());
        if (indexProto.getMzsCount() > 0) {
            int[] mzs = new int[indexProto.getMzsCount()];
            for (int j = 0; j < indexProto.getMzsCount(); j++) {
                mzs[j] = indexProto.getMzs(j);
            }
            index.setMzs(mzs);
        }
        if (indexProto.getRtsCount() > 0) {
            int[] rts = new int[indexProto.getRtsCount()];
            for (int j = 0; j < indexProto.getRtsCount(); j++) {
                rts[j] = indexProto.getRts(j);
            }
            index.setRts(rts);
        }
        if (indexProto.getSpectraIdsCount() > 0) {
            int[] spectraIds = new int[indexProto.getSpectraIdsCount()];
            for (int j = 0; j < indexProto.getSpectraIdsCount(); j++) {
                spectraIds[j] = indexProto.getSpectraIds(j);
            }
            index.setSpectraIds(spectraIds);
        }
        if (indexProto.getIntensitiesCount() > 0) {
            int[] intensities = new int[indexProto.getIntensitiesCount()];
            for (int j = 0; j < indexProto.getIntensitiesCount(); j++) {
                intensities[j] = indexProto.getIntensities(j);
            }
            index.setIntensities(intensities);
        }
        if (indexProto.getAnchorsCount() > 0) {
            long[] anchors = new long[indexProto.getAnchorsCount()];
            for (int j = 0; j < indexProto.getAnchorsCount(); j++) {
                anchors[j] = indexProto.getAnchors(j);
            }
            index.setAnchors(anchors);
        }
        return index;
    }
}
