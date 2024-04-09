package net.csibio.aird.compressor.intcomp;

import me.lemire.integercompression.*;
import net.csibio.aird.enums.IntCompType;

import java.util.Arrays;

public class DeltaZigzagVBWrapper implements IntComp {
    @Override
    public String getName() {
        return IntCompType.DZVB.getName();
    }

    @Override
    public int[] encode(int[] uncompressed) {
        IntegerCODEC codec = new DeltaZigzagVariableByte();
        int[] compressed = new int[uncompressed.length + uncompressed.length / 100 + 1024];// could need more
        IntWrapper outputoffset = new IntWrapper(1);
        codec.compress(uncompressed, new IntWrapper(0), uncompressed.length, compressed, outputoffset);
        compressed = Arrays.copyOf(compressed, outputoffset.intValue());
        compressed[0] = uncompressed.length;
        return compressed;
    }

    @Override
    public int[] decode(int[] compressed) {
        if (compressed.length == 0) {
            return new int[0];
        }
        IntegerCODEC codec = new DeltaZigzagVariableByte();
        int[] decompressed = new int[compressed[0]];
        codec.uncompress(compressed, new IntWrapper(1), compressed.length - 1, decompressed, new IntWrapper(0));
        return decompressed;
    }
}
