using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Task10
{
    class Program
    {
        static void Main()
        {
            String path = File.ReadAllText(@"C:\Temp\Misc\Data.txt");
            int[,] arr = TwoDArray(path);
            int[,] newArray = GetAnswer(arr);
            int answer = 0;
            for (int i = 1; i < newArray.GetLength(1); i++)
            {
                if (newArray [newArray.GetLength(0) - 1, i]  > answer)
                {
                    answer = newArray[newArray.GetLength(0) - 1, i];
                }
            }
            Console.WriteLine(answer);
        }

        private static int[,] TwoDArray(string path)
        {
            int i = 0;
            int[,] arr = new int[15, 15];
            foreach (var row in path.Split('\n'))
            {
                int j = 0;
                if (i < 15)
                {
                    foreach (var col in row.Trim().Split(' '))
                    {
                        if (j < 15)
                        {
                            arr[i, j] = int.Parse(col.Trim());
                            j++;
                        }
                    }
                }
                i++;
            }
            return arr;
        }
        private static int[,] GetAnswer(int[,] arr)
        {
            int[,] newArray = new int[arr.GetLength(0),arr.GetLength(1)];
            newArray[0, 0] = arr[0, 0];
            for (int i = 1; i < 15; i++)
            {
                for (int x = 0; x <= i; x++)
                {
                    int number = arr[i, x];
                    if (x == 0)
                    {
                        number += newArray[i - 1, x];
                    }
                    else if (x == i)
                    {
                        number += newArray[i - 1, x - 1];
                    }
                    else
                    {
                        int comp = newArray[i - 1, x];
                        int comparison = newArray[i - 1, x - 1];
                        if (comp > comparison)
                        {
                            number += newArray[i - 1, x];
                        }
                        else
                        {
                            number += newArray[i - 1, x - 1];
                        }
                    }
                    newArray[i, x] = number;
                }
            }
            return newArray;
        }
    }
}