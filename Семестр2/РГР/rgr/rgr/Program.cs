using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        
        var edges = new List<Rebro>();
        var points = new List<int>();
        var sPoints = new List<Tch>();
        int N, M;
        String? data;
        String[] digits;
        try
        {
            StreamReader reader = new StreamReader("input.txt");
            N = Int32.Parse(reader.ReadLine());
            M = Int32.Parse(reader.ReadLine());
            data = reader.ReadLine();
            while (data != null)
            {
                digits = Regex.Split(data, @"\D+");
                if (!points.Contains(Int32.Parse(digits[0]))) { points.Add(Int32.Parse(digits[0])); }
                if (!points.Contains(Int32.Parse(digits[1]))) { points.Add(Int32.Parse(digits[1])); }
                edges.Add(new Rebro(
                    Int32.Parse(digits[0]),
                    Int32.Parse(digits[1]),
                    Int32.Parse(digits[2])
                    ));
                data = reader.ReadLine();
            }
            reader.Close();
        }
        catch (IOException e) { throw e; }
        foreach (var p in points)  { sPoints.Add(new Tch(p, 0)); }

        var oPoints = new List<Tch>();
        int otherPointInRebro;
        foreach (var p in points) 
        {
            otherPointInRebro = 0;
            int lPN = p;
            int lPD = 0;
            for (int i = 0; i <= points.Count + 10; i++)
            {
                foreach (Tch a in sPoints)
                {
                    if (a.name.Equals(lPN))
                    {
                        sPoints.Remove(a);
                        //if (i == 0) break;
                        if(a.distance > 100) Console.WriteLine($"От пункта {p} до {a.name} потеря информации: {-1}");
                        else Console.WriteLine($"От пункта {p} до {a.name} потеря информации: {a.distance}");
                        break;
                    }
                }
                if (i == points.Count + 10) break;
                foreach (Rebro r in edges)
                {
                    if (r.tch.Contains(lPN))
                    {
                        otherPointInRebro = r.getTheOtherPoint(lPN);
                        foreach (Tch oP in sPoints)
                        {
                            if (oP.name.Equals(otherPointInRebro))
                            {
                                if (oP.distance > lPD + r.weight || oP.distance == 0) oP.distance = lPD + r.weight;
                                oPoints.Add(oP);
                            }
                        }
                    }
                }
                if (oPoints.Any()) lPD = oPoints.Min(Tch => Tch.distance);
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
            Console.WriteLine("");
            sPoints.Clear();
            foreach (var d in points) { sPoints.Add(new Tch(d, 0)); }
            oPoints.Clear();
        }
    }
}
public class Rebro
{
    public List<int> tch = new List<int>();
    public int weight;
    public Rebro(int fV, int sV, int weight)
    {
        tch.Add(fV);
        tch.Add(sV);
        this.weight = weight;
    }

    public int getTheOtherPoint(int point)
    {
        foreach (int g in tch) { if (!g.Equals(point)) { return g; } }
        return -1;
    }
}

public class Tch
{
    public int name;
    public int distance;
    public Tch(int name, int distance)
    {
        this.name = name;
        this.distance = distance;
    }
}