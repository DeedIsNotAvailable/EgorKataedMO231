using System.Text.RegularExpressions;

class Rgr
{
    public static void Main(String[] args)
    {
        var edges = new List<Edge>();
        var nodes = new List<int>();
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
                edges.Add(new Edge(
                    Int32.Parse(digits[0]),
                    Int32.Parse(digits[1]),
                    Int32.Parse(digits[2])
                    ));
                data = reader.ReadLine();
            }
            reader.Close();
        }
        catch (IOException e)
        {
            throw e;
        }

        foreach (Edge e in edges)
        {
            if (!nodes.Contains(e.x)) { nodes.Add(e.x); }
            if (!nodes.Contains(e.y)) { nodes.Add(e.y); }
        }

        int summ = 0;
        var edgesT = new List<Edge>();
        var edgesTW = new List<int>();
        var nodesT = new List<int>();
        nodesT.Add(nodes[0]);

        for (int i = 1; i < N; i++)
        {
            foreach (Edge e in edges)
            {
                foreach (int n in nodesT)
                {
                    if (nodesT.Contains(e.x) & !nodesT.Contains(e.y) || nodesT.Contains(e.y) & !nodesT.Contains(e.x))
                    {
                        edgesT.Add(e);
                        edgesTW.Add(e.weight);
                    }
                }
            }
            foreach (Edge e in edgesT)
            {
                if (e.weight == edgesTW.Min())
                {
                    if (nodesT.Contains(e.x))
                    {
                        nodesT.Add(e.y);
                    }
                    else
                    {
                        nodesT.Add(e.x);
                    }
                    edges.Remove(e);
                    summ += e.weight;
                    break;
                }
            }
            edgesT.Clear();
            edgesTW.Clear();
        }
        if (summ >= 100)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(summ);
            foreach (int n in nodes)
            {
                Console.Write($"{n} ");
            }
        }

    }
}

class Edge
{
    public int x;
    public int y;
    public int weight;
    public Edge(int x, int y, int weight)
    {
        this.x = x;
        this.y = y;
        this.weight = weight;
    }
}