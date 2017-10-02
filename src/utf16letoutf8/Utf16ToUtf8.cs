using System;

namespace utf16letoutf8
{
    using System.Runtime.CompilerServices;
    public static class Utf16Utility
    {
        public static unsafe ArraySegment<byte> GetUtf8Bytes(string source)
        {
            var retbuf = new byte[source.Length * 3];
            fixed (char* srcptr = source)
            {
                unchecked
                {
                    char* endptr = srcptr + source.Length;
                    char* iterptr = srcptr;
                    byte* retptr = (byte*)Unsafe.AsPointer(ref retbuf[0]);
                    byte* beginptr = retptr;
                    while (iterptr < endptr)
                    {
                        UpdateCharUnsafe(ref retptr, ref iterptr, ref endptr);
                    }
                    return new ArraySegment<byte>(retbuf, 0, (int)(retptr - beginptr));
                }
            }
        }
        static unsafe void UpdateCharUnsafe(ref byte* retptr, ref char* iterptr, ref char* endptr)
        {
            if (*iterptr < 0x80)
            {
                // U+7F
                *retptr = (byte)*iterptr;
                retptr++;
                iterptr++;
            }
            else if (*iterptr < 0x800)
            {
                // U+7FF
                // 
                *retptr = (byte)(
                    // 3bit
                    0xc0 
                    // 5bit
                    | ((*iterptr & 0x7c0) >> 6)
                );
                retptr[1] = (byte)(
                    // 2bit
                    0x80 
                    // 6bit
                    | ((*iterptr & 0x3f))
                );
                retptr += 2;
                iterptr++;
            }
            else if ((*iterptr & 0xfc00) == 0xd800)
            {
                if(iterptr + 1 >= endptr || (iterptr[1] & 0xfc00) != 0xdc00)
                {
                    throw new InvalidOperationException("invalid utf-16 sequence(missing surrogate pair)");
                }
                // surrogate pair(U+10FFFF)
                var u = ((0x03c0 & *iterptr) >> 6) + 1;
                *retptr = (byte)(
                    // 5bit
                    0xf0 
                    // 3bit
                    | (u >> 2)
                );
                retptr[1] = (byte)(
                    // 2bit 
                    0x80
                    // 2bit 
                    | ((u & 0x3) << 4)
                    // 4bit
                    | ((*iterptr & 0x3c) >> 2)
                );
                retptr[2] = (byte)(
                    // 2bit
                    0x80
                    // 2bit
                    | ((*iterptr & 0x3) << 4)
                    // 4bit
                    | (((iterptr[1] & 0x3c0) >> 6))
                );
                retptr[3] = (byte)(
                    // 2bit
                    0x80
                    // 6bit
                    | ((iterptr[1] & 0x3f))
                );
                retptr += 4;
                iterptr += 2;
            }
            else
            {
                // U+FFFF
                *retptr = (byte)(
                    // 4bit
                    0xe0
                    // 4bit
                    | ((*iterptr & 0xf000) >> 12)
                );
                retptr[1] = (byte)(
                    // 2bit
                    0x80
                    // 6bit
                    | ((*iterptr & 0xfc0) >> 6)
                );
                retptr[2] = (byte)(
                    // 2bit
                    0x80
                    // 6bit
                    | ((*iterptr & 0x3f))
                );
                retptr += 3;
                iterptr++;
            }
        }
        public static Utf8Enumerator GetEnumerator(char[] ar, int offset, int count)
        {
            return new Utf8Enumerator(ar, offset, count);
        }
        public struct Utf8Enumerator
        {
            char[] charArray;
            int currentIndex;
            int maxCount;
            byte first;
            byte second;
            byte third;
            byte forth;
            sbyte currentCharPosition;
            public Utf8Enumerator(char[] ar, int offset, int count)
            {
                charArray = ar;
                currentIndex = offset - 1;
                maxCount = count;
                first = 0;
                second = 0;
                third = 0;
                forth = 0;
                currentCharPosition = -1;
            }
            public bool TryGetNext(out byte b)
            {
                switch (currentCharPosition)
                {
                    case 0:
                        b = first;
                        break;
                    case 1:
                        b = second;
                        break;
                    case 2:
                        b = third;
                        break;
                    case 3:
                        b = forth;
                        break;
                    default:
                        b = 0;
                        break;
                }
                return false;
            }
            void MoveNextCharPosition()
            {
                if (currentCharPosition < 0)
                {
                    var c = charArray[currentIndex];
                    if ((c & 0xD800) == 0xD800)
                    {
                        // surrogate
                        var c2 = charArray[currentIndex + 1];

                    }
                    else
                    {
                        if (c < 0x80)
                        {
                            first = (byte)c;
                        }
                        else if (c < 0x800)
                        {

                        }
                    }
                }
            }
        }
    }
}
