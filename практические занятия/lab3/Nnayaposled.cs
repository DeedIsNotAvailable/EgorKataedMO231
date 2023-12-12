using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Количество элементов в последовательности");
        int n = Convert.ToInt32(Console.ReadLine());
        int BiggerThanThePrevNeighbour = 0;
        int SmallerThanThePrevNeighbours = 0;
        Boolean IsSmallerThanThePrevNeighbours = true;
        int BiggerThanNeghbours = 0;
        int NbufferPlusOne = 0;
        int LongestGrowth = 0;
        int LongestGrowthB1 = 0;
        int Nbuffer = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n-1; i++)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            if(Nbuffer < N) { BiggerThanThePrevNeighbour++; }
            if(Nbuffer >= N) { IsSmallerThanThePrevNeighbours = false; }
            if(IsSmallerThanThePrevNeighbours) { SmallerThanThePrevNeighbours++; }
            if(i>0 & Nbuffer > NbufferPlusOne & Nbuffer > N) { BiggerThanNeghbours++; }

            if(Nbuffer < N) { LongestGrowth++; }
            else
            {
                if(LongestGrowthB1 == 0) { LongestGrowthB1 = LongestGrowth; }
                else
                {
                    if(LongestGrowth > LongestGrowthB1) { LongestGrowthB1 = LongestGrowth; }
                }
                LongestGrowth = 0;
            }

            NbufferPlusOne = Nbuffer;
            Nbuffer = N;
        }

        if(LongestGrowth > LongestGrowthB1) { LongestGrowthB1 = LongestGrowth; }
        if(LongestGrowth != 0 || LongestGrowthB1 != 0) { LongestGrowthB1++; }

        Console.WriteLine("Количество элементов значение которых больше предшествующего соседа " + BiggerThanThePrevNeighbour);
        Console.WriteLine("Количество элементов значение которых меньше всех до него вводимых " + SmallerThanThePrevNeighbours);
        Console.WriteLine("Количество элементов значение которых больше чем у левого и правого соседей " + BiggerThanNeghbours);
        Console.WriteLine("Наибольшая длинна возрастающей последовательности " + LongestGrowthB1);
    }
}