using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KakuroProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            // Main Program goes here
            Board b = new Board();

            // TESTING: output all sum combinations
            for(int c = 2; c <= 9; c++)
            {
                for(int s = 0; s < b.cellCombos[c].Count; s++)
                {
                    if (b.cellCombos[c][s].sum < 10)
                    {
                        Console.Write(" ");
                    }
                    Console.Write(b.cellCombos[c][s].sum + "in" + c + ":");
                    for(int n = 0; n < b.cellCombos[c][s].numCombos; n++)
                    {
                        Console.Write(" ");
                        for(int i = 0; i < c; i++)
                        {
                            Console.Write(b.cellCombos[c][s].combos[n].combo[i]);
                        }
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
        }
    }
}

/* program outline:
    - classes: Board, Word, Cell
    - Board functions: generateEmptyBoard, generateUniqueSolution, emptyCells, resetBoard
        - emptyCells would be to clear values in preparation for user interaction
        - resetBoard however would be to completely reset all cells and words, including the layout
    - board steps: matrix of cells based on size, initialize word lists
    - size of board and difficulty needs to be selectable by user
    - difficulties:
        - easy: generate Nikoli-style puzzle by massing single-candidate intersections
        - medium: utilize both generation methods (switch between them every word? every few words?)
        - difficult: algorithm detailed on puzzling.stackexchange.com
*/