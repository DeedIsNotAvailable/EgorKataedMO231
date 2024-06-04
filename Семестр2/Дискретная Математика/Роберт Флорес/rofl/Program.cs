class fc
{
    static void Main(string[] args)
    {
        int[,] g = {
            {0, 1, 1, 1, 0, 0, 0},
            {1, 0, 1, 0, 1, 0, 1},
            {1, 1, 0, 1, 1, 1, 1},
            {1, 0, 1, 0, 1, 1, 1},
            {0, 1, 1, 1, 0, 1, 0},
            {0, 0, 1, 1, 1, 0, 1},
            {0, 1, 1, 1, 0, 1, 0},
        };
        int V = g.GetLength(0);
        List<int> points = new List<int>();
        rf(0, 0);
        void rf(int v, int count)
        {
            points.Add(v);
            if (count == V - 1)
            {
                if (g[v, 0] == 1)
                {
                    Console.WriteLine("Гамильтонов цикл:");
                    foreach (int vr in points) Console.Write(vr + 1 + " ");
                    return;
                }
            }
            else
            {
                for (int i = 0; i < V; i++)
                {
                    if (g[v, i] == 1 && !points.Contains(i)) rf(i, count + 1);
                }
            }
            points.RemoveAt(points.Count - 1);
        }
    }
}