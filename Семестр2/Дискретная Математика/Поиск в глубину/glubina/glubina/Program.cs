class Program
{
    static void Main(string[] args)
    {
        String pV, sV;
        int que = 0, frst = 0;
        Stack<string> checker = new Stack<string>();
        var tree = new Dictionary<string, int>();
        List<Rebro> rebri = new List<Rebro>();

        while (true)
        {
            Console.WriteLine("Введите первую вершину ребра");
            pV = Console.ReadLine().ToUpper();
            Console.WriteLine("Введите вторую вершину ребра");
            sV = Console.ReadLine().ToUpper();
            rebri.Add(new Rebro(pV, sV));
            Console.WriteLine("Добавить еще одно ребро? 1 - да 2 - нет");
            que = Convert.ToInt32(Console.ReadLine());
            if (que == 2) { break; }
        }
        foreach (Rebro r in rebri) {
            if (!checker.Contains(r.fV)) {
                checker.Push(r.fV);
            }
            if (!checker.Contains(r.sV)) { 
                checker.Push(r.sV); }
        }
        int cc = checker.Count;
        while (tree.Count != cc) {
            int counter = 0;
            foreach (Rebro s in rebri)
            {
                if (tree.ContainsKey(s.fV) && tree.ContainsKey(s.sV)) { counter++; continue; }
                if (checker.Peek() == s.fV) {
                    if (tree.ContainsKey(checker.Peek())) {
                        tree.Add(s.sV, frst);
                        if (checker.Contains(s.sV)) { 
                            checker.Push(s.sV); }
                    } else {
                        frst++;
                        tree.Add(s.sV, frst);
                        if (checker.Contains(s.sV)) { 
                            checker.Push(s.sV); }
                    }
                    continue;
                }
                else if (checker.Peek() == s.sV) {
                    if (tree.ContainsKey(checker.Peek())) {
                        tree.Add(s.fV, frst);
                        if (checker.Contains(s.fV)) { 
                            checker.Push(s.fV); }
                    }
                    else {
                        frst++;
                        tree.Add(s.fV, frst);
                        if (checker.Contains(s.fV)) { 
                            checker.Push(s.fV); }
                    }

                    continue;
                }
                counter++;
            }
            if (counter == rebri.Count) {
                if (tree.ContainsKey(checker.Peek())) {
                    checker.Pop();
                }
            }
        }
        foreach (KeyValuePair<string, int> t in tree) {
            Console.WriteLine("Вершина - " + t.Key);
            Console.WriteLine("Множество - " + t.Value);
        }
    }
}
public class Rebro
{
    public string fV, sV;
    public Rebro(string fV, string sV)
    {
        this.fV = fV;
        this.sV = sV;
    }
}