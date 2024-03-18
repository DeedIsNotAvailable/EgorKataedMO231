class Program {
    public static void Main() {
        int pV, sV, weight, summ = 0;
        List<Rebro> rebri = new List<Rebro> ();
        List<int> tochki = new List<int> ();
        List<int> tochkiVza = new List<int>();
        List<Rebro> rebriVza = new List<Rebro>();
        List<Rebro> rebriBuf = new List<Rebro>();
        while (true)
        {
            Console.WriteLine("Введите первую вершину ребра");
            pV = Convert.ToInt32(Console.ReadLine());
            if (!tochki.Contains(pV)) { tochki.Add(pV); }
            Console.WriteLine("Введите вторую вершину ребра");
            sV = Convert.ToInt32(Console.ReadLine());
            if (!tochki.Contains(sV)) { tochki.Add(sV); }
            Console.WriteLine("Введите вес ребра");
            weight = Convert.ToInt32(Console.ReadLine());
            rebri.Add(new Rebro(pV, sV, weight));
            Console.WriteLine("Добавить еще одно ребро? 1 - да 2 - нет");
            pV = Convert.ToInt32(Console.ReadLine());
            if(pV == 2) { break; }
        }

        Random rnd = new Random();
        int fT = tochki[rnd.Next(tochki.Count)];
        tochkiVza.Add(fT);
        tochki.Remove(fT);
        Rebro taken;

        while (true)
        {
            foreach (Rebro a in rebri)
            {
                foreach (int b in tochkiVza)
                {
                    if ((a.sV == b || a.pV == b) & !(tochkiVza.Contains(a.sV) && tochkiVza.Contains(a.pV)))
                    {
                        rebriBuf.Add(a);
                    }
                }
            }
            taken = rebriBuf[0];
            foreach (Rebro a in rebriBuf)
            {
                if (a.weight < taken.weight)
                {
                    taken = a;
                }
            }
            rebriBuf.Clear();
            summ += taken.weight;
            rebri.Remove(taken);
            rebriVza.Add(taken);
            
            if (!tochkiVza.Contains(taken.pV)) { tochkiVza.Add(taken.pV); tochki.Remove(taken.pV); }
            if (!tochkiVza.Contains(taken.sV)) { tochkiVza.Add(taken.sV); tochki.Remove(taken.sV); }
            
            if (tochki.Count() == 0) { break; }
        }

        Console.WriteLine(summ + " сумма");

    }
}
public class Rebro {
    public int pV;
    public int sV;
    public int weight;
    public Rebro(int pV, int sV, int weight)
    {
        this.pV = pV;
        this.sV = sV;
        this.weight = weight;
    }
}