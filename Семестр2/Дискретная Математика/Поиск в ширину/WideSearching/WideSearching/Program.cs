class Program
{
    static void Main(string[] args)
    {
        List<Rebro> rebri = new List<Rebro>();
        List<string> vers = new List<string>();
        List<string> check = new List<string>();
        var otol = new Dictionary<string, int>();
        int countup = 0, que = 0;
        String pV, sV;

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
            if (!check.Contains(r.fV)) { 
                check.Add(r.fV); }
            if (!check.Contains(r.sV)) { 
                check.Add(r.sV); }
        }
        while (otol.Count != check.Count) {
            while (vers.Count != 0) {
                foreach (string q in vers) {
                    foreach (Rebro s in rebri) {
                        if (otol.ContainsKey(s.fV) && otol.ContainsKey(s.sV)) { 
                            continue; }
                        if (q == s.fV) { otol.Add(s.sV, countup); vers.Add(s.sV); }
                        else if (q == s.sV) { otol.Add(s.fV, countup); vers.Add(s.fV); }
                    }
                    vers.Remove(q);
                    break;
                }
            }
            foreach (Rebro r in rebri) {
                if (!otol.ContainsKey(r.fV) && !otol.ContainsKey(r.sV)) {
                    countup++;
                    vers.Add(r.fV);
                    vers.Add(r.sV);
                    otol.Add(r.sV, countup);
                    otol.Add(r.fV, countup);
                    break;
                }
            }
        }
        foreach (KeyValuePair<string, int> a in otol) {
            Console.WriteLine("Вершина - " + a.Key);
            Console.WriteLine("Множество - " + a.Value);
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