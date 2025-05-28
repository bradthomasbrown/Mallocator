# AllocByteString Method

This file contains the AllocByteString method for the Mallocator.C class avatar.

The AllocByteString method parses a hex string and allocates the corresponding bytes to memory. It filters out non-hex characters and converts pairs of hex digits to bytes.

## Usage

```csharp
var allocator = new Mallocator.C();

// Parse hex string and allocate bytes
ulong hexPtr = allocator.AllocByteString("00 ab f9 0x42");  // Allocates: 0x00, 0xab, 0xf9, 0x42

// Works with various hex formats
ulong hexPtr2 = allocator.AllocByteString("deadbeef");       // Allocates: 0xde, 0xad, 0xbe, 0xef
```