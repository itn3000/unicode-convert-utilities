namespace utf16letoutf8.bench
{
    using System;
    using System.Linq;
    using System.Text;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Running;
    [ShortRunJob]
    public class Utf8AutoMatonBench
    {
        [Params(0x12, 0x123)]
        public int CodePoint;
        [Params(10 * 1024)]
        public int Length;
        [Params(100)]
        public int LoopNum;
        byte[] CreateBytes(int cp, int length)
        {
            return Encoding.UTF8.GetBytes(Enumerable.Range(0, length).Select(x => (char)cp).ToArray());
        }
        [Benchmark]
        public void Framework()
        {
            var data = CreateBytes(CodePoint, Length);
            for (int i = 0; i < LoopNum; i++)
            {
                Encoding.UTF8.GetString(data, 0, data.Length);
            }
        }
        [Benchmark]
        public void Automaton()
        {
            var data = CreateBytes(CodePoint, Length);
            for (int i = 0; i < LoopNum; i++)
            {
                Utf8AutoMatonDecoder.GetStringFromUtf8(data, 0, data.Length);
            }
        }
    }
}