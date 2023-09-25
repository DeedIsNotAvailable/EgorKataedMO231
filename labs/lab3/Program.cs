using System;
class HelloWorld
{
    static void Main()
    {
        int max = 0;
        int neg = 0;
        int summ = 0;
        int smallest = 0;

        for (int i = 0; i < 10; i++)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            if (i == 0) { max = N; }
            if (N > max) { max = N; }
            if (N < 0) { neg++; }
            if (N % 3 == 0) { summ += N; }
            if (N > 0 & smallest == 0) { smallest = N; }
            if (N > 0 & N < smallest) { smallest = N; }
        }

        Console.WriteLine("Наибольший элемент " + max);
        Console.WriteLine("Количество негативных " + neg);
        Console.WriteLine("Сумма положительных кратных трем " + summ);
        Console.WriteLine("Минимальный среди положительных " + smallest);
    }
}