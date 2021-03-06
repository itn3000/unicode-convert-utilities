using System;
using Xunit;

namespace utf16letoutf8.test
{
    using System.Text;
    using System.Linq;
    public class Utf16ToUtf8Test
    {
        [Fact]
        public void Utf8BytesU7F()
        {
            var expected = new char[] { (char)0x01, (char)0x7f, (char)0x12 };
            Utf16Utility.GetUtf8Bytes(new string(expected), out var bytes, out var count);
            var actual = Encoding.UTF8.GetString(bytes, 0, count).ToCharArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
        [Fact]
        public void Utf8BytesU7FF()
        {
            var expected = new char[] { (char)0x80, (char)0x7ff, (char)0x123 };
            Utf16Utility.GetUtf8Bytes(new string(expected), out var bytes, out var count);
            var actual = Encoding.UTF8.GetString(bytes, 0, count).ToCharArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
        [Fact]
        public void Utf8BytesUFFFF()
        {
            var expected = new char[] { (char)0x800, (char)0xd7ff, (char)0xffff };
            Utf16Utility.GetUtf8Bytes(new string(expected), out var bytes, out var count);
            var actual = Encoding.UTF8.GetString(bytes, 0, count).ToCharArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
        [Fact]
        public void Utf8BytesU10FFFF()
        {
            var expected = new char[]{
                (char)0xd800, (char)0xdc00,
                (char)0xdbff, (char)0xdfff,
                (char)0xd802, (char)0xdc52,
            };
            Utf16Utility.GetUtf8Bytes(new string(expected), out var bytes, out var count);
            var actual = Encoding.UTF8.GetString(bytes, 0, count).ToCharArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
        [Fact]
        public void Utf8BytesU7FAllocated()
        {
            var expected = Enumerable.Range(0, 10).Select(x => (char)(x + 1)).ToArray();
            var buf = new byte[expected.Length];
            Utf16Utility.GetUtf8Bytes(new string(expected), buf, 0, out var count);
            var actual = Encoding.UTF8.GetString(buf, 0, count).ToCharArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
        // [Fact]
        public void AsciiString()
        {
            var str = "abcde012345=!";
            var bytes = Encoding.UTF8.GetBytes(str);
            var actual = new byte[bytes.Length];
            var en = Utf16Utility.GetEnumerator(str.ToCharArray(), 0, str.Length);
            byte b;
            int idx = 0;
            while (en.TryGetNext(out b))
            {
                actual[idx] = b;
                idx++;
            }
            Assert.Equal(bytes, actual);
        }
    }
}
