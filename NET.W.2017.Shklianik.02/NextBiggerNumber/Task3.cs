using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Globalization;


namespace NextBiggerNumber
{
    public class Task3 : Task2
    {
        private TimeSpan timeStopWatch;
        private TimeSpan timeDate;

        public TimeSpan Time { get => timeStopWatch; }
        public TimeSpan Time2 { get => timeDate; }

        public new long FindNextBiggerNumber(long number)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            DateTime startTime = DateTime.Now; 

            long nextNum = base.FindNextBiggerNumber(number);
            stopWatch.Stop();
            DateTime endTime = DateTime.Now;


            timeDate = endTime - startTime;
            timeStopWatch = stopWatch.Elapsed;


            return nextNum;
        }

    }
}
