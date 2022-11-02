using System;
using System.Collections.Generic;

namespace PITest
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            try
            {
                string cabinetSize = Console.ReadLine();
                string[] parameters = cabinetSize.Split(' ');

                string noOfLines = Console.ReadLine();
                List<Int64> lines = new List<Int64>();
                string line;
                while (!String.IsNullOrWhiteSpace(line = Console.ReadLine()))
                {
                    lines.Add(Convert.ToInt64((line)));
                }

                //check if all the values are within range
                if (Int64.Parse(noOfLines) < 1 || Int64.Parse(noOfLines) >= 4294967296) //0 < K < 2^32
                {
                    Console.WriteLine("INPUT_ERROR");
                    return;
                }
                if (parameters.Length < 1 || parameters.Length >= 64) //0 < N < 2^6
                {
                    Console.WriteLine("INPUT_ERROR");
                    return;
                }
                for (int i = 0; i < parameters.Length; i++)
                {
                    if (Int64.Parse(parameters[i]) < 1 || Int64.Parse(parameters[i]) >= 1024) //0 < cabinet size < 2^10
                    {
                        Console.WriteLine("INPUT_ERROR");
                        return;
                    }
                }
                for (int i = 0; i < lines.Count; i++)
                {
                    if (lines[i] < 1 || lines[i] >= 4294967296)//0 < numerical key < 2^32
                    {
                        Console.WriteLine("INPUT_ERROR");
                        return;
                    }
                }

                List<Int64> tempLines = new List<Int64>(lines);
                Dictionary<Int64, int> dict = new Dictionary<Int64, int>();
                for (int i = 0; i < parameters.Length; i++)
                {
                    for (int j = 0; j < Convert.ToInt32(parameters[i]); j++)
                    {
                        if (tempLines.Count > 1)
                        {
                            int k = tempLines.Count - 2;

                            if (!dict.ContainsKey(Convert.ToInt64(tempLines[k])))
                            {
                                dict.Add(tempLines[k], i + 1);
                                tempLines.RemoveAt(k);
                            }
                            else
                            {
                                tempLines.RemoveAt(k);
                                j--;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (tempLines.Count > 0)
                {
                    int tempLinesCount = tempLines.Count;
                    Int64 lastValue = tempLines[tempLinesCount - 1];
                    tempLines.RemoveAt(tempLinesCount - 1);
                    if (dict.ContainsKey(lastValue))
                    {
                        dict.TryGetValue(lastValue, out int result);
                        Console.WriteLine(result);
                    }
                    else if (tempLines.Contains(lastValue))
                    {
                        Console.WriteLine("OUTSIDE");
                    }
                    else
                    {
                        Console.WriteLine("NEW");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("INPUT_ERROR");
            }
        }
    }
}
