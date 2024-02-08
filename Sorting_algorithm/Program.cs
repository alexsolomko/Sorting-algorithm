using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Sorting_Algorithm
{
    /// <summary>
    /// This class contains methods for sorting algorithms and a program entry point to demonstrate sorting.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        private static void Main()
        {
            List<int> numbers = GetNumbers();

            Console.WriteLine("\nChoose a sorting algorithm:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Insertion Sort");
            Console.WriteLine("3. Selection Sort");

            int algorithmChoice;
            while (!int.TryParse(Console.ReadLine(), out algorithmChoice) || algorithmChoice < 1 || algorithmChoice > 3)
            {
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 3.");
            }

            Console.WriteLine("\nChoose the output format:");
            Console.WriteLine("1. Ascending Order");
            Console.WriteLine("2. Descending Order");
            Console.WriteLine("3. Zigzag Order");

            int outputChoice;
            while (!int.TryParse(Console.ReadLine(), out outputChoice) || outputChoice < 1 || outputChoice > 3)
            {
                Console.WriteLine("Invalid choice. Please choose a number between 1 and 3.");
            }

            SortNumbers(numbers, algorithmChoice);
            DisplaySortedNumbers(numbers, outputChoice);
        }

        /// <summary>
        /// Prompts the user to enter numbers and returns them as a list.
        /// </summary>
        /// <returns>The list of numbers entered by the user.</returns>
        private static List<int> GetNumbers()
        {
            Console.WriteLine("Do you want to generate random numbers (1) or enter your own numbers (2)?");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.WriteLine("Invalid choice. Please choose 1 or 2.");
            }

            List<int> numbers = new List<int>();

            if (choice == 1)
            {
                Console.WriteLine("Enter the number of random numbers to generate:");
                int count;
                while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }

                Random random = new Random();
                for (int i = 0; i < count; i++)
                {
                    numbers.Add(random.Next(1, 100));
                }
            }
            else if (choice == 2)
            {
                Console.WriteLine("Enter numbers separated by spaces:");
                string input = Console.ReadLine();
                string[] inputs = input.Split(' ');
                foreach (string num in inputs)
                {
                    if (int.TryParse(num, out int parsedNum))
                    {
                        numbers.Add(parsedNum);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid input: {num}. Skipping...");
                    }
                }
            }

            return numbers;
        }

        /// <summary>
        /// Sorts the given list of numbers using the specified algorithm.
        /// </summary>
        /// <param name="numbers">The list of numbers to be sorted.</param>
        /// <param name="algorithmChoice">The choice of sorting algorithm.</param>
        private static void SortNumbers(List<int> numbers, int algorithmChoice)
        {
            switch (algorithmChoice)
            {
                case 1:
                    BenchmarkSortTime(BubbleSort, numbers.ToArray());
                    break;
                case 2:
                    BenchmarkSortTime(InsertionSort, numbers.ToArray());
                    break;
                case 3:
                    BenchmarkSortTime(SelectionSort, numbers.ToArray());
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        /// <summary>
        /// Displays the sorted numbers based on the output choice.
        /// </summary>
        /// <param name="numbers">The list of numbers to be displayed.</param>
        /// <param name="outputChoice">The choice of output format.</param>
        private static void DisplaySortedNumbers(List<int> numbers, int outputChoice)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine("No numbers to display.");
                return;
            }

            List<int> sortedNumbers = new List<int>(numbers);

            switch (outputChoice)
            {
                case 1:
                    sortedNumbers.Sort();
                    break;
                case 2:
                    sortedNumbers.Sort((a, b) => b.CompareTo(a));
                    break;
                case 3:
                    sortedNumbers.Sort();
                    List<int> zigzagNumbers = new List<int>();
                    int left = 0, right = sortedNumbers.Count - 1;
                    bool leftTurn = true;

                    while (left <= right)
                    {
                        zigzagNumbers.Add(leftTurn ? sortedNumbers[right--] : sortedNumbers[left++]);
                        leftTurn = !leftTurn;
                    }

                    sortedNumbers = zigzagNumbers;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            Console.WriteLine("\nSorted Numbers:");
            Console.WriteLine(string.Join(" ", sortedNumbers));
        }

        /// <summary>
        /// Benchmarks the sorting time for the specified sort method and array.
        /// </summary>
        /// <param name="sortMethod">The sorting method to be benchmarked.</param>
        /// <param name="array">The array to be sorted.</param>
        private static void BenchmarkSortTime(Action<int[]> sortMethod, int[] array)
        {
            Console.WriteLine("\nBenchmarking Sort Time...");
            BenchmarkSort(sortMethod, array);
        }

        /// <summary>
        /// Benchmarks the sorting time for the specified sort method and array.
        /// </summary>
        /// <param name="sortMethod">The sorting method to be benchmarked.</param>
        /// <param name="array">The array to be sorted.</param>
        private static void BenchmarkSort(Action<int[]> sortMethod, int[] array)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            sortMethod(array);

            stopwatch.Stop();

            double milliseconds = stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine($"Sorting Time: {stopwatch.Elapsed} ({milliseconds} milliseconds)\n");
        }

        // Sorting Algorithms (Bubble Sort, Insertion Sort, Selection Sort)

        // Bubble Sort
        private static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        // Insertion Sort
        private static void InsertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = key;
            }
        }

        // Selection Sort
        private static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
                }
            }
        }
    }
}
