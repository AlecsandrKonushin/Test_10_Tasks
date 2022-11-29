using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tasks
{
    public class Task_8 : TaskBase
    {
        private string[] allStrings;

        private List<Pixel> pixels;

        private int width = 50, height = -6;

        // Not work 87, 108

        public Task_8() : base("8")
        {
        }

        public override void CountData()
        {
            allStrings = dataFile.Split('\n');

            CreatePixels();
            ReadStrings();

            int countIsOn = 0;
            foreach (var pixel in pixels)
            {
                if (pixel.IsOn)
                {
                    countIsOn++;
                }
            }
            Console.WriteLine(countIsOn);
        }

        private void CreatePixels()
        {
            pixels = new List<Pixel>();

            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h > height; h--)
                {
                    pixels.Add(new Pixel(w, h));
                }
            }
        }

        private void ReadStrings()
        {
            foreach (var str in allStrings)
            {
                if (str.Contains("rect"))
                {
                    string containHeight = str.Substring(str.IndexOf(" ") + 1);
                    int w = Convert.ToInt32(containHeight.Substring(0, containHeight.IndexOf("x")));

                    int h = -Convert.ToInt32(str.Substring(str.IndexOf("x") + 1));

                    //Console.WriteLine($"RECR w = {w} h = {h}");

                    Rect(w, h);
                }
                else if (str.Contains("rotate row"))
                {
                    string containNumber = str.Substring(str.IndexOf("=") + 1);
                    int numberRow = -Convert.ToInt32(containNumber.Substring(0, containNumber.IndexOf(" ")));

                    string containStep = Regex.Replace(containNumber, @" ", "");
                    int stepsX = Convert.ToInt32(containStep.Substring(containStep.IndexOf("y") + 1));
                    
                    RotateRow(numberRow, stepsX);
                }
                else if (str.Contains("rotate column"))
                {
                    string containNumber = str.Substring(str.IndexOf("=") + 1);
                    int numberColumn = Convert.ToInt32(containNumber.Substring(0, containNumber.IndexOf(" ")));

                    string containStep = Regex.Replace(containNumber, @" ", "");
                    int stepsY = Convert.ToInt32(containStep.Substring(containStep.IndexOf("y") + 1));

                    RotateColumn(numberColumn, stepsY);
                }

                Console.WriteLine();
            }
        }

        private void Rect(int w, int h)
        {
            Console.WriteLine($"RECT  w = {w} h = {h}");
            int countOn = 0;
            foreach (var pixel in pixels)
            {
                if (pixel.PosX < w && pixel.PosY > h)
                {
                    pixel.IsOn = true;
                    countOn++;
                }
            }

            ViewData();
        }

        private void RotateRow(int row, int steps)
        {
            Console.WriteLine($"RotateRow  row = {row} steps = {steps}");
            List<Pixel> isOnPixels = new List<Pixel>();

            for (int i = 0; i < pixels.Count; i++)
            {
                if (pixels[i].PosY == row && pixels[i].IsOn)
                {
                    pixels[i].IsOn = false;

                    int posX = pixels[i].PosX + steps;
                    if (posX > width - 1)
                    {
                        int upValue = posX - width;
                        posX = 0 + upValue;
                    }

                    isOnPixels.Add(GetPixel(posX, pixels[i].PosY));

                }
            }

            foreach (var pixel in isOnPixels)
            {
                pixel.IsOn = true;
            }

            ViewData();
        }

        private void RotateColumn(int column, int steps)
        {
            Console.WriteLine($"RotateColumn  column = {column} steps = {steps}");
            List<Pixel> isOnPixels = new List<Pixel>();

            for (int i = 0; i < pixels.Count; i++)
            {
                if (pixels[i].PosX == column && pixels[i].IsOn)
                {
                    pixels[i].IsOn = false;

                    int posY = pixels[i].PosY - steps;
                    if (posY < height + 1)
                    {
                        int upValue = Math.Abs(posY) - Math.Abs(height);
                        posY = -upValue;

                        if (posY < height + 1)
                        {
                            upValue = Math.Abs(posY) - Math.Abs(height);
                            posY = -upValue;
                        }
                        }

                    Pixel pixel = GetPixel(pixels[i].PosX, posY);
                    if (pixel == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"ERROR posX = {pixels[i].PosX} posY = {posY}");
                        Console.WriteLine();
                    }

                    isOnPixels.Add(pixel);
                }
            }

            foreach (var pixel in isOnPixels)
            {
                pixel.IsOn = true;
            }

            ViewData();
        }

        private void ViewData()
        {
            for (int h = 0; h > height; h--)
            {
                for (int w = 0; w < width; w++)
                {
                    foreach (var pixel in pixels)
                    {
                        if (pixel.PosX == w && pixel.PosY == h)
                        {
                            if (pixel.IsOn)
                            {
                                Console.Write("#");
                            }
                            else
                            {
                                Console.Write(".");
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private Pixel GetPixel(int posX, int posY)
        {
            foreach (var pixel in pixels)
            {
                if (pixel.PosX == posX && pixel.PosY == posY)
                {
                    return pixel;
                }
            }

            return null;
        }
    }

    public class Pixel
    {
        public bool IsOn;
        public int PosX;
        public int PosY;

        public Pixel(int posX, int posY)
        {
            IsOn = false;
            PosX = posX;
            PosY = posY;
        }
    }
}