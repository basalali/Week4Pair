﻿using System;
using System.IO;


namespace file_io_part1_exercises_pair
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please type in the directory of the file you wish to access.");
            string userInputDirectory = Console.ReadLine();

            Console.WriteLine("Please type in the file name of the file you wish to access.");
            string userInputFileName = Console.ReadLine();

            int sumOfWords = 0;
            int sumOfSentences = 0;

            try
            {

                string fullPath = Path.Combine(userInputDirectory, userInputFileName);
                using (StreamReader sr = new StreamReader(fullPath)) 
                {
                    string allWords = sr.ToString();
                    string [] wordCountString = allWords.Split(" ");
                    //while(!sr.EndOfStream)
                    //{
                    //    sumOfWords++;
                    //}
                    for(int i = 0; i < wordCountString.Length; i++)
                    {
                        sumOfWords++;
                    }

                    char[] delimiterChars = { '.', '!', '?' };
                    string allSentences = sr.ToString();
                    string[] sentenceCountString = allSentences.Split(delimiterChars);
                    //while(!sr.EndOfStream)
                    //{
                    //    sumOfSentences++;
                    //}   
                    for (int i = 0; i < sentenceCountString.Length; i++)
                    {
                        sumOfSentences++;
                    }
                }

            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading the file.");
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("The total number of words used in the file is " + sumOfWords + ".");
            Console.WriteLine("The total number of sentences used in the file is " + sumOfSentences + ".");
            Console.ReadLine();

            //C:\Users\roseb\team4-c-sharp-week4-pair-exercises\16_FileIO_Reading_in\pair-exercise
        }
    }
}
