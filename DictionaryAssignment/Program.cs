﻿using DictioanryAssignmentLibraries;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] rawWords = System.IO.File.ReadAllLines("dictionary.txt");
            Dictionary<int, List<string>> wordsByLength = new Dictionary<int, List<string>>();

            foreach (string word in rawWords)
            {
                if (!wordsByLength.ContainsKey(word.Length))
                {
                    List<string> init = new List<string>();
                    init.Add(word);
                    wordsByLength.Add(word.Length, init);
                } else {
                    // wordsByLength[word.Length].Append(word);
                    wordsByLength[word.Length].Add(word);
                }
            }
            
            foreach (KeyValuePair<int, List<string>> wordsList in wordsByLength)
            {
                // Console.WriteLine("---------");
                // Console.WriteLine($"Array of Words with Length = {wordsList.Key}:");
                // wordsList.Value.ForEach(word => Console.Write("{0},", word));
                System.IO.File.WriteAllLines($"wordsList_Length-{wordsList.Key}.txt", wordsList.Value);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("The file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        
        // int row = 0;

        // do
        // {
        //     if (row == 0 || row >= 25)
        //         ResetConsole();

        //     string? input1 = Console.ReadLine();
        //     string? input2 = Console.ReadLine();
        //     string? input3 = Console.ReadLine();
        //     if (string.IsNullOrEmpty(input1)) break;
        //     if (string.IsNullOrEmpty(input2)) break;
        //     if (string.IsNullOrEmpty(input3)) break;
        //     Console.WriteLine($"Target Length: {input1}");
        //     Console.WriteLine($"First Word: {input2}");
        //     Console.WriteLine($"Second Word: {input3}");

        //     int targetLength = Convert.ToInt32(input1);

        //     Console.WriteLine("Is valid compound word? " +
        //          $"{(CompoundWordLibrary.IsValidCompoundWord(input2, input3, targetLength) ? "Yes" : "No")}");
        //     Console.WriteLine();
        //     row += 4;
        // } while (true);
        // return;

        // // Declare a ResetConsole local method
        // void ResetConsole()
        // {
        //     if (row > 0)
        //     {
        //         Console.WriteLine("Press any key to continue...");
        //         Console.ReadKey();
        //     }
        //     Console.Clear();
        //     Console.WriteLine($"{Environment.NewLine}Press <Enter> only to exit; otherwise, enter a string and press <Enter>:{Environment.NewLine}");
        //     row = 3;
        // }
    }
}