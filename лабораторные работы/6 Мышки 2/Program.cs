class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Количество");
        int colvo = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Белая мышь");
        int wm = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("k");
        int k = Convert.ToInt32(Console.ReadLine());
        int[] mouses = new int[colvo];
        for (int l = 0; l < colvo; l++) { mouses[l] = l; }
        int str = 0;
        while (Array.FindAll(mouses, element => element == -1).Length != mouses.Length - 1) {
            mouses[Decider(mouses, str, k)] = -1;
            str = Decider(mouses, str, k);
        }
        int num = Array.IndexOf(mouses, Array.Find(mouses, element => element != -1));
        int c = 0;
        Console.WriteLine(num);
    }
    static int Decider(int[] mouses, int n, int s)
    {
        int m = 0;
        for (int i = 1, j = 0; j < s + 1; i++) {
            if (n + i < mouses.Length) {
                if (mouses[n + i] != -1){++j;}
            }
            else if (n + i > mouses.Length - 1){
                int f = n + i;
                while (f > mouses.Length - 1){f -= mouses.Length;}
                if (mouses[f] != -1){++j;}
            }
            m = i;
        }
        n += m;
        while (n > mouses.Length - 1){
            n -= mouses.Length;
        }
        return n;
    }
}