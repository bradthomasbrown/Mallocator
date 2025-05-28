using Kernel32;
namespace Mallocator {
public partial class C {

unsafe public ulong AllocByteString(string s) {
 var hexChars = "";
 for (int i = 0; i < s.Length; i++) {
  char c = s[i];
  if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'))
   hexChars += c;
 }
 
 if (hexChars.Length % 2 != 0)
  throw new System.ArgumentException("Odd number of hex characters");
 
 int byteCount = hexChars.Length / 2;
 ulong a = Alloc((uint)byteCount);
 
 for (int i = 0; i < byteCount; i++) {
  string hexByte = hexChars.Substring(i * 2, 2);
  byte b = System.Convert.ToByte(hexByte, 16);
  *(byte*)(a + (ulong)i) = b;
 }
 
 return a;
}

}
}