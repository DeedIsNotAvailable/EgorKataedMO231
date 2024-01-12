using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество участков трассы");
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите время прохождения каждого");
        int t = int.Parse(Console.ReadLine());
        Console.WriteLine("введите время прохождений участков на a и b используя пробел");
        int[] mass_a = new int[N];
        int[] mass_b = new int[N];
        int l = 0; int l1 = 0;
        for (int i = 0; i < N; i++)
        {
            string[] S = Console.ReadLine().Split();
            int a = int.Parse(S[0]);
            int b = int.Parse(S[1]);
            mass_a[i] = a + l;
            mass_b[i] = b + l1;
            l = mass_a[i];
            l1 = mass_b[i];
        }
        int ans = t + mass_b[mass_b.Length - 1];
        for (int i = 0; i < mass_b.Length; i++)
        {
            if (mass_a[i] + t + (mass_b[N - 1] - mass_b[i]) < ans)
            {
                ans = mass_a[i] + t + (mass_b[N - 1] - mass_b[i]);
            }
        }
        Console.WriteLine("Наименьшее потраченное время: " + ans);
    }
}