using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tasks
{
    public class Task_5 : TaskBase
    {
        private string[] allStrings;

        private int countMatch = 0; // 246

        public Task_5() : base("5")
        {
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');

            GenerateArrays();
        }

        private void GenerateArrays()
        {
            foreach (var currentString in allStrings)
            {
                string str = currentString;
                List<string> arrayAba = new List<string>();
                List<string> arrayBab = new List<string>();

                int counter = 0;

                while (counter < 20)
                {
                    counter++;

                    if (str.Contains("["))
                    {
                        int numberStart = str.IndexOf("[");
                        int numberEnd = str.IndexOf("]");

                        if (numberStart < numberEnd)
                        {
                            arrayAba.Add(str.Substring(0, numberStart));
                            str = str.Substring(numberStart + 1);
                        }
                        else
                        {
                            arrayBab.Add(str.Substring(0, numberEnd));
                            str = str.Substring(numberEnd + 1);
                        }
                    }
                    else if (str.Contains("]"))
                    {
                        int numberEnd = str.IndexOf("]");

                        arrayBab.Add(str.Substring(0, numberEnd));
                        str = str.Substring(numberEnd + 1);
                    }
                    else
                    {
                        if (str.Length > 0)
                        {
                            arrayAba.Add(str);
                            break;
                        }
                    }
                }

                bool match = false;
                foreach (var aba in arrayAba)
                {
                    foreach (var bab in arrayBab)
                    {
                        if (CheckStrings(aba, bab))
                        {
                            match = true;
                            break;
                        }
                    }
                }

                if (match)
                {
                    countMatch++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"countMatch = {countMatch}");
        }

        private bool CheckStrings(string one, string two)
        {
            for (int i = 1; i < one.Length - 1; i++)
            {
                for (int j = 1; j < two.Length - 1; j++)
                {
                    if ((one[i] == two[j + 1] && one[i] == two[j - 1]) && (one[i + 1] == two[j] && one[i - 1] == two[j]))
                    {
                        Console.WriteLine($"TRUE = {one[i - 1]}{one[i]}{one[i + 1]}  {two[j - 1]}{two[j]}{two[j + 1]}");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}