class Program
{
    public static void Main()
    {
        Menu menu = new Menu();
    }
}

public class Menu
{
    public Menu()
    {
        Console.WriteLine("Добро пожаловать");
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("Выберите пункт меню (число)");
            Console.WriteLine("1 - Выполнить первую программу\n" +
                "2 - Выполнить вторую программу\n" +
                "3 - Об авторе программы\n" +
                "4 - Описание постановки задачи\n" +
                "5 - Выйти");

            int menuPoint = Checker();
            bool menuPointExit = true;
            switch (menuPoint)
            {
                case 1:
                    while (menuPointExit)
                    {
                        actualprg prog = new actualprg();
                        menuPointExit = Confirmation();
                    }
                    break;
                case 2:
                    while (menuPointExit)
                    {
                        actualprgtwo prog = new actualprgtwo();
                        menuPointExit = Confirmation();
                    }
                    break;
                case 3:
                    while (menuPointExit)
                    {
                        punk2();
                        menuPointExit = Confirmation();
                    }
                    break;
                case 4:
                    while (menuPointExit)
                    {
                        punk3();
                        menuPointExit = Confirmation();
                    }
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Выбран не пункт меню");
                    break;
            }
        }
        void punk2() { Console.WriteLine("Создатель: Егор Катаев. Группа: МО-231"); }
        void punk3()
        {
            Console.WriteLine("Первая задача: на вход программы поступает выражение,\n" +
                "состоящее из односимвольных идентификаторов и знаков арифметических\n" +
                "действий. Требуется решить это выражение.\n" +
                "Вторая задача: на вход программы поступает выражение, состоящее из односимвольных\n" +
                "идентификаторов-скобок. Требуется определить каждая ли пара скобок открывается\n" +
                "и закрывается одинаковым типом скобок (например [],(),{}).");
        }
        int Checker()
        {
            int num;
            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out num))
                    break;
                else
                {
                    Console.WriteLine("Ошибка было введено не число");
                    Console.Write("Напишите ваш ответ заново: ");
                }
            }
            return num;
        }
        bool Confirmation()
        {
            bool confirmation = false;
            bool isWrong = true;
            while (isWrong)
            {
                Console.WriteLine("\nХотите выйти в меню?\n" +
                "1 - Да\n" +
                "2 - Нет");
                int menuExit = Checker();
                Console.WriteLine("");
                if (menuExit == 1) { confirmation = false; isWrong = false; }
                else if (menuExit == 2) { confirmation = true; isWrong = false; }
                else { Console.WriteLine("Ответ некорректен"); }
            }
            return confirmation;
        }
    }
}

public class actualprgtwo 
{
    public actualprgtwo()
    {
        Console.WriteLine("Введите выражение из скобок (к примеру []{()})");
        string expression = Console.ReadLine();
        if (CB(expression)) Console.WriteLine("Все скобки в выражении расставлены правильно.");
        else Console.WriteLine("Скобки в выражении расставлены неправильно.");
        
        bool CB(string expression)
        {
            Dictionary<char, char> bra = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
            Stack<char> stack = new Stack<char>();
            foreach (char c in expression)
            {
                if (bra.ContainsValue(c))
                {
                    if (stack.Count == 0 || bra[stack.Peek()] != c)
                    {
                        return false;
                    }
                    stack.Pop();
                }
                else if (bra.ContainsKey(c))
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
    }

}
public class actualprg
{
    public actualprg()
    {
        Console.WriteLine("Введите пример в обратной польской записи (к примеру 2 2 +)");
        string expression = Console.ReadLine();
        int? answer = pol(expression);
        if (answer != null) Console.WriteLine($"Ответ: {answer}");
        else Console.WriteLine("Это пример не является обратной польской записью.");
    }

    static int? pol(string expression)
    {
        Stack<int> stack = new Stack<int>();
        string[] sym = expression.Split(' ');
        foreach (string t in sym)
        {
            if (int.TryParse(t, out int number))
            {
                stack.Push(number);
            }
            else
            {
                if (stack.Count < 2) return null;
                int a = stack.Pop();
                int b = stack.Pop();
                switch (t)
                {
                    case "+":
                        stack.Push(b + a);
                        break;
                    case "-":
                        stack.Push(b - a);
                        break;
                    case "*":
                        stack.Push(b * a);
                        break;
                    case "/":
                        stack.Push(b / a);
                        break;
                    default:
                        Console.WriteLine("Недействительная операция");
                        return null;
                }
            }
        }
        return stack.Pop();
    }
}