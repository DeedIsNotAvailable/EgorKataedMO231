public interface IMathOperations
{
    double Sum(double a, double b);
    double Raz(double a, double b);
    double Ymnoj(double a, double b);
    double Delenie(double a, double b);
    double Root(double a);
    double Sin(double a);
    double Cos(double a);
}

class MathOperations : IMathOperations
{
    public double Sum(double a, double b)
    {
        return a + b;
    }

    public double Raz(double a, double b)
    {
        return a - b;
    }

    public double Ymnoj(double a, double b)
    {
        return a * b;
    }

    public double Delenie(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Ошибка. Деление на ноль.");
        }
        return a / b;
    }

    public double Root(double a)
    {
        if (a < 0)
        {
            throw new ArgumentException("Нельзя извлечь корень из отрицательного числа.");
        }
        return Math.Sqrt(a);
    }

    public double Sin(double a)
    {
        return Math.Sin(a);
    }

    public double Cos(double a)
    {
        return Math.Cos(a);
    }
}

class Program
{
    static void Main()
    {
        IMathOperations mathOperations = new MathOperations();

        Console.WriteLine("Выберите математическую операцию:");
        Console.WriteLine("1. Сумма");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");
        Console.WriteLine("5. Квадратный корень");
        Console.WriteLine("6. Синус");
        Console.WriteLine("7. Косинус");

        int choice = Convert.ToInt32(Console.ReadLine());

        try
        {
            if (choice >= 1 && choice <= 4)
            {
                Console.WriteLine("Введите два числа:");
                double num1 = Convert.ToDouble(Console.ReadLine());
                double num2 = Convert.ToDouble(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Результат: {mathOperations.Sum(num1, num2)}");
                        break;
                    case 2:
                        Console.WriteLine($"Результат: {mathOperations.Raz(num1, num2)}");
                        break;
                    case 3:
                        Console.WriteLine($"Результат: {mathOperations.Ymnoj(num1, num2)}");
                        break;
                    case 4:
                        Console.WriteLine($"Результат: {mathOperations.Delenie(num1, num2)}");
                        break;
                }
            }
            else if (choice >= 5 && choice <= 7)
            {
                Console.WriteLine("Введите число:");
                double num = Convert.ToDouble(Console.ReadLine());

                switch (choice)
                {
                    case 5:
                        Console.WriteLine($"Результат: {mathOperations.Root(num)}");
                        break;
                    case 6:
                        Console.WriteLine($"Результат: {mathOperations.Sin(num)}");
                        break;
                    case 7:
                        Console.WriteLine($"Результат: {mathOperations.Cos(num)}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Неизвестный номер операции.");
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Недопустимый символ.");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}