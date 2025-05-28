# Alloc Method

This file contains the Alloc method for the Mallocator.C class avatar.

The Alloc method allocates a memory block of the specified size with optional alignment within the reserved memory region.

## Usage

```csharp
var allocator = new Mallocator.C();

// Allocate 1KB without alignment
ulong ptr1 = allocator.Alloc(1024);

// Allocate 512 bytes with 16-byte alignment
ulong ptr2 = allocator.Alloc(512, 16);
```