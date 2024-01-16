using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int size = 10000;
        const int upperBound = 1000;

        int[] ascendingArray = GenerateAscendingArray(size);
        int[] randomArray = GenerateRandomArray(size, upperBound);
        int[] descendingArray = GenerateDescendingArray(size);

        Console.WriteLine("------------------------------------------");
        Console.WriteLine("-----Bubble Sort Benchmark----- \n");

        Console.WriteLine("Ascending Array:");
        BenchmarkSort(BubbleSort, ascendingArray);

        Console.WriteLine("Random Array:");
        BenchmarkSort(BubbleSort, randomArray);

        Console.WriteLine("Descending Array:");
        BenchmarkSort(BubbleSort, descendingArray);

        Console.WriteLine("------------------------------------------");

        Console.WriteLine("-----Selection Sort Benchmark----- \n");

        Console.WriteLine("Ascending Array:");
        BenchmarkSort(SelectionSort, ascendingArray);

        Console.WriteLine("Random Array:");
        BenchmarkSort(SelectionSort, randomArray);

        Console.WriteLine("Descending Array:");
        BenchmarkSort(SelectionSort, descendingArray);

        Console.WriteLine("------------------------------------------");

        Console.WriteLine("-----Insertion Sort Benchmark----- \n");

        Console.WriteLine("Ascending Array:");
        BenchmarkSort(InsertionSort, ascendingArray);

        Console.WriteLine("Random Array:");
        BenchmarkSort(InsertionSort, randomArray);

        Console.WriteLine("Descending Array:");
        BenchmarkSort(InsertionSort, descendingArray);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    Swap(arr, j, j + 1);
                    swapped = true;
                }
            }

            if (!swapped)
                break;
        }
    }

    static void SelectionSort(int[] arr)
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

            Swap(arr, i, minIndex);
        }
    }

    static void InsertionSort(int[] arr)
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

    static void BenchmarkSort(Action<int[]> sortMethod, int[] array)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        sortMethod.Invoke(array);

        stopwatch.Stop();

        double milliseconds = stopwatch.Elapsed.TotalMilliseconds;
        Console.WriteLine($"Sorting Time: {stopwatch.Elapsed} ({milliseconds} milliseconds)\n");
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static int[] GenerateAscendingArray(int size)
    {
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = i;
        }
        return array;
    }

    static int[] GenerateRandomArray(int _size, int _upperBound)
    {
        Random random = new Random();
        int[] array = new int[_size];

        for (int i = 0; i < _size; i++)
        {
            array[i] = random.Next(1, _upperBound);
        }

        return array;
    }

    static int[] GenerateDescendingArray(int size)
    {
        int[] array = new int[size];

        for (int i = 0; i < size; i++)
        {
            array[i] = size - i;
        }
        return array;
    }
}
