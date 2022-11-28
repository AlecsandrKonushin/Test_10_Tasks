using System;

namespace Tasks
{
    public class Task_4 : TaskBase
    {
        private string[] allStrings;
        private int countAvailable = 0;

        // 122

        public Task_4() : base("4")
        {
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');

            CheckStrings();

            Console.WriteLine("available " + countAvailable);
        }

        private void CheckStrings()
        {
            for (int i = 0; i < allStrings.Length; i++)
            {
                string[] currentWords = allStrings[i].Split(' ');

                if (!CheckRepeatWords(currentWords))
                {
                    countAvailable++;
                }
            }
        }

        private bool CheckRepeatWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                char[] chekWord = words[i].ToCharArray();

                for (int c = 0; c < words.Length; c++)
                {
                    if (i != c && words[i].Length == words[c].Length)
                    {
                        bool repeat = true;

                        foreach (var checkChar in chekWord)
                        {
                            if (!words[c].Contains(checkChar.ToString()))
                            {
                                repeat = false;
                                break;
                            }
                        }

                        if (repeat)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}