using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakuroProject
{
    class Cell
    {
        private int value; // number written into this cell
        private bool[] candidates; // array to store candidate values (possible values based on word sums)
        private Word hWord; // point to horizontal Word this cell is part of
        private Word vWord; // point to vertical Word this cell is part of

        public Cell()
        {
            value = 0; // 0 will represent an empty cell
            candidates = new bool[10]; // first entry 0 will be unused, but length 10 is essential for [] operator use (i.e. [x] represents candidate bool for num x)
            hWord = null; // no need to initialize these since cells are created long before words are generated
            vWord = null;
        }

        public int getValue()
        {
            return value;
        }
        public void setValue(int n)
        {
            value = n;
        }
        public void changeCandidate(int pos, bool b)
        {
            candidates[pos] = b;
        }
        public void setHWord(Word w)
        {
            hWord = w;
        }
        public void setVWord(Word w)
        {
            vWord = w;
        }
    }
}
