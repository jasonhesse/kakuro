using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KakuroProject
{
    class Board
    {
        public int maxNum;
        public List<SumCombo>[] cellCombos;

        // store word list here
        // store cell objects?

        // constructor
        public Board()
        {
            maxNum = 9;
            cellCombos = new List<SumCombo>[10];
            initializeSumCombos();
        }
        public Board(int x, int y, int max)
        {
            maxNum = max;
            cellCombos = new List<SumCombo>[max + 1];
            initializeSumCombos();
        }

        public void initializeSumCombos()
        {
            for (int c = 2; c <= 9; c++)
            {
                // calculate number of SumCombos
                int minSum = (c * (c + 1)) / 2;
                int maxSum = (maxNum * c) - ((c * (c - 1)) / 2);
                cellCombos[c] = new List<SumCombo>(maxSum - minSum + 1);

                // for each sum
                for (; minSum <= maxSum; minSum++)
                {
                    // initialize variables
                    int[] combo = calculateCombo(new int[c], 1, maxNum, minSum); // first combination
                    SumCombo sc = new SumCombo(minSum, c);
                    sc.addCombo(new Sum(c, (int[])combo.Clone()));

                    // last element is index (c - 1), but never check last element
                    bool twoIntervalFound = false;
                    for (int changeIndex = c - 2; changeIndex >= 0; changeIndex--)
                    {
                        int difference = combo[changeIndex + 1] - combo[changeIndex];
                        if (difference > 1)
                        {
                            if (difference == 2 && !twoIntervalFound)
                            {
                                twoIntervalFound = true;
                            }
                            else if(difference > 2 || (difference == 2 && twoIntervalFound))
                            {
                                // update combo
                                combo[changeIndex]++;
                                int[] subArray = new int[c - (changeIndex + 1)];
                                Array.Copy(combo, changeIndex + 1, subArray, 0, subArray.Length);

                                // figure out desired sum of subArray
                                int remainingSum = minSum;
                                for(int i = 0; i <= changeIndex; i++)
                                {
                                    remainingSum -= combo[i];
                                }

                                // recalculate subArray and update combo, add to SumCombo
                                subArray = calculateCombo(subArray, combo[changeIndex] + 1, maxNum, remainingSum);
                                Array.Copy(subArray, 0, combo, changeIndex + 1, subArray.Length);
                                sc.addCombo(new Sum(c, (int[])combo.Clone()));

                                // reset changeIndex and bool
                                changeIndex = c - 1; // the -- from the for loop makes it (c - 2)
                                twoIntervalFound = false;
                            }
                        }
                    }

                    // only one '2' interval found in entire combo (for loop finished)
                    cellCombos[c].Add(sc);
                }
            }
        }

        public int[] calculateCombo(int[] combo, int min, int max, int sum)
        {
            int cellCount = combo.Length;
            int remainingSum = sum;

            int maxNum = calculateMaxNum(remainingSum, cellCount, max);
            int minNum = calculateMinNum(remainingSum, cellCount, maxNum, min);

            // fill out minimum Combo
            for(int i = 0; i < cellCount; i++)
            {
                combo[i] = minNum;
                remainingSum -= minNum;
                maxNum = calculateMaxNum(remainingSum, cellCount - (i + 1), max);
                minNum = calculateMinNum(remainingSum, cellCount - (i + 1), maxNum, minNum + 1);
            }

            return combo;
        }

        public int calculateMinNum(int sum, int cellCount, int maxNum, int minValue)
        {
            int differential = (cellCount * (cellCount - 1)) / 2;
            int maxSumWithoutMin = (maxNum * (cellCount - 1)) - (((cellCount - 1) * (cellCount - 2)) / 2);
            int minNum = sum - maxSumWithoutMin;
            if (minNum < minValue)
            {
                minNum = minValue;
            }
            return minNum;
        }
        public int calculateMaxNum(int sum, int cellCount, int maxValue)
        {
            int differential = (cellCount * (cellCount - 1)) / 2;
            int maxNum = sum - differential;
            if (maxNum > maxValue)
            {
                maxNum = maxValue;
            }
            return maxNum;
        }
    }
}
