using System;
using System.Collections.Generic;
namespace ConsoleApplication31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать");
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите пункт меню (число)");
                int menuPoint = Convert.ToInt32(Console.ReadLine());
                switch (menuPoint)
                {
                    case 1: //Создание датабазы
                        DB DB = new DB();
                        break;
                    case 2: //Добавление в базу
                        Creation();
                        break;
                    case 3: //Изменение данных по заданному номеру
                        Console.WriteLine("Выберете какой аудиторию вы хотите изменить");
                        break;
                    case 4: //Выборка аудитории

                        break;
                    case 5: //Выборка аудитории с проектором

                        break;
                    case 6: //Выборка аудитории с компьютером с посадочных мест больше меньше

                        break;
                    case 7: //Выборка аудитории по этажу

                        break;
                    case 8: //Вывод всех данных по аудиториям

                        break;
                    case 9: //Выход

                        break;
                }
            }
        }

        static void Creation()
        {
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());
            bool p = Convert.ToBoolean(Console.ReadLine());
            bool c = Convert.ToBoolean(Console.ReadLine());
            DB.audiences.Add(new Audience(n1, n2, p, c));
        }
    }

    public class Menu 
    {
        static Menu
    }

    public class DB
    {
        public static List<Audience> audiences = new List<Audience>();
    }

    public class Audience
    {
        int audienceNumber;
        int numberOfSeats;
        bool projector;
        bool computer;

        public Audience(int n1, int n2, bool p, bool c)
        {
            audienceNumber = n1;
            numberOfSeats = n2;
            projector = p;
            computer = c;
        }
    }
}