using System;

public class ArrayProcessor
{
    private int[] arr;

    public ArrayProcessor(int size)
    {
        arr = new int[size];
    }

    public void Input()
    {
        Console.WriteLine("Nhap cac phan tu cua mang:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Phan tu {0}: ", i);
            arr[i] = int.Parse(Console.ReadLine());
        }
    }

    public void Display()
    {
        Console.WriteLine("Mang hien tai: " + string.Join(" ", arr));
    }

    public void BubbleSort()
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    public void QuickSort(int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(left, right);
            QuickSort(left, pivotIndex - 1);
            QuickSort(pivotIndex + 1, right);
        }
    }

    private int Partition(int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] <= pivot)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        int temp1 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp1;

        return i + 1;
    }

    public int LinearSearch(int key)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == key)
                return i;
        }
        return -1;
    }

    public int BinarySearch(int key)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (arr[mid] == key)
                return mid;
            if (arr[mid] < key)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Nhap kich thuoc mang: ");
        int size = int.Parse(Console.ReadLine());

        ArrayProcessor processor = new ArrayProcessor(size);

        processor.Input();

        Console.WriteLine("\nMang ban dau:");
        processor.Display();

        processor.BubbleSort();
        Console.WriteLine("\nMang sau khi sap xep bang Bubble Sort:");
        processor.Display();

        Console.WriteLine("\nNhap lai mang de thuc hien Quick Sort:");
        processor.Input();
        processor.QuickSort(0, size - 1);
        Console.WriteLine("\nMang sau khi sap xep bang Quick Sort:");
        processor.Display();

        Console.Write("\nNhap so can tim: ");
        int key = int.Parse(Console.ReadLine());

        int linearResult = processor.LinearSearch(key);
        if (linearResult != -1)
            Console.WriteLine("Tim thay {0} tai vi tri {1} bang Linear Search", key, linearResult);
        else
            Console.WriteLine("Khong tim thay {0} bang Linear Search", key);

        int binaryResult = processor.BinarySearch(key);
        if (binaryResult != -1)
            Console.WriteLine("Tim thay {0} tai vi tri {1} bang Binary Search", key, binaryResult);
        else
            Console.WriteLine("Khong tim thay {0} bang Binary Search", key);
    }
}