from Compressor.IntCompressor import IntCompressor
from Enums.IntCompType import IntCompType


class BinPackingWrapper:
    codec = 'simdbinarypacking'

    def getName(self):
        return IntCompType.BP

    def encode(self, input):
        compressed = IntCompressor(self.codec).encode(input)
        return compressed

    def decode(self, input, offset, length):
        decompressed = IntCompressor(self.codec).decode(input, offset, length)
        return decompressed
