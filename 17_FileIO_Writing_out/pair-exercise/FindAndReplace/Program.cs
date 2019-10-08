using System;
using System.IO;
namespace FindAndReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What word would you like to find?");
            string searchWord = Console.ReadLine();

            Console.WriteLine("What word would you like to replace it with?");
            string replacementWord = Console.ReadLine();

            string currentFilePath = "";
            while (!File.Exists(currentFilePath))
            {
                Console.WriteLine("Please enter a valid source file path.");
                currentFilePath = Console.ReadLine();
            }

            string destinationFilePath = "";
            while (!File.Exists(destinationFilePath))
            {
                try
                {
                    Console.WriteLine("Please enter a valid destination file path.");                 
                    destinationFilePath = Console.ReadLine();
                    File.CreateText(destinationFilePath);

                }

                catch (IOException e)
                {
                    Console.WriteLine("Error! There's already a file by that name in that location.");
                    Console.WriteLine(e.Message);
                    Console.ReadLine();


                }

                try
                {
                    using (StreamReader sr = new StreamReader(currentFilePath))
                    {

                        using (StreamWriter sw = new StreamWriter(destinationFilePath, true))
                        {
                            while (!sr.EndOfStream)
                            {
                                string line = sr.ReadLine();
                                string fixedLine = line.Replace(searchWord, replacementWord);
                                sw.WriteLine(fixedLine);
                            }
                        }
                    }
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);

                }
                Console.ReadLine();
            }
        }
    }
}
