class Program
{
    static void Main(string[] args)
    { 
        Console.WriteLine("Сколько будет строк в ступенчатом массиве?");
        int rows = Convert.ToInt32(Console.ReadLine());
        int[][] uArr = new int[rows][];
        int[] rowPow = new int[rows];
        for (int i = 1; i <= rows; i++) { Console.WriteLine($"Сколько будет элементов в {i} множестве");
            rowPow[i-1] = Convert.ToInt32(Console.ReadLine());}
        for (int i = 0; i  < rows; i++) { Console.WriteLine($"Вводите элементы в {i+1} множество");
            uArr[i] = new int[rowPow[i]];
            for (int j = 0; j < rowPow[i]; j++) { uArr[i][j] = Convert.ToInt32(Console.ReadLine()); }}
        Console.WriteLine("Элементы которые входят в пересечение всех множеств:");
        for (int i = 0; i < uArr[^1].Length; i++)
        {
            bool checker = true;
            for (int j = 0; j < rows - 1; j++) { if (!uArr[j].Contains(uArr[^1][i])) { checker = false; } }
            if (checker == true) { Console.Write($"{uArr[^1][i]} "); }
        }
        Console.WriteLine("\nЭлементы которые входят в объединение всех множеств:");
        for (int i = 0; i < rows; i++) {
            for (int j = 0;j < uArr[i].Length; j++) {
                bool checker = true;
                for (int k = i + 1; k < rows; k++)
                {
                    if (uArr[k].Contains(uArr[i][j])) { checker = false; }
                }
                if (checker == true) { Console.Write($"{uArr[i][j]} "); }
            }
        }
        Console.WriteLine("\nДополнение к каждому множеству относительно объединения:");
        for (int i = 0; i < rows; i++) {
            Console.WriteLine($"\nДополнение к каждому множеству {i} относительно объединения:");
            for (int j = 0; j < rows; j++)
            {
                if(j != i)
                {
                    for (int k = 0; k < uArr[j].Length; k++)
                    {
                        if (!uArr[i].Contains(uArr[j][k])) { Console.Write($"{uArr[j][k]} "); }
                    }
                }
            }
        }
    }
}