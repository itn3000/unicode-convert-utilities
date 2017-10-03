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
    public class Utf16UtilityBench
    {
        // [Params(0x12, 0x123, 0x1234)]
        [Params(0x123)]
        public int CharacterCode;
        [Params(16, 1024)]
        // [Params(1024)]
        public int Length;
        [Params(1000)]
        public int LoopNum;
        [Benchmark]
        public void ConvertWithFrameworkPreallocated()
        {
            var str = new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray());
            var buf = new byte[str.Length * 3];
            for (int i = 0; i < LoopNum; i++)
            {
                Encoding.UTF8.GetBytes(str, 0, str.Length, buf, 0);
            }
        }
        [Benchmark]
        public void GetUtf8BytesPreallocated()
        {
            var str = new string(Enumerable.Range(0, Length).Select(x => (char)CharacterCode).ToArray());
            var buffer = new byte[str.Length * 3];
            for (int i = 0; i < LoopNum; i++)
            {
                Utf16Utility.GetUtf8Bytes(str, buffer, 0, out var count);
            }
        }
    }
}