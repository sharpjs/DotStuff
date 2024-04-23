## About

DotStuff is a source-only NuGet package that adds few helpful extensions for
method chaining in C#.

*Source-only* here means that DotStuff adds a single, hidden C# file to your
project.  There is no extra DLL to ship.  For libraries, there is no extra
dependency that referencing projects see.  This is ideal for a micro-package
like DotStuff that consists of a single file.  The file itself is written
carefully to avoid conflicts with existing code.

## Status

[![Build](https://github.com/sharpjs/DotStuff/workflows/Build/badge.svg)](https://github.com/sharpjs/DotStuff/actions)
[![NuGet](https://img.shields.io/nuget/v/DotStuff.svg)](https://www.nuget.org/packages/DotStuff)
[![NuGet](https://img.shields.io/nuget/dt/DotStuff.svg)](https://www.nuget.org/packages/DotStuff)

- **Tested:**      100% coverage by automated tests.

- **Documented:**  IntelliSense on everything.  Examples below.

## Installation

Install [this NuGet Package](https://www.nuget.org/packages/DotStuff) in your
project.

## Usage

```csharp
// Right assign
foo.AssignTo(out bar)       // => bar = foo;

// Right coalesce
foo.CoalesceTo(ref bar)     // => bar ??= foo;

// Tap
foo.Tap(action)             // { action(foo);       return foo; }
foo.Tap(x, action)          // { action(foo, x);    return foo; }
foo.Tap(x, y, action)       // { action(foo, x, y); return foo; }
// ... up to 3 extra arguments

// Apply
foo.Apply(function)         // => function(foo);
foo.Apply(x, function)      // => function(foo, x);
foo.Apply(x, y, function)   // => function(foo, x, y);
// ... up to 3 extra arguments
```

For Ruby developers, `Tap` and `Apply` are the C# equivalents of
[`tap`](https://ruby-doc.org/3.3.0/Kernel.html#method-i-tap) and
[`then`](https://ruby-doc.org/3.3.0/Kernel.html#method-i-then).
`AssignTo` is similar to using Ruby's `=>`
[pattern-matching](https://ruby-doc.org/3.3.0/syntax/pattern_matching_rdoc.html)
operator for rightward assignment.

## Options

DotStuff responds to the following preprocessor symbols.

- `DOTSTUFF_DISABLE`

  Define this symbol to disable DotStuff completely.

- `DOTSTUFF_ENABLE_CODE_COVERAGE`

  Define this symbol to include the DotStuff extension methods in code
  coverage.  By default, the extension methods are excluded.

- `DOTSTUFF_HAS_CSHARP_8_OR_GREATER`

  If this symbol is defined, DotStuff uses C# 8.0 features, such as the `??=`
  operator required for `CoalesceTo`.

  This symbol is defined by default for target frameworks that use C# 8.0 or
  later by default: .NET 5.0, .NET Core 3.0, .NET Standard 2.1, and later.

  Define this symbol to use C# 8.0 features on older target frameworks.  Make
  sure to [configure the language version](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version#override-the-default)
  of the project to C# 8.0 or later.

- `DOTSTUFF_HAS_NULLABLE`

  If this symbol is defined, DotStuff uses [nullability attributes](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/nullable-analysis).

  This symbol is defined by default for target frameworks that provide these
  attributes: .NET 5.0, .NET Core 3.0, .NET Standard 2.1, and later.

  Define this symbol to use nullability attributes on older target frameworks.
  Some source of those attributes will be required.  One easy option is to use
  Manuel Römer's [Nullable](https://www.nuget.org/packages/nullable) package.

<!--
  Copyright 2024 Jeffrey Sharp
  SPDX-License-Identifier: ISC
-->
