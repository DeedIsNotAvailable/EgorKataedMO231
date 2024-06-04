class taukit
{
    static void Main(string[] args)
    {
        StreamReader StreR = new StreamReader("C:\\Users\\Deed\\Desktop\\inputs\\input.txt");
        StreamWriter StreaW = new StreamWriter("output.txt");
        string[] tok = StreR.ReadLine().Split();
        string[] ans = new string[tok.Length];
        int rest = tok.Length;
        rest = rest / 2;
        int ta, tb, re;

        for (int i = 0; i < tok.Length; i++)
        {
            if (i % 2 == 0) ta = i;
            else ta = -i;
            rest += ta;

            re = tok[rest].Length / 2;

            for (int j = 0; j < tok[rest].Length; j++)
            {
                if (j % 2 == 0) tb = j;
                else tb = -j;
                re += tb;

                ans[i] += tok[rest][re];
            }

        }
        StreaW.Write(string.Join(" ", ans));
        StreaW.Close();
    }
}