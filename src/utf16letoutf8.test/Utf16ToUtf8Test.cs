using System;
using Xunit;

namespace utf16letoutf8.test
{
    using System.Text;
    using System.Linq;
    public class Utf16ToUtf8Test
    {
        [Fact]
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
