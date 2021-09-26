.assembly ClassLibrary1
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit ClassLibrary1.Parser extends [mscorlib]System.Object
{
  .field private static literal int32 WrongArgsNumber = int32(1)
  .field private static literal int32 WrongValueFormat = int32(2)
  .field private static literal int32 WrongOperation = int32(3)
  .field private static literal int32 DivisionByZero = int32(4)
  .method public hidebysig static int32
    ParseArgs(
      string[] args,
      [out] int32& val1,
      [out] valuetype ClassLibrary1.Calculator/SupportedOperations& operation,
      [out] int32& val2
    ) cil managed
  {
    .maxstack 5
    .locals init (
      [0] valuetype ClassLibrary1.Calculator/SupportedOperations V_0,
      [1] int32 V_1,
      [2] bool V_2,
      [3] int32 V_3,
      [4] bool V_4,
      [5] bool V_5,
      [6] bool V_6
    )

    // [18 13 - 18 48]
    IL_0001: ldarg.1      // val1
    IL_0002: ldarg.3      // val2
    IL_0003: ldarg.2      // operation
    IL_0004: ldc.i4.0
    IL_0005: dup
    IL_0006: stloc.0      // V_0
    IL_0007: stind.i4
    IL_0008: ldloc.0      // V_0
    IL_0009: dup
    IL_000a: stloc.1      // V_1
    IL_000b: stind.i4
    IL_000c: ldloc.1      // V_1
    IL_000d: stind.i4

    // [19 13 - 19 46]
    IL_000e: ldarg.0      // args
    IL_000f: call         bool ClassLibrary1.Parser::CheckArgsNumber(string[])
    IL_0014: stloc.2      // V_2

    IL_0015: ldloc.2      // V_2
    IL_0016: brfalse.s    IL_001c

    // [19 47 - 19 70]
    IL_0018: ldc.i4.1
    IL_0019: stloc.3      // V_3
    IL_001a: br.s         IL_0063

    // [20 13 - 21 60]
    IL_001c: ldarg.0      // args
    IL_001d: ldc.i4.0
    IL_001e: ldelem.ref
    IL_001f: ldarg.1      // val1
    IL_0020: call         bool ClassLibrary1.Parser::TryParseValue(string, int32&)
    IL_0025: brtrue.s     IL_0032
    IL_0027: ldarg.0      // args
    IL_0028: ldc.i4.2
    IL_0029: ldelem.ref
    IL_002a: ldarg.3      // val2
    IL_002b: call         bool ClassLibrary1.Parser::TryParseValue(string, int32&)
    IL_0030: br.s         IL_0033
    IL_0032: ldc.i4.1
    IL_0033: stloc.s      V_4

    IL_0035: ldloc.s      V_4
    IL_0037: brfalse.s    IL_003d

    // [21 61 - 21 85]
    IL_0039: ldc.i4.2
    IL_003a: stloc.3      // V_3
    IL_003b: br.s         IL_0063

    // [22 13 - 22 65]
    IL_003d: ldarg.0      // args
    IL_003e: ldc.i4.1
    IL_003f: ldelem.ref
    IL_0040: ldarg.2      // operation
    IL_0041: call         bool ClassLibrary1.Parser::TryParseOperator(string, valuetype ClassLibrary1.Calculator/SupportedOperations&)
    IL_0046: stloc.s      V_5

    IL_0048: ldloc.s      V_5
    IL_004a: brfalse.s    IL_0050

    // [22 66 - 22 88]
    IL_004c: ldc.i4.3
    IL_004d: stloc.3      // V_3
    IL_004e: br.s         IL_0063

    // [23 13 - 23 27]
    IL_0050: ldarg.3      // val2
    IL_0051: ldind.i4
    IL_0052: ldc.i4.0
    IL_0053: ceq
    IL_0055: stloc.s      V_6

    IL_0057: ldloc.s      V_6
    IL_0059: brfalse.s    IL_005f

    // [23 28 - 23 50]
    IL_005b: ldc.i4.4
    IL_005c: stloc.3      // V_3
    IL_005d: br.s         IL_0063

    // [24 13 - 24 22]
    IL_005f: ldc.i4.0
    IL_0060: stloc.3      // V_3
    IL_0061: br.s         IL_0063

    // [25 9 - 25 10]
    IL_0063: ldloc.3      // V_3
    IL_0064: ret

  }

  .method private hidebysig static bool
    CheckArgsNumber(
      string[] args
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )
    // [29 13 - 29 34]
    IL_0001: ldarg.0      // args
    IL_0002: ldlen
    IL_0003: conv.i4
    IL_0004: ldc.i4.3
    IL_0005: ceq
    IL_0007: stloc.0      // V_0

    IL_0008: ldloc.0      // V_0
    IL_0009: brfalse.s    IL_000f

    // [29 35 - 29 48]
    IL_000b: ldc.i4.0
    IL_000c: stloc.1      // V_1
    IL_000d: br.s         IL_002b

    // [30 13 - 30 85]
    IL_000f: ldstr        "Programm needs 3 args, but there is {0}"
    IL_0014: ldarg.0      // args
    IL_0015: ldlen
    IL_0016: conv.i4
    IL_0017: box          [mscorlib]System.Int32
    IL_001c: call         string [mscorlib]System.String::Format(string, object)
    IL_0021: call         void [mscorlib]System.Console::WriteLine(string)
    // [31 13 - 31 25]
    IL_0027: ldc.i4.1
    IL_0028: stloc.1      // V_1
    IL_0029: br.s         IL_002b

    // [32 9 - 32 10]
    IL_002b: ldloc.1      // V_1
    ret

  } 

  .method private hidebysig static bool
    TryParseValue(
      string arg,
      [out] int32& result
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] bool V_0,
      [1] bool V_1
    )
    
    // [36 13 - 36 47]
    IL_0001: ldarg.0      // arg
    IL_0002: ldarg.1      // result
    IL_0003: call         bool [mscorlib]System.Int32::TryParse(string, int32&)
    IL_0008: stloc.0      // V_0

    IL_0009: ldloc.0      // V_0
    IL_000a: brfalse.s    IL_0010

    // [37 17 - 37 30]
    IL_000c: ldc.i4.0
    IL_000d: stloc.1      // V_1
    IL_000e: br.s         IL_0025

    // [38 13 - 38 52]
    IL_0010: ldarg.0      // arg
    IL_0011: ldstr        " is not int"
    IL_0016: call         string [mscorlib]System.String::Concat(string, string)
    IL_001b: call         void [mscorlib]System.Console::WriteLine(string)
   
    // [39 13 - 39 25]
    IL_0021: ldc.i4.1
    IL_0022: stloc.1      // V_1
    IL_0023: br.s         IL_0025

    // [40 9 - 40 10]
    IL_0025: ldloc.1      // V_1
    IL_0026: ret

  } 

  .method private hidebysig static bool
    TryParseOperator(
      string arg,
      [out] valuetype ClassLibrary1.Calculator/SupportedOperations& operation
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] string V_0,
      [1] string V_1,
      [2] bool V_2
    )
    
    // [44 13 - 44 25]
    IL_0001: ldarg.0      // arg
    IL_0002: stloc.1      // V_1

    IL_0003: ldloc.1      // V_1
    IL_0004: stloc.0      // V_0

    IL_0005: ldloc.0      // V_0
    IL_0006: ldstr        "+"
    IL_000b: call         bool [mscorlib]System.String::op_Equality(string, string)
    IL_0010: brtrue.s     IL_003b
    IL_0012: ldloc.0      // V_0
    IL_0013: ldstr        "-"
    IL_0018: call         bool [mscorlib]System.String::op_Equality(string, string)
    IL_001d: brtrue.s     IL_0040
    IL_001f: ldloc.0      // V_0
    IL_0020: ldstr        "*"
    IL_0025: call         bool [mscorlib]System.String::op_Equality(string, string)
    IL_002a: brtrue.s     IL_0045
    IL_002c: ldloc.0      // V_0
    IL_002d: ldstr        "/"
    IL_0032: call         bool [mscorlib]System.String::op_Equality(string, string)
    IL_0037: brtrue.s     IL_004a
    IL_0039: br.s         IL_004f

    // [47 21 - 47 69]
    IL_003b: ldarg.1      // operation
    IL_003c: ldc.i4.0
    IL_003d: stind.i4

    // [48 21 - 48 27]
    IL_003e: br.s         IL_0056

    // [50 21 - 50 70]
    IL_0040: ldarg.1      // operation
    IL_0041: ldc.i4.1
    IL_0042: stind.i4

    // [51 21 - 51 27]
    IL_0043: br.s         IL_0056

    // [53 21 - 53 73]
    IL_0045: ldarg.1      // operation
    IL_0046: ldc.i4.3
    IL_0047: stind.i4

    // [54 21 - 54 27]
    IL_0048: br.s         IL_0056

    // [56 21 - 56 71]
    IL_004a: ldarg.1      // operation
    IL_004b: ldc.i4.2
    IL_004c: stind.i4

    // [57 21 - 57 27]
    IL_004d: br.s         IL_0056

    // [59 21 - 59 41]
    IL_004f: ldarg.1      // operation
    IL_0050: ldc.i4.0
    IL_0051: stind.i4

    // [60 21 - 60 33]
    IL_0052: ldc.i4.1
    IL_0053: stloc.2      // V_2
    IL_0054: br.s         IL_005a

    // [63 13 - 63 26]
    IL_0056: ldc.i4.0
    IL_0057: stloc.2      // V_2
    IL_0058: br.s         IL_005a

    // [64 9 - 64 10]
    IL_005a: ldloc.2      // V_2
    ret
  } 
}
