using System;
using System.IO.Compression;
using System.IO;
using System.Text;

public class decode {
  public static byte[] Decompress(byte[] input) {
    byte[] buffer;
    using(MemoryStream stream = new MemoryStream(input)) {
      using(MemoryStream stream2 = new MemoryStream()) {
        using(DeflateStream stream3 = new DeflateStream(stream, CompressionMode.Decompress)) {
          stream3.CopyTo(stream2);
        }
        buffer = stream2.ToArray();
      }
    }
    return buffer;
  }

  public static string Unzip(string input) {
    if (string.IsNullOrEmpty(input)) {
      return input;
    }
    try {
      byte[] bytes = Decompress(Convert.FromBase64String(input));
      return Encoding.UTF8.GetString(bytes);
    }
    catch(Exception) {
      return input;
    }
  }

}

public class program {
  public static void Main() {
	var Input=Console.ReadLine();
    Console.WriteLine(Encoding.Default.GetString(decode.Decompress(Convert.FromBase64String(Input))));
  }
}