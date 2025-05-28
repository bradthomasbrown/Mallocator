# Mallocator

A C# memory allocator class that provides manual memory management using Windows API functions.

## Overview

The `Mallocator` class wraps Windows' `VirtualAlloc` and `VirtualFree` functions to provide a simple memory allocation interface. It maintains a contiguous memory region and allows sequential allocation within that region.

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
var allocator = new Mallocator();

// Create allocator with custom size and protection
var allocator = new Mallocator(
    size: 4 * VirtualAlloc.PageGranularity,
    protect: VirtualAlloc.MemoryProtectionConstants.PAGE_READWRITE
);

// Allocate memory blocks
ulong ptr1 = allocator.Alloc(1024);        // Allocate 1KB
ulong ptr2 = allocator.Alloc(512, 16);     // Allocate 512 bytes, 16-byte aligned

// Allocate strings and byte arrays
ulong strPtr = allocator.AllocStr("Hello World");
ulong bytesPtr = allocator.AllocBytes(new byte[] { 0x01, 0x02, 0x03 });
ulong hexPtr = allocator.AllocByteStr("00 ab f9 0x42");  // Allocates bytes: 0x00, 0xab, 0xf9, 0x42

// Clean up when done
allocator.Free();
```

## Methods

### Constructor
- `Mallocator(ulong size, MemoryProtectionConstants protect)` - Initialize with custom size and protection
- Default size: 1 page (`VirtualAlloc.PageGranularity`)
- Default protection: `PAGE_READWRITE`

### Allocation
- `ulong Alloc(uint size, uint align=1)` - Allocate memory block with optional alignment
- `ulong AllocStr(string s, int width=1)` - Allocate and copy string with character width
- `ulong AllocBytes(byte[] bs)` - Allocate and copy byte array
- `ulong AllocByteStr(string s)` - Parse hex string and allocate bytes (e.g., "00 ab f9" → 3 bytes)

### Cleanup
- `void Free()` - Release all allocated memory back to the system

## Properties

- `ulong Base` - Base address of the allocated memory region
- `ulong Ptr` - Current allocation pointer within the region  
- `ulong Size` - Total size of the allocated memory region

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