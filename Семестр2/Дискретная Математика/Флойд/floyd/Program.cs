internal class floyd
{
    static void Main(string[] args)
    {
        int[,] graph =    { {0,4,0,0,3,5,0},
                            {0,0,0,0,4,4,0},
                            {0,1,0,3,0,3,0},
                            {0,0,0,0,0,0,2},
                            {0,0,6,0,0,0,0},
                            {0,0,0,3,0,0,0},
                            {0,0,0,0,0,0,2} };
        for (int k = 0; k < graph.GetLength(0); k++)
            for (int i = 0; i < graph.GetLength(0); i++)
                for (int j = 0; j < graph.GetLength(0); j++)
                    if (i != j && graph[k, j] != 0 && graph[i, k] != 0 && (graph[i, j] > graph[i, k] + graph[k, j] || graph[i, j] == 0))  graph[i, j] = graph[i, k] + graph[k, j];
        for (int i = 0; i < graph.GetLength(0); i++)
        {
            for (int j = 0; j < graph.GetLength(0); j++) Console.Write(graph[i, j] + "  ");
            Console.WriteLine();
        }
    }
}