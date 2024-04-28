class KruskalAlgorithm
{
    static void Main(string[] args)
    {
        var rebra = new List<Tuple<char, char, int>>
        {
            Tuple.Create('A', 'B', 2),
            Tuple.Create('B', 'C', 2),
            Tuple.Create('A', 'C', 2),
            Tuple.Create('A', 'E', 7),
            Tuple.Create('C', 'E', 5),
            Tuple.Create('B', 'E', 2),
            Tuple.Create('B', 'D', 9),
            Tuple.Create('E', 'G', 9),
            Tuple.Create('D', 'G', 2),
            Tuple.Create('D', 'H', 16),
            Tuple.Create('G', 'H', 17),
            Tuple.Create('D', 'F', 5),
            Tuple.Create('F', 'H', 17),
            Tuple.Create('E', 'D', 10),
        };

        int answer = 0;
        var result = Kruskal(rebra);
        foreach (var edge in result)
        {
            answer += edge.Item3;
            Console.WriteLine(edge.Item1 + " - " + edge.Item2 + " : " + edge.Item3);
        }
        Console.WriteLine(answer);
    }
    static List<Tuple<char, char, int>> Kruskal(List<Tuple<char, char, int>> rebra)
    {
        var result = new List<Tuple<char, char, int>>();
        var tree = new Dictionary<char, char>();

        rebra = rebra.OrderBy(e => e.Item3).ToList();

        foreach (var rebro in rebra)
        {
            char root1 = Find(rebro.Item1, tree);
            char root2 = Find(rebro.Item2, tree);

            if (root1 != root2)
            {
                result.Add(rebro);
                tree[root1] = root2;
            }
        }
        return result;
    }
    static char Find(char v, Dictionary<char, char> tree)
    {
        if (!tree.ContainsKey(v))
        {
            tree[v] = v;
        }

        if (tree[v] != v)
        {
            tree[v] = Find(tree[v], tree);
        }

        return tree[v];
    }
}