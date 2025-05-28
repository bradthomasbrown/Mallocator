# AllocString Method

This file contains the AllocString method for the Mallocator.C class avatar.

The AllocString method allocates memory and copies a string to the allocated region, with support for different character widths.

## Usage

```csharp
var allocator = new Mallocator.C();

// Allocate and copy a string (1-byte per character)
ulong strPtr = allocator.AllocString("Hello World");

// Allocate and copy a string with 2-byte characters
ulong wideStrPtr = allocator.AllocString("Hello World", 2);
```