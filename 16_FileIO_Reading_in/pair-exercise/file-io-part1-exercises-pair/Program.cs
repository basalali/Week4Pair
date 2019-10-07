using System;
using System.IO;
using System.Collections.Generic;


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

            string fullPath = Path.Combine(userInputDirectory, userInputFileName);
            try
            {
             
                
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string allText = sr.ReadLine();
                        string[] wordCountString = allText.Split(" ");

                        for (int i = 0; i < wordCountString.Length; i++)
                        {
                            sumOfWords = sumOfWords + 1;
                        }
      
                        foreach(string word in wordCountString)
                        {
                            if (word.Contains("."))
                            {
                                sumOfSentences = sumOfSentences + 1;

                            }
                            else if (word.Contains("!"))
                            {
                                sumOfSentences = sumOfSentences + 1;

                            }
                            else if (word.Contains("?"))
                            {
                                sumOfSentences = sumOfSentences + 1;

                            }

                        }
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

            //C:\Users\basala\team4-c-sharp-week4-pair-exercises\16_FileIO_Reading_in\pair-exercise
        }
    }
}
