namespace utf16letoutf8.bench
{
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Running;
    using System;
    using System.Linq;
    using System.Text;
    [ShortRunJob]
    public class Utf8ToUtf16LargeBench
    {
        [Params(1024 * 1024)]
        public int Length;
        [Params(0x12, 0x123, 0x1234)]
        public int CharacterCode;
        [Params(10)]
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
    }
}