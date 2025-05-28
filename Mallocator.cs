using Kernel32;
public class Mallocator {


public ulong Base;
public ulong Ptr;
public ulong Size;

public Mallocator(
 ulong                                  size    = 1 * VirtualAlloc.PageGranularity                     ,
 VirtualAlloc.MemoryProtectionConstants protect = VirtualAlloc.MemoryProtectionConstants.PAGE_READWRITE
) {
 Base = VirtualAlloc._(
  size    : size   ,
  protect : protect
 );
 Size = size;
 Ptr  = Base;
}

public ulong Alloc(uint size, uint align=1) {
 Ptr = Algorithms._e7_(Ptr, align);
 ulong pf = Ptr;
 Ptr = Ptr + size;
 return pf;
}

public void Free() {
 VirtualFree._(
  address : Base,
  size    : Size
 );
}

unsafe public ulong AllocStr(string s, int width=1) {
 ulong a = Alloc((uint)(s.Length+1<<width-1));
 for (int i = 0; i < s.Length; i++)
  *(byte*)(a+(ulong)(i<<width-1)) = (byte)s[i];
 return a;
}

unsafe public ulong AllocBytes(byte[] bs) {
 ulong a = Alloc((uint)bs.Length);
 for (int i = 0; i < bs.Length; i++)
  *(byte*)(a+(ulong)i) = bs[i];
 return a;
}

unsafe public ulong AllocByteStr(string s) {
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