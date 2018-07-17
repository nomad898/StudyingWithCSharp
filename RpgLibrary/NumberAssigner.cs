using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary
{
    public static class NumberAssigner
    {
        static int nextNumber = 0;

        public static int GetNextNumber()
        {
            nextNumber += 1;
            return nextNumber;
        }
    }
}
