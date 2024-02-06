package net.csibio.aird.test.sliceV2;

import com.alibaba.fastjson2.JSON;
import net.csibio.aird.bean.common.Xic;
import net.csibio.aird.parser.ColumnParser;
import org.junit.Test;

import java.io.IOException;

public class TestSliceV2 {

    static String indexPath = "F:\\测试\\SA1.cjson";
    static String oldIndexPath = "F:\\测试\\V1\\SA1.cjson";

    @Test
    public void testEIC() throws IOException {
        ColumnParser parserNew = new ColumnParser(indexPath);
        ColumnParser parserOld = new ColumnParser(oldIndexPath);
        Xic newXic = parserNew.calcXicByMz(313.1733, 0.015);
//        Xic oldXic = parserOld.calcXicByMz(313.1733, 0.015);
//        System.out.println(JSON.toJSONString(newXic.getRts()));
        System.out.println(JSON.toJSONString(newXic.getInts()));
//        System.out.println(JSON.toJSONString(oldXic.getRts()));
//        System.out.println(JSON.toJSONString(oldXic.getInts()));
    }
}
