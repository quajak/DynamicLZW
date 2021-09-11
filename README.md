# DynamicLZW
Allows Dynamic LZW Decompression in C#.

## To use:
The only function you need is:
`LZWDecoder.Decode(byte[] data, int maxKeySize = 16, int dictionarySize = 256, int dictionaryBaseOffset = 0, int indexSize = 8)`
For normal compressed data, simply calling `LZWDecoder.Decode(byte[] data)` should suffice.
