class HelloWorld
{
    static void Main() // без перебора
    {
        Console.WriteLine("Введите количество мышей");
        int n = Convert.ToInt32(Console.ReadLine()); // количество мышей
        Console.WriteLine("Введите шаг");
        int k = Convert.ToInt32(Console.ReadLine()); // шаг
        Console.WriteLine("Введите номер белой мыши");
        int m = Convert.ToInt32(Console.ReadLine()); // номер белой мыши

        int[] z = new int[n];
        foreach (int i in z) { z[i] = 0; }
        int v = 0;
        int ans = m;
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                v++;
                if (v > n - 1) { v = 0; }
                if (z[v] == 1) { j--; }
            }
            z[v] = 1;
        }

        for (int i = 0; i < v; i++)
        {
            ans--;
            if (ans < 0) { ans = n - 1; }
        }

        Console.WriteLine(ans);
    }
}
