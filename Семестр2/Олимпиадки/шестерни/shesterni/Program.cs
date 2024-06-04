class shesterni
{
    static void Main(string[] args)
    {
        StreamReader StreR = new StreamReader("C:\\Users\\Deed\\Desktop\\inputs\\input.txt"); //путь к файлу
        StreamWriter StraW = new StreamWriter("output.txt");

        string token = StreR.ReadLine();
        string[] tokenSplited = token.Split(" ");

        int N = Convert.ToInt32(tokenSplited[0]);
        int M = Convert.ToInt32(tokenSplited[1]);

        gear[] amoun = new gear[N];

        for (int i = 0; i < N; i++)
        {
            amoun[i] = new gear();
            amoun[i].nearGs = new int[N];
            string str1 = StreR.ReadLine();
            string[] e1 = str1.Split(" ");
            amoun[i].n = Convert.ToInt32(e1[0]);
            amoun[i].zubci = Convert.ToDouble(e1[1]);
        }

        for (int i = 0; i < M; i++)
        {
            string tokenN = StreR.ReadLine();
            string[] tokenM = tokenN.Split(" ");
            int r1 = Convert.ToInt32(tokenM[0]);
            int r2 = Convert.ToInt32(tokenM[1]);

            if (r1 >= 1 || r1 <= N || r2 >= 1 || r2 <= N)
            {
                for (int j = 0; j < N; j++)
                {
                    if (amoun[j].n == r1)
                    {
                        amoun[j].nearGs[amoun[j].i] = r2;
                        amoun[j].i++;
                    }
                    if (amoun[j].n == r2)
                    {
                        amoun[j].nearGs[amoun[j].i] = r1;
                        amoun[j].i++;
                    }
                }
            }
        }

        int start = 0;
        int end = 0;

        string str11 = StreR.ReadLine();
        string[] e11 = str11.Split(" ");
        string str22 = StreR.ReadLine();
        string[] e22 = str22.Split(" ");

        int a1 = Convert.ToInt32(e11[0]);
        int b1 = Convert.ToInt32(e11[1]);

        for (int j = 0; j < N; j++)
        {
            if (amoun[j].n == a1) amoun[j].direction = Convert.ToInt32(e22[0]); start = j;
            if (amoun[j].n == b1) end = j;
        }

        if (s(amoun[start], ref amoun))
        {
            StraW.WriteLine(1);
            StraW.WriteLine(amoun[end].direction);
            StraW.WriteLine("{0:N3}", amoun[start].zubci / amoun[end].zubci);
        }

        else StraW.WriteLine(-1);

        StreR.Close(); StraW.Close();
    }
    static bool s(gear A, ref gear[] mas)
    {
        for (int i = 0; i < A.i; i++)
        {
            for (int j = 0; j < mas.Length; j++)
            {
                if (A.nearGs[i] == mas[j].n)
                {
                    if (mas[j].direction == 0) mas[j].direction = -A.direction;
                    else if (mas[j].direction != -A.direction) return false;
                    if (mas[j].meets != 1)
                    {
                        mas[j].meets = 1;
                        if (s(mas[j], ref mas) == false) return false;
                    }
                }
            }
        }

        return true;
    }
    public class gear
    {
        public int n;
        public double zubci;
        public int[] nearGs;
        public int direction;
        public int i = 0;
        public int meets = 0;
    }
}