﻿using System.Diagnostics;

namespace Module_13.LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            LinkedList<string> list = new LinkedList<string>();

            stopWatch.Start();

            string file = @"C:\Users\bazhi\Desktop\Обучение C#\13_6_1_Text.txt";

            if (File.Exists(file))
            {
                using (StreamReader sr = File.OpenText(file))
                {
                    string s = sr.ReadToEnd();
                    char[] delimiters = { ' ', '\r', '\n' };
                    string[] w = s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in w)
                        list.AddFirst(word);

                }
            }

            stopWatch.Stop();
            Console.WriteLine($"Прошло {stopWatch.Elapsed.Milliseconds} миллисек.");

            Console.ReadKey();
        }
    }
}
