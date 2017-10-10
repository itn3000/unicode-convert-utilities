namespace utf16letoutf8.test
{
    using System;
    using System.Text;
    using Xunit;
    using System.Linq;
    public class Utf8ToUtf16Test
    {
        [Fact]
        public void Utf8ToUtf16AsciiTest()
        {
            var expected = new char[] { (char)0x00, (char)0x7f, (char)0x3f };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16Enumerable(bytes, 0).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16U7FFTest()
        {
            var expected = new char[] { (char)0x123, (char)0x80, (char)0x7ff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16Enumerable(bytes, 0).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UFFFFTest()
        {
            var expected = new char[] { (char)0x1234, (char)0x800, (char)0xffff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16Enumerable(bytes, 0).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16U10FFFFTest()
        {
            var expected = new char[] { (char)0xdbc0, (char)0xdc00, (char)0xdbc0, (char)0xdc30, (char)0xdbff, (char)0xdfff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16Enumerable(bytes, 0).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16BOMTest()
        {
            var expected = new char[] { (char)0xfeff, (char)0x3f };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16Enumerable(bytes, 0).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UnsafeAsciiTest()
        {
            var expected = new char[] { (char)0x00, (char)0x7f, (char)0x3f };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16String(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UnsafeU7FFTest()
        {
            var expected = new char[] { (char)0x123, (char)0x80, (char)0x7ff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16String(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UnsafeUFFFFTest()
        {
            var expected = new char[] { (char)0x1234, (char)0x800, (char)0xffff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16String(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UnsafeU10FFFFTest()
        {
            var expected = new char[] { (char)0xdbc0, (char)0xdc00, (char)0xdbc0, (char)0xdc30, (char)0xdbff, (char)0xdfff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16String(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Utf8ToUtf16UnsafeBOMTest()
        {
            var expected = new char[] { (char)0xfeff, (char)0x3f };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8ToUtf16.ToUtf16String(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AutoMatonU7F()
        {
            var expected = new char[] { (char)0x00, (char)0x7f, (char)0x3f };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8AutoMatonDecoder.GetStringFromUtf8(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void AutoMatonLong()
        {
            var expected = Enumerable.Range(0, 256).Select(x => (char)0x12).ToArray();
            var bytes = Encoding.UTF8.GetBytes(expected);
            for (int i = 0; i < 2; i++)
            {
                var actual = Utf8AutoMatonDecoder.GetStringFromUtf8(bytes, 0, bytes.Length).ToArray();
                Assert.Equal(expected, actual);
            }
        }
        [Fact]
        public void AutoMatonU10FFFF()
        {
            var expected = new char[] { (char)0xdbc0, (char)0xdc00, (char)0xdbc0, (char)0xdc30, (char)0xdbff, (char)0xdfff };
            var bytes = Encoding.UTF8.GetBytes(expected);
            var actual = Utf8AutoMatonDecoder.GetStringFromUtf8(bytes, 0, bytes.Length).ToArray();
            Assert.Equal(expected.Select(x => (int)x), actual.Select(x => (int)x));
        }
    }
}