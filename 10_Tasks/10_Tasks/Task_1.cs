using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class Task_1 : TaskBase
    {
        private Dictionary<int, int[]> allValues;

        private int finalValue = 0;

        public Task_1() : base("1")
        {

        }

        public override void CountData()
        {
            allValues = new Dictionary<int, int[]>();

            GetAllValues();
            CountAllValues();
                
            Console.WriteLine(finalValue); // 3809677
        }

        private void GetAllValues()
        {
            string[] valuesStrings = dataFile.Split('\n');

            for (int i = 0; i < valuesStrings.Length; i++)
            {
                if (valuesStrings[i].Length > 2)
                {
                    string[] valuesString = valuesStrings[i].Split('x');
                    int[] valuesInt = valuesString.Select(int.Parse).ToArray();

                    allValues.Add(i, valuesInt);
                }
            }
        }

        private void CountAllValues()
        {

            int[] sortArray;

            foreach (var currentValues in allValues) // Sort arrays
            {
                sortArray = currentValues.Value.OrderBy(num => num).ToArray();

                for (int i = 0; i < currentValues.Value.Length; i++)
                {
                    currentValues.Value[i] = sortArray[i];
                }
            }

            foreach (var currentValues in allValues)
            {
                int countNumbers = 0;

                foreach (var value in currentValues.Value)
                {
                    if (countNumbers < 2)
                    {
                        finalValue += value * 2;
                    }

                    countNumbers++;
                }
            }

            foreach (var currentValues in allValues)
            {
                int number = 0;
                bool firstNumber = true;

                foreach (var value in currentValues.Value)
                {
                    if (firstNumber)
                    {
                        number = value;
                        firstNumber = false;
                    }
                    else
                    {
                        number *= value;
                    }
                }

                finalValue += number;
            }
        }
    }
}