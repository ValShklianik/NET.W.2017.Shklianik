using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitFiltrations
{
    public class Task4
    {
        public List<int> FilterDigit(List<int> list, int digit)
        {
            List<int> outResult= new List<int>();
            foreach(int number in list)
            {
                string num = number.ToString();
                if (num.Contains(digit.ToString()))
                {
                    outResult.Add(number);
                }
                
            }

            return outResult;
        }
    }
}
