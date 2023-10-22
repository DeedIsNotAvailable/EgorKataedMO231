class HelloWorld
{
    static void Main() // без перебора
    {
        int n = Convert.ToInt32(Console.ReadLine()); // количество мышей
        int k = Convert.ToInt32(Console.ReadLine()); // шаг
        int m = Convert.ToInt32(Console.ReadLine()); // номер белой мыши

        int[] z = new int[n];
        foreach (int i in z) { z[i] = 0; }
        int v = 0;
        int ans = m;

        /*
        надо найти номер белой мыши если мы начнем есть с самой первой мыши
        надо найти разность номера белой мыши и первой мыши, это значение будет являться дельтой
        надо вычесть дельту из m, это результат, то есть номер мыши с которой надо начать есть остальных
        */

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                v++;
                if (v > n - 1) { v = 0; }
                if (z[v] == 1) { j--; }
            }
            z[v] = 1;
            /*foreach (int g in z) { Console.Write($"{g} "); }
            Console.WriteLine(" ");*/
        }

        for (int i = 0; i < v; i++)
        {
            ans--;
            if (ans < 0) { ans = n - 1; }
        }

        Console.WriteLine(ans);
    }
}