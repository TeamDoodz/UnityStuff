using System;
using System.IO;
using System.IO.Compression;
using System.Text;

/// <summary>
/// <seealso cref="https://stackoverflow.com/questions/7343465/compression-decompression-string-with-c-sharp"/>
/// </summary>
public static class StringCompresser {
    /// <summary>
    /// Compresses the string.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public static byte[] CompressString(string text) {
        byte[] buffer = Encoding.UTF8.GetBytes(text);
        var memoryStream = new MemoryStream();
        using(var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true)) {
            gZipStream.Write(buffer, 0, buffer.Length);
        }

        memoryStream.Position = 0;

        var compressedData = new byte[memoryStream.Length];
        memoryStream.Read(compressedData, 0, compressedData.Length);

        var gZipBuffer = new byte[compressedData.Length + 4];
        Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
        Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
        return gZipBuffer;
    }

    /// <summary>
    /// Decompresses the string.
    /// </summary>
    /// <param name="compressedText">The compressed text.</param>
    /// <returns></returns>
    public static string DecompressString(byte[] compressedText) {
        byte[] gZipBuffer = compressedText;
        using(var memoryStream = new MemoryStream()) {
            int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
            memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

            var buffer = new byte[dataLength];

            memoryStream.Position = 0;
            using(var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress)) {
                gZipStream.Read(buffer, 0, buffer.Length);
            }

            return Encoding.UTF8.GetString(buffer);
        }
    }
}