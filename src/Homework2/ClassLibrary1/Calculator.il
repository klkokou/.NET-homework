.assembly ClassLibrary1
{
  .ver 1:0:0:0
}

.class public abstract sealed auto ansi beforefieldinit
  ClassLibrary1.Calculator
    extends [mscorlib]System.Object
{

  .class nested public sealed auto ansi
    SupportedOperations
      extends [mscorlib]System.Enum
  {

    .field public specialname rtspecialname int32 value__

    .field public static literal valuetype ClassLibrary1.Calculator/SupportedOperations Plus = int32(0) // 0x00000000

    .field public static literal valuetype ClassLibrary1.Calculator/SupportedOperations Minus = int32(1) // 0x00000001

    .field public static literal valuetype ClassLibrary1.Calculator/SupportedOperations Divide = int32(2) // 0x00000002

    .field public static literal valuetype ClassLibrary1.Calculator/SupportedOperations Multiply = int32(3) // 0x00000003
  } // end of class SupportedOperations

  .method public hidebysig static float64
    Calculate(
      int32 val1,
      valuetype ClassLibrary1.Calculator/SupportedOperations operation,
      int32 val2
    ) cil managed
  {
    .maxstack 2
    .locals init (
      [0] float64 result,
      [1] valuetype ClassLibrary1.Calculator/SupportedOperations V_1,
      [2] valuetype ClassLibrary1.Calculator/SupportedOperations V_2,
      [3] float64 V_3
    )

    // [16 9 - 16 10]
    IL_0000: nop

    // [17 13 - 17 30]
    IL_0001: ldc.r8       0.0
    IL_000a: stloc.0      // result

    // [18 13 - 18 31]
    IL_000b: ldarg.1      // operation
    IL_000c: stloc.2      // V_2

    IL_000d: ldloc.2      // V_2
    IL_000e: stloc.1      // V_1

    IL_000f: ldloc.1      // V_1
    IL_0010: switch       (IL_0027, IL_002e, IL_003c, IL_0035)
    IL_0025: br.s         IL_0044

    // [21 21 - 21 42]
    IL_0027: ldarg.0      // val1
    IL_0028: ldarg.2      // val2
    IL_0029: add
    IL_002a: conv.r8
    IL_002b: stloc.0      // result

    // [22 21 - 22 27]
    IL_002c: br.s         IL_0044

    // [24 21 - 24 42]
    IL_002e: ldarg.0      // val1
    IL_002f: ldarg.2      // val2
    IL_0030: sub
    IL_0031: conv.r8
    IL_0032: stloc.0      // result

    // [25 21 - 25 27]
    IL_0033: br.s         IL_0044

    // [27 21 - 27 42]
    IL_0035: ldarg.0      // val1
    IL_0036: ldarg.2      // val2
    IL_0037: mul
    IL_0038: conv.r8
    IL_0039: stloc.0      // result

    // [28 21 - 28 27]
    IL_003a: br.s         IL_0044

    // [30 21 - 30 50]
    IL_003c: ldarg.0      // val1
    IL_003d: conv.r8
    IL_003e: ldarg.2      // val2
    IL_003f: conv.r8
    IL_0040: div
    IL_0041: stloc.0      // result

    // [31 21 - 31 27]
    IL_0042: br.s         IL_0044

    // [34 13 - 34 27]
    IL_0044: ldloc.0      // result
    IL_0045: stloc.3      // V_3
    IL_0046: br.s         IL_0048

    // [35 9 - 35 10]
    IL_0048: ldloc.3      // V_3
    IL_0049: ret

  } // end of method Calculator::Calculate
} // end of class Homework1.Calculator
