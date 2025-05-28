# Mallocator

Mallocator is a concept that provides manual memory management using Windows API functions. The Class avatar `Mallocator.C` implements this Mallocator concept as a C# memory allocator that wraps Windows' `VirtualAlloc` and `VirtualFree` functions to provide a simple memory allocation interface.

## Overview

The `Mallocator.C` class avatar maintains a contiguous memory region and allows sequential allocation within that region using bump pointer allocation.

## Features

- **Virtual Memory Allocation**: Uses `VirtualAlloc` to reserve memory pages
- **Sequential Allocation**: Provides bump pointer allocation within the reserved region
- **Alignment Support**: Supports memory alignment for allocated blocks
- **String Allocation**: Helper method to allocate and copy strings to managed memory
- **Byte Array Allocation**: Helper method to allocate and copy byte arrays
- **Manual Cleanup**: Explicit memory deallocation using `VirtualFree`

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

## API Reference

```csharp
namespace Mallocator {
    partial class C
    {
        // Properties
        ulong Base;
        ulong Ptr;
        ulong Size;
        
        // Constructor
        C(ulong size = 1 * VirtualAlloc.PageGranularity, 
          VirtualAlloc.MemoryProtectionConstants protect = PAGE_READWRITE);
        
        // Memory allocation methods
        ulong Alloc(uint size, uint align = 1);
        ulong AllocString(string s, int width = 1);
        ulong AllocBytes(byte[] bs);
        ulong AllocByteString(string s);
        
        // Cleanup
        void Free();
    }
}
```

## Constructor

The constructor initializes a new memory allocator instance using Windows' VirtualAlloc function to reserve a contiguous memory region.

- Default size: 1 page (`VirtualAlloc.PageGranularity`)
- Default protection: `PAGE_READWRITE`

## Dependencies

Requires the `Kernel32` namespace for Windows API functions:
- `VirtualAlloc._`
- `VirtualFree._`
- `Algorithms._e7_` (for alignment calculations)

## Notes

- This is a bump pointer allocator - memory can only be freed all at once
- Individual allocations cannot be freed separately
- Uses unsafe code for direct memory access
- Designed for Windows platforms using Win32 API