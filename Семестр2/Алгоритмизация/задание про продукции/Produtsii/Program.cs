class Program
{
    static void Main(string[] args)
    {
        List<worker> workers = new List<worker>
        {
            new worker(1001, "John Smith", "Manufacturing", 500, 10, 300000, "Assembly"),
            new worker(1002, "Sarah Johnson", "IT", 10, 100, 50000, "Programs"),
            new worker(1003, "Michael Brown", "Designer", 5, 200000, 60000, "Graphic Design"),
            new worker(1004, "Emily Davis", "Salesperson", 100, 50, 40000, "Advertisment"),
            new worker(1005, "David Wilson", "Manufacturing", 1000, 5, 35000, "Assembly"),
            new worker(1006, "Alice Thompson", "Salesperson", 75, 150, 30000, "Business Development"),
            new worker(1007, "Ryan Lee", "Developer", 8, 55000, 20000, "Mobile App"),
            new worker(1008, "Sophia Rodriguez", "Designer", 15, 800, 48000, "Graphic Design"),
            new worker(1009, "Ethan Davis", "Manufacturing", 800, 7, 3800, "Quality Control"),
            new worker(1010, "Olivia Evans", "Salesperson", 60, 120, 32000, "Advertisment"),
            new worker(1011, "Liam Martinez", "Developer", 6, 60000, 29000, "Mobile App"),
            new worker(1012, "Ava Nguyen", "Designer", 12, 700, 45000, "UI/UX Design")
        };

        Console.WriteLine($"\n задание 1"); 
        int FirstT = workers.Where(x => x.salary < x.price * x.produced).Count();
        Console.WriteLine($"количество работников которые получают зарплату меньше чем они производят: {FirstT}");

        Console.WriteLine($"\n задание 2");
        var SecondT = workers.GroupBy(x => x.category);
        foreach( var t in SecondT )
        {
            int amount = t.Sum(x => x.produced);
            Console.WriteLine($"{t.Key} {amount}");
        }

        Console.WriteLine($"\n задание 3");
        var ThirdT = workers.GroupBy(x => x.specialty);
        foreach (var t in ThirdT)
        {
            int amount = t.Sum(x => x.price * x.produced);
            Console.WriteLine($"{t.Key} {amount}");
        }

        Console.WriteLine($"\n задание 4");
        int FourthT = workers.Where(x => x.salary > x.price * 0.5).Count();
        Console.WriteLine($"количество работников которые получают зарплату больше чем 50% от суммы производимого товара: {FourthT}");
    }
}

class worker
{
    public int id;
    public string name;
    public string category;
    public int produced;
    public int price;
    public int salary;
    public string specialty;
    public worker(int id, string name, string category, int produced, int price, int salary, string specialty)
    {
        this.id = id;
        this.name = name;
        this.category = category;
        this.produced = produced;
        this.price = price;
        this.salary = salary;
        this.specialty = specialty;
    }
}