using System;

namespace utf16letoutf8.bench
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Running;
    using System.Text;
    using System.Linq;
    [MemoryDiagnoser]
    [ShortRunJob]
    public class Utf8To16Bench
    {
        [Params(0x12, 0x123, 0x1234)]
        // [Params(0x12)]
        public int CharacterCode;
        [Params(10 * 1024)]
        public int Length;
        [Params(100)]
        public int LoopNum;
        [Benchmark]
        public void UnsafeUtf8ToUtf16()
        {
            var bytes = Encoding.UTF8.GetBytes(new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray()));
            for (int i = 0; i < LoopNum; i++)
            {
                Utf8ToUtf16.ToUtf16String(bytes, 0, Length);
            }
        }
        [Benchmark]
        public void ConvertWithFramework()
        {
            var bytes = Encoding.UTF8.GetBytes(new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray()));
            for (int i = 0; i < LoopNum; i++)
            {
                Encoding.UTF8.GetString(bytes);
            }
        }
        [Benchmark]
        public void UnsafeUtf8ToUtf16Preallocated()
        {
            var bytes = Encoding.UTF8.GetBytes(new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray()));
            char[] buf = System.Buffers.ArrayPool<char>.Shared.Rent(bytes.Length);
            for (int i = 0; i < LoopNum; i++)
            {
                Utf8ToUtf16.ToUtf16Chars(bytes, 0, bytes.Length, buf, 0);
            }
            System.Buffers.ArrayPool<char>.Shared.Return(buf);
        }
        [Benchmark]
        public void ConvertWithFrameworkPreallocated()
        {
            var bytes = Encoding.UTF8.GetBytes(new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray()));
            char[] buf = System.Buffers.ArrayPool<char>.Shared.Rent(bytes.Length);
            for (int i = 0; i < LoopNum; i++)
            {
                Encoding.UTF8.GetChars(bytes, 0, bytes.Length, buf, 0);
            }
            System.Buffers.ArrayPool<char>.Shared.Return(buf);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var reporter = BenchmarkRunner.Run<Utf8To16Bench>();
            // BenchmarkRunner.Run<Utf16UtilityBench>();
            // var bench = new Utf8To16Bench();
            // bench.CharacterCode = 0x12;
            // bench.Length = 0x1ffff;
            // bench.LoopNum = 10;
            // bench.UnsafeUtf8ToUtf16();
            // bench.ConvertWithFramework();
        }
    }
}
