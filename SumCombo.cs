using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakuroProject
{
    class SumCombo
    {
        // contains all combinations for one particular sum in one particular # of cells (e.g. 5in2 = '1,4', '2,3')
        public int numCombos;
        public int sum;
        public int cells;
        public List<Sum> combos;

        public SumCombo()
        {
            sum = 0;
            cells = 0;
            combos = null;
        }
        public SumCombo(int s, int numCells)
        {
            sum = s;
            cells = numCells;
            combos = new List<Sum>();
        }

        public void addCombo(Sum s)
        {
            combos.Add(s);
            numCombos++;
        }

        // return List<Sum> containing sums with chosen number
        public List<Sum> findSumsWithNum(int n)
        {
            List<Sum> result = new List<Sum>();
            for (int i = 0; i < numCombos; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (combos[i].combo[j] == n)
                    {
                        result.Add(combos[i]);
                    }
                }
            }

            return result;
        }

        // return Sum of ONLY sum with chosen number, returns null if none or more than 1
        public Sum findOnlySumWithNum(int n)
        {
            Sum result = new Sum();
            for (int i = 0; i < numCombos; i++)
            {
                for (int j = 0; j < cells; j++)
                {
                    if (combos[i].combo[j] == n)
                    {
                        if (result.comboLength == 0)
                        {
                            result = combos[i];
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }

            return result;
        }
    }
}
