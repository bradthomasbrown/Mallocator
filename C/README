# Constructor

This file contains the constructor for the Mallocator.C class avatar.

The constructor initializes a new memory allocator instance using Windows' VirtualAlloc function to reserve a contiguous memory region.

## Usage

```csharp
// Create allocator with default size (1 page) and read/write protection
var allocator = new Mallocator.C();

// Create allocator with custom size and protection
var allocator = new Mallocator.C(
    size: 4 * VirtualAlloc.PageGranularity,
    protect: VirtualAlloc.MemoryProtectionConstants.PAGE_READWRITE
);
```