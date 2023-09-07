using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question3
{
    internal class Program
    {
        static void Main(string[] args)
        {
                try
                {
                    // get length for array
                    Console.WriteLine("enter an integer length of a 2 dimentional array:");
                    int n = int.Parse(Console.ReadLine());
                    int[][] arr = CreateArrayOnIndexIncrease(n);

                    // get value to search it
                    Console.WriteLine("enter an integer value to search it in the array");
                    int value = int.Parse(Console.ReadLine());


                    bool result = Contains(value, arr);
                    Console.WriteLine(result == true ? "value exist in the array" : "value dosent exist");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("enter an integer value!!!!");
                    Console.WriteLine(ex.Message);

                }
            

            Console.ReadLine();
        }

        // findvalue iterate on n number of array and on n length of each array 
        // complexity is O(n*n)
        public static bool Contains(int value, int[][] arr)
        {
            for(int i = 0;i<arr.Length;i++)
            {
                for(int j=0;j<arr.Length;j++)
                {
                    if (arr[i][j] == value) return true;
                }
            }
            return false;
        }
        
        // here also complexity is O(n*n)
        public static int[][] CreateArrayOnIndexIncrease(int n)
        {
            int[][] grid = new int[n][];
            int value = 0;

            for (int i = 0; i< n; i++)
            {
                grid[i] = new int[n];
                for (int j= 0; j< n; j++)
                {
                    grid[i][j] = value;
                    value++;
                }
            }

            return grid;
        }
        
    }
}
