using Kernel32;
namespace Mallocator {
public partial class C {

public ulong Alloc(uint size, uint align=1) {
 Ptr = Algorithms._e7_(Ptr, align);
 ulong pf = Ptr;
 Ptr = Ptr + size;
 return pf;
}

}
}