using System;
using System.Collections.Generic;
using System.Text;

namespace ResisiorTutorial
{
    internal class ResistorValues
    {
        private static Random r = new Random();
        private static readonly List<long> resistorValuesList = new List<long>
        {
            1500,
            1200,
            560,
            1000,
            910,
            820,
            390
        };

        public static long[] GetList() => resistorValuesList.ToArray();
        public static long GetRandom() => resistorValuesList[r.Next(0, resistorValuesList.Count)];
    }
}
