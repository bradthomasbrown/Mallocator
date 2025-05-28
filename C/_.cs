using Kernel32;
namespace Mallocator {
public partial class C {

public C(
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

}
}