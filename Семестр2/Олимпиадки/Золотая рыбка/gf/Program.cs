class gf
{
    static void Main(string[] args)
    {
        StreamReader StrR = new StreamReader("C:\\Users\\Deed\\Desktop\\inputs\\input.txt"); //input
        StreamWriter StrW = new StreamWriter("output.txt");

        string[] toito = StrR.ReadLine().Split();
        int n = int.Parse(toito[0]);
        int m = int.Parse(toito[1]);
        string[] Coords = StrR.ReadLine().Split();
        int xAxis = int.Parse(Coords[0]);
        int yAxis = int.Parse(Coords[1]);
        int zAxis = int.Parse(Coords[2]);
        for (int i = 0; i < m; i++)
        {
            string[] axis = StrR.ReadLine().Split();
            string ax = axis[0];
            int ker = int.Parse(axis[1]);
            int ser = int.Parse(axis[2]);
            if (ax.Equals("X") && xAxis == ker)
            {
                List<List<int>> mas = new List<List<int>>();
                for (int j = 0; j < n; j++)
                {
                    mas.Add(new List<int>());
                    for (int l = 0; l < n; l++) mas[j].Add(0);
                }
                mas[yAxis - 1][zAxis - 1] = 1;
                if (ser == 1) mas = spin(mas);
                else mas = spin(spin(spin(mas)));
                for (int j = 0; j < n; j++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        if (mas[j][l] == 1)
                        {
                            yAxis = j + 1;
                            zAxis = l + 1;
                        }
                    }
                }
            }
            if (ax.Equals("Y") && yAxis == ker)
            {
                List<List<int>> mas = new List<List<int>>();
                for (int j = 0; j < n; j++)
                {
                    mas.Add(new List<int>());
                    for (int l = 0; l < n; l++) mas[j].Add(0);
                }
                mas[xAxis - 1][zAxis - 1] = 1;
                if (ser == 1) mas = spin(mas);
                else mas = spin(spin(spin(mas)));
                for (int j = 0; j < n; j++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        if (mas[j][l] == 1)
                        {
                            xAxis = j + 1;
                            zAxis = l + 1;
                        }
                    }
                }
            }
            if (ax.Equals("Z") && zAxis == ker)
            {
                List<List<int>> pole = new List<List<int>>();
                for (int j = 0; j < n; j++)
                {
                    pole.Add(new List<int>());
                    for (int l = 0; l < n; l++) pole[j].Add(0);
                }

                pole[xAxis - 1][yAxis - 1] = 1;

                if (ser == 1) pole = spin(pole);

                else pole = spin(spin(spin(pole)));
                for (int j = 0; j < n; j++)
                {
                    for (int l = 0; l < n; l++)
                    {
                        if (pole[j][l] == 1)
                        {
                            xAxis = j + 1;
                            yAxis = l + 1;
                        }
                    }
                }
            }
        }
        StrW.Write($"{xAxis} {yAxis} {zAxis}");
        StrW.Close();
    }

    static List<List<int>> spin(List<List<int>> m)
    {
        List<List<int>> matdone = new List<List<int>>();
        for (int i = 0; i < m[0].Count; i++)
        {
            List<int> res = new List<int>();
            for (int j = m.Count - 1; j >= 0; j--) res.Add(m[j][i]);
            matdone.Add(res);
        }
        return matdone;
    }
}