# Free Method

This file contains the Free method for the Mallocator.C class avatar.

The Free method releases all allocated memory back to the system using VirtualFree. This is a bump pointer allocator, so individual allocations cannot be freed separately.

## Usage

```csharp
var allocator = new Mallocator.C();
// ... use allocator ...

// Release all memory when done
allocator.Free();
```