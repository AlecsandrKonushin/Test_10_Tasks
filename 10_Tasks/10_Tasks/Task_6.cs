using System;

namespace Tasks
{
    public class Task_6 : TaskBase
    {
        private string[] allStrings;

        private int number = 0;
        private bool upNumber; // 410        

        public Task_6() : base("6")
        {
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');

            CheckStrings();

            Console.WriteLine($"NUMBER = {number}");
        }

        private void CheckStrings()
        {
            foreach (var currentString in allStrings)
            {
                if(currentString[0] == '-')
                {
                    upNumber = false;
                }
                else
                {
                    upNumber = true;
                }

                int currentNumber = Convert.ToInt32(currentString.Substring(1));

                if (upNumber)
                {
                    number += currentNumber;
                }
                else
                {
                    number -= currentNumber;
                }
            }
        }
    }
}