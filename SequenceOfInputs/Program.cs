
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceOfInputs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int what = 0;
            Console.WriteLine("select a number:");
            Console.WriteLine("1 -- to enter a sequence of input directly");
            Console.WriteLine("2 -- to read a file and print its content");
            try
            {
                what=int.Parse(Console.ReadLine());
                if (what == 1)
                {
                    Console.WriteLine("how many input you want to give??");
                    int n = int.Parse(Console.ReadLine());
                    string[] inputs = new string[n];
                    int i = 0;
                    while (i < n)
                    {
                        Console.WriteLine($"input {i+1}:");
                        inputs[i] = Console.ReadLine();
                        i++;
                    }
                    Console.WriteLine("Your inputs:");
                    for (int j = 0; j < inputs.Length; j++)
                    {
                        Console.WriteLine($"{j+1} - " + inputs[j]);
                    }
                }else if(what == 2)
                {
                    Console.WriteLine("enter the file full path and name from your pc,Note:file should have .txt extension");
                    string file= Console.ReadLine();
                    if(file.Substring(file.LastIndexOf('.') + 1,3) !="txt")
                    {
                        Console.WriteLine("enter a .txt file");
                        Console.ReadLine();
                    }
                    else
                    {
                        string dataFile = ReadFileFromPc(file);

                        Console.WriteLine();
                        Console.WriteLine(dataFile);
                    }
                    
                }
                Console.ReadLine();

            }
            catch (FormatException ex)
            {
                Console.WriteLine("enter data correctly");
                Console.WriteLine("message " +ex.Message);
                Console.ReadLine();
            }   
        }
        public static string ReadFileFromPc(string filePath)
        {
            StreamReader r = new StreamReader(filePath);
            string content = r.ReadToEnd();
            return content;
        }
    }
}
