class Program
{
    static void Main(string[] args)
    {
        int weight, decider;
        String fP, sP, mainPoint;
        var edges = new List<Rebro>();
        var points = new List<String>();
        var sPoints = new List<Tch>();

        while (true)
        {
            Console.Write("Первая точка ребра: ");
            fP = Console.ReadLine();
            if (!points.Contains(fP)) { points.Add(fP); sPoints.Add(new Tch(fP, 0)); }
            Console.Write("Вторая точка ребра: ");
            sP = Console.ReadLine();
            if (!points.Contains(sP)) { points.Add(sP); sPoints.Add(new Tch(sP, 0)); }
            Console.Write("Введите вес ребра: ");
            weight = Convert.ToInt32(Console.ReadLine());
            edges.Add(new Rebro(fP, sP, weight));
            Console.Write("Добавить еще одно ребро? 1 - да 2 - нет: ");
            decider = Convert.ToInt32(Console.ReadLine());
            if (decider == 2) { break; }
            else if (decider == 1) { Console.WriteLine("Еще одно ребро: "); }
        }

        foreach(String p in points) { Console.WriteLine(p); }

        Console.Write("Из какой точки считать все расстояния: ");

        mainPoint = Console.ReadLine();
        String lPN = mainPoint;
        int lPD = 0;

        var oPoints = new List<Tch>();
        String otherPointInRebro;

        for (int i = 0; i <= points.Count; i++)
        {
            foreach (Tch a in sPoints)
            {
                if (a.name.Equals(lPN))
                {
                    Console.WriteLine($"От точки {mainPoint} до {a.name} расстояние: {a.distance}");
                    sPoints.Remove(a);
                    break;
                }
            }
            if (i == points.Count) break;
            foreach (Rebro r in edges)
            {
                if (r.tch.Contains(lPN))
                {
                    otherPointInRebro = r.getTheOtherPoint(lPN);
                    foreach (Tch oP in sPoints)
                    {
                        if (oP.name.Equals(otherPointInRebro))
                        {
                            oP.distance = lPD + r.weight;
                            oPoints.Add(oP);
                        }
                    }
                }
            }
            lPD = oPoints.Min(Tch => Tch.distance);
            foreach (Tch a in oPoints)
            {
                if (a.distance == lPD)
                {
                    lPN = a.name;
                    oPoints.Remove(a);
                    break;
                }
            }
        }
    }
}
public class Rebro
{
    public List<String> tch = new List<String>();
    public int weight;
    public Rebro(string fV, string sV, int weight)
    {
        tch.Add(fV);
        tch.Add(sV);
        this.weight = weight;
    }

    public String getTheOtherPoint(String point) {
        foreach (String g in tch) { if (!g.Equals(point)) { return g; } }
        return "err";
    }
}

public class Tch
{
    public string name;
    public int distance;
    public Tch(string name, int distance) {
        this.name = name;
        this.distance = distance;
    }
}