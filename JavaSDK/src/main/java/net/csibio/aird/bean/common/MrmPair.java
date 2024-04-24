package net.csibio.aird.bean.common;

import lombok.Data;
import net.csibio.aird.bean.WindowRange;

@Data
public class MrmPair {

    /**
     * order number for current spectrum
     */
    int num;

    String id;

    String key;

    WindowRange precursor;
    WindowRange product;
    String polarity;
    String activator;
    Float energy;

    double[] rts;
    double[] ints;
}
