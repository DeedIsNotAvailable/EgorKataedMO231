class HelloWorld
{
    static void Main()
    {
        int stroki = Convert.ToInt32(Console.ReadLine());
        int stolbci = Convert.ToInt32(Console.ReadLine());

        int a = 0;
        int b = 0;
        int c = 0;
        int d = 0;
        int e = 0;

        int a1;
        int a2;
        bool b1 = true;
        int d1;
        int e1;
        int e2;
        int e3;
        int[,] e4 = new int[stroki, 3];

        int[,] massive = new int[stroki, stolbci];

        for (int i = 0; i < stroki; i++)
        {
            for (int j = 0; j < stolbci; j++)
            {
                massive[i, j] = Convert.ToInt32(Console.ReadLine());
                if (massive[i, j] == 0)
                {
                    c++;
                }
            }
        }

        for (int i = 0; i < stroki; i++)
        {
            a1 = massive[i, 0];
            a2 = massive[i, 0];
            d1 = 0;
            for (int j = 0; j < stolbci; j++)
            {
                if (a1 > massive[i, j])
                {
                    a1 = massive[i, j];
                }
                if (a2 < massive[i, j])
                {
                    a2 = massive[i, j];
                }
                d1 += massive[i, j];
            }
            if (a1 % 2 == 0 & a2 % 2 == 0)
            {
                a++;
            }
            if (d1 == 0)
            {
                d++;
            }
        }

        for (int i = 0; i < stolbci; i++)
        {
            for (int j = 0; j < stroki; j++)
            {
                if (massive[j, i] < 0)
                {
                    b1 = false;
                }
            }

            if (b1 == true) { b++; }
            b1 = true;
        }

        for (int i = 0; i < stroki; i++)
        {
            e1 = 0;
            e2 = 1;
            e3 = 0;
            for (int j = 0; j < stolbci; j++)
            {
                e1 += massive[i, j];
                if (massive[i, j] != 0)
                {
                    e2 *= massive[i, j];
                }
                if (massive[i, j] == 0)
                {
                    e3++;
                }
            }
            e4[i, 0] = e1;
            e4[i, 1] = e2;
            e4[i, 2] = e3;
        }
        
        for (int i = 0; i < stroki; i++) 
        {
            e1 = e4[i, 0];
            e2 = e4[i, 1];
            e3 = e4[i, 2];
            for (int j = 0; j < stroki; j++) 
            {
                if (i != j & e1 == e4[j, 0] & e2 == e4[j, 1] & e3 == e4[j, 2])
                {
                    e++;
                }
            }
        }

        e /= 2;

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
        Console.WriteLine(d);
        Console.WriteLine(e);
    }
}
