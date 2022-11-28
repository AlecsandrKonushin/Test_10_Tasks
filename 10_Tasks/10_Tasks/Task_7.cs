using System;
using System.Collections.Generic;

namespace Tasks
{
    public class Task_7 : TaskBase
    {
        private string[] allStrings;

        private List<Security> securitys;
        private Security currentSecurity;

        private int startSleep;

        public Task_7() : base("7")
        {
            securitys = new List<Security>();
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');
            Array.Sort(allStrings);

            GetMinutesSecurity();
            GetCountSleepMinutes();            
        }

        private void GetCountSleepMinutes()
        {
            foreach (var security in securitys)
            {
                int sleepMintes = 0;
                int maxSleep = 0;

                foreach (var minute in security.Minutes)
                {
                    sleepMintes += minute.Count;

                    if (minute.Count > maxSleep)
                    {
                        maxSleep = minute.Count;
                    }
                }

                security.AllSleepMinutes = sleepMintes;
                security.MaxSleep = maxSleep;
            }

            Security sleepScurity = securitys[0];

            foreach (var security in securitys)
            {
                if(security.AllSleepMinutes > sleepScurity.AllSleepMinutes)
                {
                    sleepScurity = security;
                }
            }

            Minute maxSleepMinute = sleepScurity.Minutes[0];

            foreach (var minute in sleepScurity.Minutes)
            {
                if(minute.Count > maxSleepMinute.Count)
                {
                    maxSleepMinute = minute;
                }
            }

            foreach (var security in securitys)
            {
                Console.WriteLine($"security = {security.Id} {security.AllSleepMinutes} {security.MaxSleep}");
            }

            Console.WriteLine();
            Console.WriteLine($"sleepScurity = {sleepScurity.Id} maxSleepMinute = {maxSleepMinute.Id}");
        }

        private void GetMinutesSecurity()
        {
            foreach (var str in allStrings)
            {
                if (str.Contains("#"))
                {
                    string name = str.Substring(str.IndexOf("#"));
                    name = name.Substring(0, name.IndexOf(" "));

                    currentSecurity = GetSecurity(name);
                }

                if (str.Contains(":"))
                {

                    int indexMinute = str.IndexOf(":");
                    int minute = Convert.ToInt32(str.Substring(indexMinute + 1, 2));

                    if (str.Contains("falls asleep"))
                    {
                        startSleep = minute;
                    }
                    else if (str.Contains("wakes up"))
                    {
                        for (int i = startSleep; i < minute; i++)
                        {
                            if(startSleep > minute)
                            {
                                Console.WriteLine("<color=red>startSleep > minute!</color>");
                            }
                            else
                            {
                                AddMinute(i);
                            }
                        }
                    }
                }                
            }
        }

        private Security GetSecurity(string id)
        {
            foreach (var checkSecurity in securitys)
            {
                if (checkSecurity.Id == id)
                {
                    return checkSecurity;
                }
            }

            Security security = new Security();
            security.Id = id;
            security.Minutes = new List<Minute>();

            securitys.Add(security);

            return security;
        }

        private void AddMinute(int id)
        {
            foreach (var minute in currentSecurity.Minutes)
            {
                if(minute.Id == id)
                {
                    minute.Count++;
                    return;
                }
            }

            Minute newMinute = new Minute();
            newMinute.Id = id;
            newMinute.Count = 1;
            currentSecurity.Minutes.Add(newMinute);
        }
    }

    public class Security
    {
        public string Id;
        public List<Minute> Minutes;
        public int AllSleepMinutes;
        public int MaxSleep;
    }

    public class Minute
    {
        public int Id;
        public int Count;
    }

    // 1657 - 100
}