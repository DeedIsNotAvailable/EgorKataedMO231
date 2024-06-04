class HelloWorld
{
    static void Main()
    {
        List<int> List = new List<int> { 4, 123, 46, 789, 1305, 246, 79, 154, 11111, 25, 77, 157779354 };

        var LastNum = List.Where(n => (n % 10) % 3 == 0);
        var AnyNum = List.Where(n => n.ToString().Any(c => c % 2 == 0));

        Console.WriteLine("Элементы, у которых последняя цифра кратна 3:");
        foreach (var num in LastNum)
        {
            Console.WriteLine(num);
        }

        Console.WriteLine("\nЭлементы, у которых в записи присутствует хотя бы одна четная цифра:");
        foreach (var num in AnyNum)
        {
            Console.WriteLine(num);
        }
    }
}