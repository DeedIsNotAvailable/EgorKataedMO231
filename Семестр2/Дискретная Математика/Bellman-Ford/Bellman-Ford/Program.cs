class Program {
public static void Main() {
        int fP, sP, weight, decider, mainPoint;
        List<Edge> edges = new List<Edge>();
        List<int> points = new List<int>();
        List<Point> sPoints = new List<Point>();

        while (true) {
            Console.Write("Из какой точки исходит ребро: ");
            fP = Convert.ToInt32(Console.ReadLine());
            if (!points.Contains(fP)) { points.Add(fP); }
            Console.Write("В какую точку оно заходит: ");
            sP = Convert.ToInt32(Console.ReadLine());
            if(!points.Contains(sP)) { points.Add(sP); }
            Console.Write("Введите вес ребра: ");
            weight = Convert.ToInt32(Console.ReadLine());
            edges.Add(new Edge(fP, sP, weight));
            Console.Write("Добавить еще одно ребро? 1 - да 2 - нет: ");
            decider = Convert.ToInt32(Console.ReadLine());
            if (decider == 2) { break; }
            else if (decider == 1) { Console.WriteLine("Еще одно ребро: "); }
            else { Console.WriteLine("Неверный вариант!"); }
        }

        Console.Write("Из какой точки считать все расстояния: ");
        mainPoint = Convert.ToInt32(Console.ReadLine());
        points.Remove(mainPoint);
        sPoints.Add(new Point(mainPoint, 0));

        foreach (int p in points) { sPoints.Add(new Point(p, null)); }
        foreach (Edge e in edges) {
            foreach (Point p in sPoints) {
                if (e.fP == p.name)
                {
                    foreach (Point d in sPoints) {
                        if (e.sP == d.name) {
                            p.infs.Add(d);
                        }
                    }
                }
            }
        }

        int dB = 0;

        for (int i = 0; i < sPoints.Count; i++)
        {
            foreach (Point p in sPoints)
            {
                if (p.distance != null)
                {
                    foreach (Point d in p.infs)
                    {
                        foreach (Edge e in edges) { if (e.fP == p.name && e.sP == d.name) { dB = e.weight; } }
                        if ((d.distance == null) || (d.distance > p.distance + dB))
                        {
                            d.distance = p.distance + dB;
                        }
                        dB = 0;
                    }
                }
            }
        }

        foreach (Point p in sPoints) {
            Console.WriteLine("Дистанция от " + mainPoint + " до " + p.name + " : " + p.distance);
        }
        
    }
}
public class Edge {
    public int fP;
    public int sP;
    public int weight;
    public Edge(int fP, int sP, int weight) {
        this.fP = fP;
        this.sP = sP;
        this.weight = weight;
    }
}

public class Point {
    public int? distance;
    public int name;
    public List<Point> infs = new List<Point>();
    public Point(int name, int? distance) {
        this.name = name;
        this.distance = distance;
    }
}