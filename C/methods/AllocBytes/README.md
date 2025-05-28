# AllocBytes Method

This file contains the AllocBytes method for the Mallocator.C class avatar.

The AllocBytes method allocates memory and copies a byte array to the allocated region.

## Usage

```csharp
var allocator = new Mallocator.C();

// Allocate and copy a byte array
byte[] data = { 0x01, 0x02, 0x03, 0xFF };
ulong bytesPtr = allocator.AllocBytes(data);
```