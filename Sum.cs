using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakuroProject
{
    class Sum
    {
        // contains one combinations for one particular sum in one particular # of cells (e.g. for 5in2 this Sum = '2,3')
        public int comboLength;
        public int[] combo;

        public Sum()
        {
            comboLength = 0;
            combo = null;
        }
        public Sum(int l, int[] c)
        {
            comboLength = l;
            combo = c;
        }
    }
}
