using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakuroProject
{
    class Word
    {
        private int sum;
        private Cell[] cells;
        private bool isVertical;

        public Word()
        {
            sum = 0;
            cells = null;
            isVertical = false;
        }
        public Word(int numCells, bool orientation)
        {
            sum = 0; // 0 will represent that this word has yet to be assigned a sum
            cells = new Cell[numCells]; // initialize cells array based on how many cells will be assigned
            isVertical = orientation; // initialize word orientation (horizontal or vertical)
        }

        public int getSum()
        {
            return sum;
        }
        public void setSum(int s)
        {
            sum = s;
        }
        public Cell getCell(int pos)
        {
            return cells[pos];
        }
        public void addCell(int pos, Cell c)
        {
            cells[pos] = c;
        }
        public bool getOrient()
        {
            return isVertical;
        }
        public void setOrient(bool vert)
        {
            isVertical = vert;
        }
    }
}
