using Kernel32;
namespace Mallocator {
public partial class C {

public void Free() {
 VirtualFree._(
  address : Base,
  size    : Size
 );
}

}
}