﻿namespace Module_13.TenWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<WordCount> list = new List<WordCount>();
            string file = @"C:\Users\bazhi\Desktop\Обучение C#\13_6_1_Text.txt";

            if (File.Exists(file))
                using (StreamReader sr = File.OpenText(file))
                {
                    string s = sr.ReadToEnd();

                    string noPunct_s = new string(s.Where(c => !char.IsPunctuation(c)).ToArray());

                    char[] delimiters = { ' ', '\r', '\n', '–' };
                    string[] w = noPunct_s.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string word in w)
                    {
                        list.Add(new WordCount(word.ToLower(), 1));
                    }

                    MergeList(ref list);

                    list.Sort(SortByNumDesc);

                    PrintWords(list, 10);
                }
            else
                Console.WriteLine("Файл не найден");
            Console.ReadKey();
        }
        /// <summary>
        /// Слияние списка 
        /// </summary>
        /// <param name="merge_list"></param>
        static void MergeList(ref List<WordCount> merge_list)
        {
            for (int i = 0; i < merge_list.Count; i++)
            {
                for (int k = i + 1; k < merge_list.Count;)
                {
                    if (merge_list.ElementAt(i).word == merge_list.ElementAt(k).word)
                    {
                        merge_list.ElementAt(i).number += merge_list.ElementAt(k).number;
                        merge_list.RemoveAt(k);
                    }
                    else
                        k++;
                }
            }
        }
        /// <summary>
        /// Функция для сравнения по числу в элементе WordCount
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int SortByNum(WordCount x, WordCount y)
        {
            return x.number - y.number;
        }
        /// <summary>
        /// Сортировка от большого к меньшему
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int SortByNumDesc(WordCount x, WordCount y)
        {
            return y.number - x.number;
        }

        /// <summary>
        /// Вывод всех элементов в списке
        /// </summary>
        /// <param name="words"></param>
        static void PrintWords(List<WordCount> words)
        {
            foreach (WordCount word in words)
            {
                Console.WriteLine($"{word.word}  {word.number}");
            }
        }
        /// <summary>
        /// Вывод первых элементов в списке
        /// </summary>
        /// <param name="words"></param>
        /// <param name="number"></param>
        static void PrintWords(List<WordCount> words, int number)
        {
            for (int i = 0; i < Math.Min(words.Count, number); i++)
            {
                Console.WriteLine($"{words.ElementAt(i).word}  {words.ElementAt(i).number}");
            }
        }
    }
}
