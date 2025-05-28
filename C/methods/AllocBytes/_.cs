using Kernel32;
namespace Mallocator {
public partial class C {

unsafe public ulong AllocBytes(byte[] bs) {
 ulong a = Alloc((uint)bs.Length);
 for (int i = 0; i < bs.Length; i++)
  *(byte*)(a+(ulong)i) = bs[i];
 return a;
}

}
}