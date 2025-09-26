using System;
class Program
{
    static void Main()
    {
        int m, n, i, j;
        Console.Write("dong: "); m = int.Parse(Console.ReadLine());
        Console.Write("cot: "); n = int.Parse(Console.ReadLine());

        int[,] A = new int[m, n], B = new int[m, n];

        Console.WriteLine("matrix A:");
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                Console.Write($"A[{i},{j}]= ");
                A[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("matrix B:");
        for (i = 0; i < m; i++)
        {
            for (j = 0; j < n; j++)
            {
                Console.Write($"B[{i},{j}]= ");
                B[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine(" A:");
        for (i = 0; i < m; i++) { for (j = 0; j < n; j++) Console.Write(A[i, j] + " "); Console.WriteLine(); }

        Console.WriteLine("B:");
        for (i = 0; i < m; i++) { for (j = 0; j < n; j++) Console.Write(B[i, j] + " "); Console.WriteLine(); }

        Console.WriteLine("A + B:");
        for (i = 0; i < m; i++) { for (j = 0; j < n; j++) Console.Write((A[i, j] + B[i, j]) + " "); Console.WriteLine(); }

        if (A.GetLength(1) == B.GetLength(0))
        {
            Console.WriteLine("A * B:");
            for (i = 0; i < m; i++)
            {
                for (j = 0; j < B.GetLength(1); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < n; k++) sum += A[i, k] * B[k, j];
                    Console.Write(sum + " ");
                }
                Console.WriteLine();
            }
        }
        else Console.WriteLine(" false A * B");

        Console.WriteLine("A^T:");
        for (i = 0; i < n; i++) { for (j = 0; j < m; j++) Console.Write(A[j, i] + " "); Console.WriteLine(); }

        int min = A[0, 0], max = A[0, 0];
        foreach (int x in A) { if (x < min) min = x; if (x > max) max = x; }
        Console.WriteLine("Min=" + min + " Max=" + max);

        if (m == 2 && n == 2)
        {
            int det = A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
            Console.WriteLine("Dinhthuc A=" + det);
        }

        if (m == n)
        {
            bool dx = true;
            for (i = 0; i < m; i++)
                for (j = 0; j < n; j++)
                    if (A[i, j] != A[j, i]) dx = false;
            Console.WriteLine(dx ? "A doi xung" : "A khong doi xung");
        }
    }
}