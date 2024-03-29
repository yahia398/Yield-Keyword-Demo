﻿using System;
using System.Collections.Generic;

namespace YieldDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the start point.\n");
            Console.WriteLine("Entered List of numbers is as the following: 1, 10, 2, 20, 3, 30, 4, 40, 5, 50\n");
            IEnumerable<int> numbers = new List<int>() {
                1, 10,
                2, 20,
                3, 30,
                4, 40,
                5, 50
            };
            
            // The execution will be deffered till we iterate over the takenNumbers
            var takenNumbers = numbers.WhereDemo(x => x > 10).TakeDemo(2);

            foreach (var number in takenNumbers)
            {
                Console.WriteLine($"The result has {number}\n");
            }
        }
    }

    public static class ExtensionsDemo
    {
        public static void Print(this int number)
        {
            Console.WriteLine($"The current number '{number}' is greater than 10\n");
        }

        public static IEnumerable<int> TakeDemo(this IEnumerable<int> source, int count)
        {
            int counter = 0;
            foreach (int item in source)
            {
                // If you reach the limit you want, terminate the process
                if (counter >= count)
                {
                    Console.WriteLine("The process has been terminated.\n");
                    yield break;
                }
                Console.WriteLine($"The taken number is {item}\n");
                yield return item;
                counter++;
            }
        }

        public static IEnumerable<int> WhereDemo(this IEnumerable<int> numbers, Func<int, bool> predicate)
        {
            foreach (int number in numbers)
            {
                if (predicate(number))
                {
                    yield return number;
                }
                else
                {
                    Console.WriteLine($"This number '{number}' is lower than or equal 10\n");
                }
            }
        }
    }
}