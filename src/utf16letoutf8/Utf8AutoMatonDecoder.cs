namespace utf16letoutf8
{
    using System;
    using System.Runtime.CompilerServices;
    public static class Utf8AutoMatonDecoder
    {
        static readonly byte[] utf8d = new byte[]
        {
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 00..1f
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 20..3f
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 40..5f
  0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0, // 60..7f
  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9,9, // 80..9f
  7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7,7, // a0..bf
  8,8,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2, // c0..df
  0xa,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x3,0x4,0x3,0x3, // e0..ef
  0xb,0x6,0x6,0x6,0x5,0x8,0x8,0x8,0x8,0x8,0x8,0x8,0x8,0x8,0x8,0x8, // f0..ff
  0x0,0x1,0x2,0x3,0x5,0x8,0x7,0x1,0x1,0x1,0x4,0x6,0x1,0x1,0x1,0x1, // s0..s0
  1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,0,1,1,1,1,1,1, // s1..s2
  1,2,1,1,1,1,1,2,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1, // s3..s4
  1,2,1,1,1,1,1,1,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,3,1,1,1,1,1,1, // s5..s6
  1,3,1,1,1,1,1,3,1,3,1,1,1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,1, // s7..s8
          };
        const uint UTF8_ACCEPT = 0;
        const uint UTF8_REJECT = 12;
        [ThreadStatic]
        static char[] buffer = null;
        public static unsafe string GetStringFromUtf8(byte[] src, int offset, int count)
        {
            buffer = buffer != null && buffer.Length >= count ? buffer : new char[count];
            uint codepoint = 0;
            uint state = 0;
            var dst = (char*)Unsafe.AsPointer(ref buffer[0]);
            var d = dst;
            var s = (byte*)Unsafe.AsPointer(ref src[offset]);
            var src_actual_end = s + count;

            while (s < src_actual_end)
            {
                var dst_words_free = buffer.Length - (d - dst);
                byte* src_current_end = s + dst_words_free;
                if (src_actual_end < src_current_end)
                {
                    src_current_end = src_actual_end;
                }
                if (src_current_end <= s)
                {
                    state = 0;
                    break;
                }
                while (s < src_current_end)
                {
                    if (decode(ref state, ref codepoint, *s) != 0)
                    {
                        s++;
                        continue;
                    }
                    if (codepoint > 0xffff)
                    {
                        *d = (char)(0xd7c0 + (codepoint >> 10));
                        d[1] = (char)(0xdc00 + (codepoint & 0x3ff));
                        d += 2;
                        s++;
                    }
                    else
                    {
                        if (codepoint < 0x80)
                        {
                            while ((s < src_current_end - 8) && (*(ulong*)s & 0x8080808080808080UL) == 0)
                            {
                                d[0] = (char)s[0];
                                d[1] = (char)s[1];
                                d[2] = (char)s[2];
                                d[3] = (char)s[3];
                                d[4] = (char)s[4];
                                d[5] = (char)s[5];
                                d[6] = (char)s[6];
                                d[7] = (char)s[7];
                                d += 8;
                                s += 8;
                            }
                            if (s < src_actual_end)
                            {
                                *d = (char)codepoint;
                                d++;
                                s++;
                            }
                        }
                        else
                        {
                            *d = (char)codepoint;
                            d++;
                            s++;
                        }
                    }
                }
            }
            if (state != UTF8_ACCEPT)
            {
                throw new Exception($"state exception:{state}");
            }
        // *d = (char)0;
        // d++;
            return new string(buffer, 0, (int)(d - dst));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static unsafe uint decode(ref uint state, ref uint codep, byte data)
        {
            // var type = utf8d[data];
            // codep = (state != UTF8_ACCEPT) ?
            //     (uint)((data & 0x3fu) | (codep << 6)) : (uint)((0xff >> type) & data);
            // state = utf8d[256 + state + type];
            // return state;
            var type = utf8d[data];

            codep = (state != UTF8_ACCEPT) ?
              (uint)((data & 0x3fu) | (codep << 6)) :
              (uint)((0xff >> type) & (data));

            state = utf8d[256 + state * 16 + type];
            return state;
        }
    }
}