using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ConsoleApplication31
{
    class Program
    {
        static void Main(string[] args)
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
                Console.WriteLine("1 - Создание датабазы\n" +
                    "2 - Добавление аудитории в датабазу\n" +
                    "3 - Изменение данных об аудитории\n" +
                    "4 - Выборка аудиторий по количеству мест\n" +
                    "5 - Выборка аудиторий по наличию проектора\n" +
                    "6 - Выборка аудиторий по количиству мест и наличию компьютера\n" +
                    "7 - Выборка аудиторий по этажу\n" +
                    "8 - Вывод всех данных по аудиториям\n" +
                    "9 - Закончить работу программы");
                int menuPoint = Checker();
                bool menuPointExit = true;
                switch (menuPoint)
                {
                    case 1: //Создание датабазы
                        while (menuPointExit)
                        {
                            DB DB = new DB();
                            Console.WriteLine("Датабаза создана");
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 2: //Добавление в базу
                        while (menuPointExit)
                        {
                            Creation();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 3: //Изменение данных по заданному номеру
                        while (menuPointExit)
                        {
                            Change();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 4: //Выборка аудитории
                        while (menuPointExit)
                        {
                            SampleNumberOfSeats();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 5: //Выборка аудитории с проектором
                        while (menuPointExit)
                        {
                            SampleProjector();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 6: //Выборка аудитории с компьютером с посадочных мест больше меньше
                        while (menuPointExit)
                        {
                            SampleNumberOfSeatsWithPC();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 7: //Выборка аудитории по этажу
                        while (menuPointExit)
                        {
                            Floor();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 8: //Вывод всех данных по аудиториям
                        while (menuPointExit)
                        {
                            Print();
                            menuPointExit = Confirmation();
                        }
                        break;
                    case 9: //Выход
                        exit = true;
                        break;
                }
            }
        }

        void Creation()
        {
            Console.WriteLine("Какой у аудитории будет номер?");
            int n1 = Checker();
            Console.WriteLine("Сколько будет мест у аудитории?");
            int n2 = Checker();
            Console.WriteLine("Будет ли у аудитории проектор?");
            bool p = true;
            bool isWrong = true;
            while (isWrong)
            {
                Console.WriteLine("1 - Да\n" +
                "2 - Нет");
                int ans = Checker();
                if (ans == 1) { p = true;
                    isWrong = false;
                }
                else if (ans == 2) { p = false;
                    isWrong = false;
                }
                else { Console.WriteLine("Ответ некорректен"); }
            }
            Console.WriteLine("Будут ли в аудитории компьютеры?");
            bool c = true;
            isWrong = true;
            while (isWrong)
            {
                Console.WriteLine("1 - Да\n" +
                "2 - Нет");
                int ans = Checker();
                if (ans == 1)
                {
                    c = true;
                    isWrong = false;
                }
                else if (ans == 2)
                {
                    c = false;
                    isWrong = false;
                }
                else { Console.WriteLine("Ответ некорректен"); }
            }
            DB.audiences.Add(new Audience(n1, n2, p, c));
            Console.WriteLine("Новая аудитория создана");
        }

        void Change()
        {
            Console.WriteLine("Выберете какую аудиторию вы хотите изменить");
            int n = Checker();
            int k = 0;
            foreach (Audience a in DB.audiences)
            {
                if (a.audienceNumber == n)
                {
                    Console.WriteLine("Выберете какой параметр вы хотите изменить:\n" +
                        "1 - Номер\n" +
                        "2 - Количество мест\n" +
                        "3 - Наличие проетора\n" +
                        "4 - Наличие компьютеров");
                    int answer = Checker();
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("На какой номер?");
                            int n1 = Checker();
                            a.audienceNumber = n1;
                            break;
                        case 2:
                            Console.WriteLine("На какое количество седушек?");
                            int n2 = Checker();
                            a.numberOfSeats = n2;
                            break;
                        case 3:
                            a.projector = !a.projector;
                            break;
                        case 4:
                            a.computer = !a.computer;
                            break;
                    }
                    k++;
                    break;
                }
            }
            if(k == 0) { Console.WriteLine("Такой аудитории нет"); }
        }

        void SampleNumberOfSeats()
        {
            List<int> r = new List<int>();
            Console.WriteLine("Количество мест должно быть\n" +
                "1 - больше\n" +
                "2 - равно\n" +
                "3 - меньше");
            int answer = Checker();
            Console.WriteLine("Этому числу :");
            int number = Checker();
            switch (answer)
            {
                case 1:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats > number) { r.Add(a.numberOfSeats); }
                    }
                    break;
                case 2:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats == number) { r.Add(a.numberOfSeats); }
                    }
                    break;
                case 3:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats < number) { r.Add(a.numberOfSeats); }
                    }
                    break;
            }
            Console.WriteLine("Аудитории:");
            foreach (int a in r)
            {
                Console.WriteLine(a);
            }
        }

        void SampleProjector()
        {
            Console.WriteLine("Аудитории с проектором:");
            List<int> r = new List<int>();
            foreach (Audience a in DB.audiences)
            {
                if (a.projector) { r.Add(a.audienceNumber); }
            }
            foreach (int a in r)
            {
                Console.WriteLine(a);
            }
        }

        void SampleNumberOfSeatsWithPC()
        {
            List<int> r = new List<int>();
            Console.WriteLine("Количество мест должно быть\n" +
                "1 - больше\n" +
                "2 - равно\n" +
                "3 - меньше");
            int answer = Checker();
            Console.WriteLine("Этому числу :");
            int number = Checker();
            switch (answer)
            {
                case 1:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats > number && a.computer) { r.Add(a.numberOfSeats); }
                    }
                    break;
                case 2:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats == number && a.computer) { r.Add(a.numberOfSeats); }
                    }
                    break;
                case 3:
                    foreach (Audience a in DB.audiences)
                    {
                        if (a.numberOfSeats < number && a.computer) { r.Add(a.numberOfSeats); }
                    }
                    break;
            }
            Console.WriteLine("Аудитории:");
            foreach (int a in r)
            {
                Console.WriteLine(a);
            }
        }

        void Floor()
        {
            List<int> r = new List<int>();
            Console.WriteLine("Аудитории какого этажа вы хотите найти?");
            int number = Checker();
            foreach (Audience a in DB.audiences)
            {
                string str = a.audienceNumber.ToString();
                if (str[0].ToString() == number.ToString())
                {
                    r.Add(a.audienceNumber);
                }
            }
            foreach (int a in r)
            {
                Console.WriteLine(a);
            }
        }

        void Print()
        {
            Console.WriteLine("Выборка аудиторий:");
            int n = 0;
            foreach (Audience a in DB.audiences)
            {
                Console.WriteLine("В аудитории " + a.audienceNumber +
                    "\nтакое количество сидений " + a.numberOfSeats);
                if (a.projector) { Console.WriteLine("Имеется проектор"); }
                else { Console.WriteLine("Не имеется проектор"); }
                if (a.computer) { Console.WriteLine("Имеются компьютеры\n"); }
                else { Console.WriteLine("Не имеются компьютеры\n"); }
                n++;
            }
            if (n == 0)
            {
                Console.WriteLine("Аудиторий нет");
            }
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
    }
    public class DB
    {
        public static List<Audience> audiences = new List<Audience>();
    }

    public class Audience
    {
        public int audienceNumber;
        public int numberOfSeats;
        public bool projector;
        public bool computer;

        public Audience(int n1, int n2, bool p, bool c)
        {
            audienceNumber = n1;
            numberOfSeats = n2;
            projector = p;
            computer = c;
        }
    }
}