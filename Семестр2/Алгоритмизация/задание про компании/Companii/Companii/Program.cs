using System.Linq;

class Program
{
    public static void Main(string[] args)
    {

        product apple = new product(1, "apple", "еда", 10);
        product grape = new product(2, "grape", "еда", 12);
        product peach = new product(3, "peach", "еда", 11);
        product phone = new product(4, "phone", "электроника", 5100);
        product notepad = new product(5, "notepad", "электроника", 5500);
        product computer = new product(6, "computer", "электроника", 7300);
        product table = new product(7, "table", "мебель", 2200);
        product chair = new product(8, "chair", "мебель", 1700);
        product sofa = new product(9, "sofa", "мебель", 3100);

        var storages = new List<storage>
        {
            new storage(1),
            new storage(2),
            new storage(3)
        };

        storages[0].addItem(new item(20, apple));
        storages[0].addItem(new item(5, sofa));
        storages[0].addItem(new item(5, phone));
        storages[0].addItem(new item(10, notepad));
        storages[1].addItem(new item(45, grape));
        storages[1].addItem(new item(145, peach));
        storages[1].addItem(new item(4, notepad));
        storages[1].addItem(new item(3, computer));
        storages[2].addItem(new item(4, computer));
        storages[2].addItem(new item(17, table));
        storages[2].addItem(new item(78, chair));

        int i = 0;

        Console.WriteLine("5)Общее количество товаров на каждом складе по категориям");
        foreach (var p in storages)
        {
            i++;
            var amountPerStorage = p.items.GroupBy(x => x.type.category);
            foreach(var am in amountPerStorage)
            {
                int amo = am.Sum(x => x.amount);
                Console.WriteLine($"На складе {i} по категории {am.Key} количество товаров равно: {amo}");
            }
        }
        Console.WriteLine("\n");
        i = 0;

        Console.WriteLine("4)Самый дешевый товар на каждом складе");
        var minP = storages.Select(x => x.items.Min(x => x.type.price)).ToList(); //4
        foreach (var p in minP)
        {
            i++;
            Console.WriteLine($"На складе {i} цена самого дешевого товара равна: {p}");
        }
        Console.WriteLine("\n");
        i = 0;

        Console.WriteLine("3)Среднее значение для категорий");
        var allItems = storages.SelectMany(x => x.items); //3
        var itemCat = allItems.GroupBy(p => p.type.category);
        //List<double> mede = itemCat.Select(i => i.Average(g => g.type.price * g.amount)).ToList();
        foreach (var item in itemCat)
        {
            double m = item.Average(g => g.type.price * g.amount);
            Console.WriteLine($"{item.Key} {m}");
        }
        Console.WriteLine("\n");
        

        Console.WriteLine("2)Максимальная цена товара по каждой категории");
        foreach (storage g in storages) //2
        {
            i++;
            var maxValuesPerC = g.items.OrderByDescending(s => s.type.price).GroupBy(s => s.type.category);
            Console.WriteLine($"Для склада {i}:");
            foreach (var v in maxValuesPerC)
            {
                foreach (var person in v)
                {
                    Console.WriteLine($"{v.Key} {person.type.price}");
                    break;
                }
                
            }
            Console.WriteLine();
        }
        i = 0;

        Console.WriteLine("1)Объем товара в денежном эквиваленте"); //1
        var volumes = storages.Select(s => s.items.Sum(x => x.type.price * x.amount));
        foreach (var volume in volumes) 
        {
            i++;
            Console.WriteLine($"На складе {i} объем товара равен: {volume}");
        }
        i = 0;
    }
}

public class storage
{
    public List<item> items = new List<item>();
    public int id;
    public storage(int id)
    {
        this.id = id;
    }
    public void addItem(item item)
    {
        items.Add(item);
    }
}

public class item
{
    public int amount;
    public product type;
    public item(int amount, product type)
    {
        this.amount = amount;
        this.type = type;
    }
}

public class product
{
    public int id;
    public string name;
    public string category;
    public int price;
    public product(int id, string name, string category, int price)
    {
        this.id = id;
        this.name = name;
        this.category = category;
        this.price = price;
    }
}