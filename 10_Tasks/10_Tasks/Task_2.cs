using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks
{
    public class Task_2 : TaskBase
    {
        private int width = 999, height = 999;

        private List<Bulb> bulbs;
        private List<BuldAction> actions;
        private int countOnBulb = 0;

        /// <summary>
        /// 
        /// 543903         
        /// 
        /// </summary>

        public Task_2() : base("2")
        {
            bulbs = new List<Bulb>();
            actions = new List<BuldAction>();

            for (int w = 0; w <= width; w++)
            {
                for (int h = 0; h <= height; h++)
                {
                    bulbs.Add(new Bulb(w, h));
                }
            }
        }

        public override void CountData()
        {
            GetData();
            ChangeBuld();

            foreach (var bulb in bulbs)
            {
                if (bulb.IsOn)
                {
                    countOnBulb++;
                }
            }
        }

        private void GetData()
        {
            string[] valuesStrings = dataFile.Split('\n');

            for (int i = 0; i < valuesStrings.Length; i++)
            {
                if (valuesStrings[i].Length > 2)
                {
                    string[] valuesString = valuesStrings[i].Split(' ');

                    if (valuesString.Length != 4)
                    {
                        Console.WriteLine($"Error length - {valuesString.Length}. Number string = {i}");
                        return;
                    }
                    else
                    {
                        BuldAction action = new BuldAction();

                        if (valuesString[0] == "toggle")
                        {
                            action.TypeAction = TypeAction.Toggle;
                        }
                        else if (valuesString[0] == "off")
                        {
                            action.TypeAction = TypeAction.Off;
                        }
                        else if (valuesString[0] == "on")
                        {
                            action.TypeAction = TypeAction.On;
                        }

                        int[] startNumbers = valuesString[1].Split(',').Select(int.Parse).ToArray();

                        action.StartX = startNumbers[0];
                        action.StartY = startNumbers[1];

                        int[] endNumbers = valuesString[3].Split(',').Select(int.Parse).ToArray();

                        action.EndX = endNumbers[0];
                        action.EndY = endNumbers[1];

                        actions.Add(action);
                    }
                }
            }
        }

        private void ChangeBuld()
        {
            foreach (var action in actions)
            {
                foreach (var bulb in bulbs)
                {
                    if(bulb.PosX >= action.StartX && bulb.PosX <=action.EndX &&
                        bulb.PosY >= action.StartY && bulb.PosY <= action.EndY)
                    {
                        if(action.TypeAction == TypeAction.Toggle)
                        {
                            bulb.IsOn = !bulb.IsOn;
                        }
                        else if (action.TypeAction == TypeAction.On)
                        {
                            bulb.IsOn = true;
                        }
                        else if (action.TypeAction == TypeAction.Off)
                        {
                            bulb.IsOn = false;
                        }
                    }
                }
            }
        }

        private class Bulb
        {
            public int PosX { get; private set; }
            public int PosY { get; private set; }

            public bool IsOn { get; set; }

            public Bulb(int posX, int posY)
            {
                PosX = posX;
                PosY = posY;

                IsOn = false;
            }
        }

        private enum TypeAction
        {
            On,
            Off,
            Toggle
        }

        private struct BuldAction
        {
            public TypeAction TypeAction;
            public int StartX, EndX, StartY, EndY;
        }
    }
}