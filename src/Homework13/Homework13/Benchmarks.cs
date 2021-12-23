using System;
using BenchmarkDotNet.Attributes;

namespace Homework13
{
    [MemoryDiagnoser]
    [MedianColumn]
    [MaxColumn]
    [MinColumn]
    public class Benchmarks
    {
        private static readonly TestRunner TestRunnerRunner = new();
        private static readonly int num = 10;

        [Benchmark]
        public void Simple() => TestRunnerRunner.SimpleMethod(num);

        [Benchmark]
        public void Static() => TestRunner.StaticMethod(num);

        [Benchmark]
        public void Virtual() => TestRunnerRunner.VirtualMethod(num);

        [Benchmark]
        public void Generic() => TestRunnerRunner.GenericMethod(num);

        [Benchmark]
        public void Dynamic() => TestRunnerRunner.DynamicMethod(num);

        [Benchmark]
        public void Reflection() => TestRunnerRunner.ReflectionMethod(num);
    }

    internal class Test
    {
        public static string StaticMethod(int num) => (num+num).ToString();
        public string SimpleMethod(int num) => (num+num).ToString();
        public virtual string VirtualMethod(int num) => (num+num).ToString();
        public string GenericMethod<T>(T num) where T : struct => num.ToString()!+num;
        public string DynamicMethod(dynamic num) => (num+num).ToString();

        public string ReflectionMethod(int num) =>
            (typeof(Test).GetMethod("StaticMethod")!.Invoke(default, new[] { (object)num }) as string)!;
    }

    internal class TestRunner : Test
    {
    }
}