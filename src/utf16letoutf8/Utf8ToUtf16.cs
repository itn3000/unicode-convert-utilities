namespace utf16letoutf8
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.CompilerServices;
    public static class Utf8ToUtf16
    {
        public unsafe static string ToUtf16String(byte[] data, int offset, int count)
        {
            var dataptr = (byte*)Unsafe.AsPointer(ref data[offset]);
            var endptr = dataptr + count;
            if (count < 128)
            {
                var buf = stackalloc char[count];
                char* iterptr = buf;
                while (UpdateCharUnsafe(ref dataptr, ref endptr, ref iterptr)) ;
                return new string(buf, 0, (int)(iterptr - buf));
            }
            else
            {
                var buf = new char[count];
                char* iterptr = (char*)Unsafe.AsPointer(ref buf[0]);
                while (UpdateCharUnsafe(ref dataptr, ref endptr, ref iterptr)) ;
                return new string(buf, 0, (int)(iterptr - (char*)Unsafe.AsPointer(ref buf[0])));
            }
        }
        public static CharEnumerable ToUtf16(byte[] data, int offset)
        {
            return new CharEnumerable(data, offset);
        }
        internal const byte SecondFlag = 1;
        internal const byte SurrogateFlag = 2;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static unsafe bool UpdateCharUnsafe(ref byte* data, ref byte* endptr, ref char* outbuf)
        {
            if (data >= endptr)
            {
                return false;
            }
            else if (*data < 0x80)
            {
                *outbuf = (char)*data;
                outbuf++;
                data++;
                return true;
            }
            else if ((*data & 0xf0) == 0xf0)
            {
                if (data + 4 > endptr)
                {
                    return false;
                }
                if (((*data & 0x07) | (*(data + 1) & 0x30)) == 0)
                {
                    throw new InvalidOperationException("invalid utf-8 byte sequence(not shortest)");
                }
                var w = ((((((*data) & 0x7) << 2)
                    | ((*(data + 1) & 0x30) >> 4))
                    - 1) & 0x0f) << 6;
                outbuf[0] = (char)(
                    // 6bit
                    (char)0xd800
                    // 4bit
                    | (char)w
                    // 4bit
                    | (((char)*(data + 1) & 0x0f) << 2)
                    // 2bit
                    | (((char)*(data + 2) & 0x30) >> 4)
                );
                outbuf[1] = (char)(
                    // 6bit
                    (char)0xdc00 |
                    // 4bit
                    (((char)*(data + 2) & 0xf) << 6) |
                    // 6bit
                    ((char)*(data + 3) & 0x3f)
                );
                data += 4;
                outbuf += 2;
            }
            else if ((*data & 0xe0) == 0xe0)
            {
                if (data + 3 > endptr)
                {
                    return false;
                }
                if (((*data & 0xf) | (*(data + 1) & 0x20)) == 0)
                {
                    throw new InvalidOperationException("invalid byte sequence(not shortest)");
                }
                // U+FFFF
                // 4 + 6 + 6 = 16
                outbuf[0] = (char)((char)(*data & 0x0f) << 12
                    | (char)(*(data + 1) & 0x3f) << 6
                    | (char)(*(data + 2) & 0x3f));
                data += 3;
                outbuf++;
            }
            else if ((*data & 0xc0) == 0xc0)
            {
                if (data + 2 > endptr)
                {
                    return false;
                }
                // U+07FF
                if ((*data & 0x1e) == 0)
                {
                    throw new InvalidOperationException("invalid utf-8 byte sequence(not shortest)");
                }
                outbuf[0] = (char)((((char)*data & 0x1f) << 6) | (((char)*(data + 1)) & 0x3f));
                data += 2;
                outbuf++;
            }
            else
            {
                throw new InvalidOperationException("unknown byte data");
            }
            return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool UpdateChar(byte[] Utf8Data, ref char First, ref char Second, ref int CurrentIndex, out bool isSurrogate)
        {
            isSurrogate = false;
            if (CurrentIndex >= Utf8Data.Length)
            {
                return false;
            }
            else if (Utf8Data[CurrentIndex] < 0x80)
            {
                // U+07F
                First = (char)Utf8Data[CurrentIndex];
                CurrentIndex++;
            }
            else if ((Utf8Data[CurrentIndex] & 0xf0) == 0xf0)
            {
                if (CurrentIndex + 4 > Utf8Data.Length)
                {
                    return false;
                }
                if (((Utf8Data[CurrentIndex] & 0x07) | (Utf8Data[CurrentIndex + 1] & 0x30)) == 0)
                {
                    throw new InvalidOperationException("invalid utf-8 byte sequence(not shortest)");
                }
                isSurrogate = true;
                var w = ((((((Utf8Data[CurrentIndex]) & 0x7) << 2)
                    | ((Utf8Data[CurrentIndex + 1] & 0x30) >> 4))
                    - 1) & 0x0f) << 6;
                First = (char)(
                    // 6bit
                    (char)0xd800
                    // 4bit
                    | (char)w
                    // 4bit
                    | (((char)Utf8Data[CurrentIndex + 1] & 0x0f) << 2)
                    // 2bit
                    | (((char)Utf8Data[CurrentIndex + 2] & 0x30) >> 4)
                );
                Second = (char)(
                    // 6bit
                    (char)0xdc00 |
                    // 4bit
                    (((char)Utf8Data[CurrentIndex + 2] & 0xf) << 6) |
                    // 6bit
                    ((char)Utf8Data[CurrentIndex + 3] & 0x3f)
                );
                CurrentIndex += 4;
            }
            else if ((Utf8Data[CurrentIndex] & 0xe0) == 0xe0)
            {
                if (CurrentIndex + 3 > Utf8Data.Length)
                {
                    return false;
                }
                if (((Utf8Data[CurrentIndex] & 0xf) | (Utf8Data[CurrentIndex] & 0x20)) == 0)
                {
                    throw new InvalidOperationException("invalid byte sequence(not shortest)");
                }
                // U+FFFF
                // 4 + 6 + 6 = 16
                First = (char)((char)(Utf8Data[CurrentIndex] & 0x0f) << 12
                    | (char)(Utf8Data[CurrentIndex + 1] & 0x3f) << 6
                    | (char)(Utf8Data[CurrentIndex + 2] & 0x3f));
                CurrentIndex += 3;
            }
            else if ((Utf8Data[CurrentIndex] & 0xc0) == 0xc0)
            {
                if (CurrentIndex + 2 > Utf8Data.Length)
                {
                    return false;
                }
                // U+07FF
                if ((Utf8Data[CurrentIndex] & 0x1e) == 0)
                {
                    throw new InvalidOperationException("invalid utf-8 byte sequence(not shortest)");
                }
                First = (char)((((char)Utf8Data[CurrentIndex] & 0x1f) << 6) | (((char)Utf8Data[CurrentIndex + 1]) & 0x3f));
                CurrentIndex += 2;
            }
            else
            {
                throw new InvalidOperationException("unknown byte data");
            }
            return true;
        }
        public struct CharEnumerable : IEnumerable<char>
        {
            readonly byte[] Utf8Data;
            readonly int Offset;
            public override string ToString()
            {
                var sb = new StringBuilder(Utf8Data.Length);
                var enumrator = new CharEnumerator(Utf8Data, Offset);
                while (enumrator.MoveNext())
                {
                    sb.Append(enumrator.Current);
                }
                return sb.ToString();
            }
            public CharEnumerable(byte[] utf8Data, int offset)
            {
                Utf8Data = utf8Data;
                Offset = offset;
            }
            public struct CharEnumerator : IEnumerator<char>
            {
                readonly byte[] Utf8Data;
                char First;
                char Second;
                int CurrentIndex;
                byte CurrentStatus;
                public CharEnumerator(byte[] data, int offset)
                {
                    Utf8Data = data;
                    CurrentIndex = offset;
                    CurrentStatus = 0;
                    First = default(char);
                    Second = default(char);
                }
                bool IsBOM()
                {
                    return CurrentIndex + 3 < Utf8Data.Length
                        && ((Utf8Data[0] << 16) | (Utf8Data[1] << 8) | (Utf8Data[2])) == 0xefbbbf;
                }
                public char Current => (CurrentStatus & SecondFlag) == 0 ? First : Second;

                object IEnumerator.Current => (CurrentStatus & SecondFlag) != 0 ? First : Second;

                public void Dispose()
                {
                }
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                bool SetCharAndMoveNext()
                {
                    var ret = UpdateChar(Utf8Data, ref First, ref Second, ref CurrentIndex, out var isSurrogate);
                    if (isSurrogate)
                    {
                        CurrentStatus = SecondFlag;
                    }
                    return ret;
                }

                public bool MoveNext()
                {
                    if ((CurrentStatus & SurrogateFlag) != 0 && (CurrentStatus & SecondFlag) == 0)
                    {
                        CurrentStatus |= SecondFlag;
                        return true;
                    }
                    return SetCharAndMoveNext();
                }

                public void Reset()
                {
                    throw new System.NotImplementedException();
                }
            }
            public CharEnumerator GetEnumerator()
            {
                return new CharEnumerator(Utf8Data, Offset);
            }
            IEnumerator<char> IEnumerable<char>.GetEnumerator()
            {
                return new CharEnumerator(Utf8Data, Offset);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new CharEnumerator(Utf8Data, Offset);
            }
        }
    }
}