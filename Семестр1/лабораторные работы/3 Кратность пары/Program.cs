class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Введите количество пар");
        int n = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < n; i++) 
        {
            Console.WriteLine("Введите первого члена пары");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите второго члена пары");
            int b = Convert.ToInt32(Console.ReadLine());
            if(a>=b & a % 3 == 0) { Console.WriteLine(a); }
            if(a>=b & a % 3 != 0 & b % 3 == 0) { Console.WriteLine(b); }
            if(b>a & b % 3 == 0) { Console.WriteLine(b); }
            if(b>a & b % 3 != 0 & a % 3 == 0) { Console.WriteLine(a); }

        }
    }
}