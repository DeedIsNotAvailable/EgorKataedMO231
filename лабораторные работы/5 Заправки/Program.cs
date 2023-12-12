class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("введите сколько будет дорог");
        int RAmount = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("введите размер запрещенной области вокруг городов");
        int FRegion = Convert.ToInt32(Console.ReadLine());

        int[] Roads = new int[RAmount]; // массив длин дорог
        int RLength = 0;                // количество точек дорог
        Console.WriteLine("вводите длины дорог");
        for (int i = 0; i < Roads.Length; i++)
        {
            Roads[i] = Convert.ToInt32(Console.ReadLine());
            RLength += Roads[i]-1;
        }
        
        int GLength = RLength + RAmount + 1;    // количество точек

        int[] Towns = new int[RAmount + 1];
        Towns[0] = 1;
        for (int i = 0; i < Towns.Length - 1; i++)
        {
            Towns[i+1] = Towns[i] + Roads[i];
        }

        int[] Zones = new int[(RAmount + 1) * 2 * FRegion];
        int z = 0;
        for (int i = 0; i < RAmount + 1; i++)
        {
            
            for (int d = 1; d <= FRegion; d++)
            {
                Zones[z] = Towns[i] + d;
                Zones[z+1] = Towns[i] - d;
                z += 2;
            }
        }

        int Answer = 0;
        int BAnswer = 0;
        int za = 0;
        for (int i = 0; i < GLength; i++)
        {
            if (!Zones.Contains(i) & !Towns.Contains(i))
            {
                for (int d = 0; d < Towns.Length; d++)
                {
                    BAnswer += Math.Abs(Towns[d] - i);
                }
                if (za == 0)
                {
                    Answer = BAnswer;
                    za++;
                }
            }
            if (BAnswer < Answer)
            {
                Answer = BAnswer;
            }
        }
        
        if(Answer == 0) { Console.Write("Не хватает места поставить колонку"); }
        else { Console.Write(Answer); }
    }
}