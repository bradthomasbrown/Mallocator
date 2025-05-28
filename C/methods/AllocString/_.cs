using Kernel32;
namespace Mallocator {
public partial class C {

unsafe public ulong AllocString(string s, int width=1) {
 ulong a = Alloc((uint)(s.Length+1<<width-1));
 for (int i = 0; i < s.Length; i++)
  *(byte*)(a+(ulong)(i<<width-1)) = (byte)s[i];
 return a;
}

}
}