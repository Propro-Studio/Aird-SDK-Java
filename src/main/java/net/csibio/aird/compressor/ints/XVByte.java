package net.csibio.aird.compressor.ints;

import me.lemire.integercompression.differential.IntegratedIntCompressor;
import me.lemire.integercompression.differential.IntegratedVariableByte;
import net.csibio.aird.compressor.ByteCompressor;
import net.csibio.aird.compressor.ByteTrans;
import net.csibio.aird.compressor.CompressorType;

public class XVByte {

  /**
   * XDPD Encoder, default byte compressor is Zlib
   *
   * @param sortedInts the sorted integers
   * @return the compressed data
   */
  public static byte[] encode(int[] sortedInts) {
    return encode(sortedInts, CompressorType.Zlib);
  }

  /**
   * ZDPD Encoder
   *
   * @param sortedInts the sorted integers
   * @return the compressed data
   */
  public static byte[] encode(int[] sortedInts, CompressorType byteCompType) {
    int[] compressedInts = new IntegratedIntCompressor(new IntegratedVariableByte()).compress(
        sortedInts);
    byte[] bytes = ByteTrans.intToByte(compressedInts);
    return new ByteCompressor(byteCompType).encode(bytes);
  }

  public static byte[] encode(double[] sortedFloats, double precision,
      CompressorType compType) {
    int[] sortedInts = new int[sortedFloats.length];
    for (int i = 0; i < sortedFloats.length; i++) {
      sortedInts[i] = (int) (precision * sortedFloats[i]);
    }
    return encode(sortedInts, compType);
  }

  public static int[] decode(byte[] bytes) {
    return decode(bytes, CompressorType.Zlib);
  }

  public static int[] decode(byte[] bytes, CompressorType type) {
    byte[] decodeBytes = new ByteCompressor(type).decode(bytes);
    int[] zipInts = ByteTrans.byteToInt(decodeBytes);
    int[] sortedInts = new IntegratedIntCompressor(new IntegratedVariableByte()).uncompress(
        zipInts);
    return sortedInts;
  }
}
