using System;

namespace utf16letoutf8
{
    public static class Utf16Utility
    {
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
            byte fifth;
            byte sixth;
            int currentCharPosition;
            public Utf8Enumerator(char[] ar, int offset, int count)
            {
                charArray = ar;
                currentIndex = offset - 1;
                maxCount = count;
                first = 0;
                second = 0;
                third = 0;
                forth = 0;
                fifth = 0;
                sixth = 0;
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
                    case 4:
                        b = fifth;
                        break;
                    case 5:
                        b = sixth;
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
                        var c2 = charArray[currentIndex+1];

                    }else{
                        if(c < 0x80)
                        {
                            first = (byte)c;
                        }else if(c < 0x800){
                            
                        }
                    }
                }
            }
        }
    }
}
