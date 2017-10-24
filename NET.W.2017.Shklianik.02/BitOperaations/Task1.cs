using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOperations
{
    public static class Task1
    {
        public static int InsertNumber(int numberSource, int numberIn, byte j, byte i)
        {
            const int size = 32;
            int count = j - i + 1;
            uint mask = (uint) ((~0) << size - count) >> size - count << i;
            numberIn = (int) ((numberIn << i) & (mask));
            mask = (uint)(~0 ^ mask);
            numberSource = numberSource << 32 - i;
            return (int)(numberSource & mask) | numberIn;
        }
    }
}
