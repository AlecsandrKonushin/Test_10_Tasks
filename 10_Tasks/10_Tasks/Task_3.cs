using System;
using System.Collections.Generic;

namespace Tasks
{
    public class Task_3 : TaskBase
    {
        private NumberPath[] numbers;
        private string[] stringNumbers;
        private int countNumber = 0;

        private NumberPath currentNumber;
        // 4 4 9 7 6
        public Task_3() : base("3")
        {
        }

        public override void CountData()
        {
            stringNumbers = dataFile.Split('\n');
            Console.WriteLine($"stringNumbers = {stringNumbers.Length}");
            CreateNumbersPath();
            currentNumber = numbers[4];

            CountNumber();
        }

        private void CreateNumbersPath()
        {
            numbers = new NumberPath[9];

            numbers[0] = new NumberPath(1);
            numbers[1] = new NumberPath(2);
            numbers[2] = new NumberPath(3);
            numbers[3] = new NumberPath(4);
            numbers[4] = new NumberPath(5);
            numbers[5] = new NumberPath(6);
            numbers[6] = new NumberPath(7);
            numbers[7] = new NumberPath(8);
            numbers[8] = new NumberPath(9);

            numbers[0].R = numbers[1];
            numbers[0].D = numbers[3];

            numbers[1].R = numbers[2];
            numbers[1].D = numbers[4];
            numbers[1].L = numbers[0];

            numbers[2].D = numbers[5];
            numbers[2].L = numbers[1];

            numbers[3].U = numbers[0];
            numbers[3].R = numbers[4];
            numbers[3].D = numbers[6];

            numbers[4].U = numbers[1];
            numbers[4].R = numbers[5];
            numbers[4].D = numbers[7];
            numbers[4].L = numbers[3];

            numbers[5].U = numbers[2];
            numbers[5].D = numbers[8];
            numbers[5].L = numbers[4];

            numbers[6].U = numbers[3];
            numbers[6].R = numbers[7];

            numbers[7].U = numbers[4];
            numbers[7].R = numbers[8];
            numbers[7].L = numbers[6];

            numbers[8].U = numbers[5];
            numbers[8].L = numbers[7];
        }

        private void CountNumber()
        {
            char[] pathChars = stringNumbers[countNumber].ToCharArray();

            foreach (var path in pathChars)
            {
                if (path == 'U' && currentNumber.U != null)
                {
                    currentNumber = currentNumber.U;
                }
                else if (path == 'R' && currentNumber.R != null)
                {
                    currentNumber = currentNumber.R;
                }
                else if (path == 'D' && currentNumber.D != null)
                {
                    currentNumber = currentNumber.D;
                }
                else if (path == 'L' && currentNumber.L != null)
                {
                    currentNumber = currentNumber.L;
                }
            }

            Console.WriteLine($"currentNumber {currentNumber.Number}");

            if (countNumber + 1 < stringNumbers.Length)
            {
                countNumber++;
                CountNumber();
            }
        }

        private class NumberPath
        {
            public int Number { get; private set; }
            public NumberPath U;
            public NumberPath R;
            public NumberPath D;
            public NumberPath L;

            public NumberPath(int number)
            {
                Number = number;
                U = null;
                R = null;
                D = null;
                L = null;
            }
        }
    }
}