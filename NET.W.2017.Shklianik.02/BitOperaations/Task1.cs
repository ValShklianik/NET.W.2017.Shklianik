using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitOperations
{
    public class Task1
    {
        public int InsertNumber(int numberSource, int numberIn, byte j, byte i)
        {
            //i++;
            //j++;
            int count = j - i + 1;
            uint mask = (uint) ((~0) << 32 - count) >> 32 - count << i;
            numberIn = (int) ((numberIn << i) & (mask));
            mask = (uint)(~0 ^ mask);
            numberSource = numberSource << 32 - i;
            return (int)(numberSource & mask) | numberIn;
            //return (int)mask;
        }
    }
}
