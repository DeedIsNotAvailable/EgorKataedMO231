class Program
{
    static List<List<int>> graph = new List<List<int>>();
    static List<Edge> edges = new List<Edge>();
    static int[] alreadyUsed = new int[5];
    static int t = 1;
    static int s, f, ans;

    static void Main(string[] args)
    {
        List<int[]> intiate = new List<int[]>
        {
            new int[] {0, 1, 20}, new int[] {0, 2, 30}, new int[] {0, 3, 10},
            new int[] {1, 2, 40}, new int[] {1, 4, 30}, new int[] {2, 3, 10},
            new int[] {2, 4, 20}, new int[] {3, 4, 20}
        };

        s = 0;
        f = 4;
        ans = 0;

        for (int i = 0; i < 5; i++) graph.Add(new List<int>());
        foreach (var a in intiate) addEdgee(a[0], a[1], a[2]);
        while (FF(s, int.MaxValue) > 0) t++;
        foreach (var a in graph[s]) ans += edges[a].flow;
        Console.WriteLine(ans);
    }
    static void addEdgee(int vO, int vN, int weight)
    {
        graph[vO].Add(edges.Count);
        edges.Add(new Edge(vN, weight));
        graph[vN].Add(edges.Count);
        edges.Add(new Edge(vO, 0));
    }
    static int FF(int versh, int minCapacity)
    {
        if (versh == f) return minCapacity;
        alreadyUsed[versh] = t;

        foreach (var i in graph[versh])
        {
            if (edges[i].gvc() == 0 || alreadyUsed[edges[i].point] == t) continue;
            int x = FF(edges[i].point, Math.Min(minCapacity, edges[i].gvc()));
            if (x > 0)
            {
                edges[i].flow += x;
                edges[i ^ 1].flow -= x;
                return x;
            }
        }
        return 0;
    }
}

class Edge
{
    public int point;
    public int flow;
    public int weight;

    public Edge(int versh, int weight)
    {
        this.point = versh;
        this.flow = 0;
        this.weight = weight;
    }

    public int gvc()
    {
        return this.weight - this.flow;
    }
}