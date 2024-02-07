internal class Program
{
    static void Main(string[] args)
    {

        int c = Convert.ToInt32(Console.ReadLine());
        int c1 = c;
        int ost_c = Convert.ToInt32(Console.ReadLine());
        int ost_c1 = ost_c;
        int b = Convert.ToInt32(Console.ReadLine());
        int b1 = b;
        int ost_b = Convert.ToInt32(Console.ReadLine());
        int ost_b1 = ost_b;
        int k = Convert.ToInt32(Console.ReadLine());
        int n = c + b;
        int ost_n = (c - ost_c) + (b - ost_b);
        int[] misi = new int[n];
        int start_pos = 0;
        for (int i = 0; i < ost_n; i++)
        {
            for (int j = 0; j < k;)
            {
                start_pos++;
                while (start_pos > n - 1)
                {
                    start_pos = start_pos - n;
                }
                if (misi[start_pos] != -1 || misi[start_pos] != -2)
                {
                    j++;
                }
            }
            if (ost_b1 != b)
            {
                misi[start_pos] = -1;
                ost_b1++;
            }
            else if (ost_c1 != c)
            {
                misi[start_pos] = -2;
                ost_c1++;
            }

        }
        for (int i = 0; i < n; i++)
        {
            if (misi[i] == -1 || misi[i] == -2)
            {
                continue;
            }
            else if (c1 - (c - ost_c) != 0)
            {
                misi[i] = 2;
                c1--;
            }
            else if (b1 - (b - ost_b) != 0)
            {
                misi[i] = 1;
                b1--;
            }

        }
        Console.Write("Расположение мышей: ");
        for (int i = 0; i < n; i++)
        {
            if (ost_b > b || ost_c > c)
            {
                Console.WriteLine("невозможно");
                break;
            }
            if (misi[i] == 1 || misi[i] == -1) Console.Write("б ");
            if (misi[i] == 2 || misi[i] == -2) Console.Write("с ");
        }

    }
}