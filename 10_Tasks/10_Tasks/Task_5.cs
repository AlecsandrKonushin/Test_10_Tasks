using System.Text.RegularExpressions;

namespace Tasks
{
    public class Task_5 : TaskBase
    {
        private string[] allStrings;

        public Task_5() : base("5")
        {
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');

            CheckStrings();
        }

        private void CheckStrings()
        {
            foreach (var currentString in allStrings)
            {
               // string[] array
            }
        }
    }
}