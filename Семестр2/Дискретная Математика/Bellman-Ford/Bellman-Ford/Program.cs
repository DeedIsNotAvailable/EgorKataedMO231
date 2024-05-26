using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp40
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rebro[] rebra = new Rebro[15];
            rebra[0] = new Rebro("1", "3", 11);
            rebra[1] = new Rebro("1", "4", 15);
            rebra[2] = new Rebro("1", "5", 7);
            rebra[3] = new Rebro("2", "5", 14);
            rebra[4] = new Rebro("2", "6", 18);
            rebra[5] = new Rebro("3", "2", 9);
            rebra[6] = new Rebro("3", "4", 13);
            rebra[7] = new Rebro("3", "5", 7);
            rebra[8] = new Rebro("3", "6", 11);
            rebra[9] = new Rebro("3", "7", 22);
            rebra[10] = new Rebro("4", "6", 11);
            rebra[11] = new Rebro("4", "7", 16);
            rebra[12] = new Rebro("5", "6", 8);
            rebra[13] = new Rebro("5", "7", 23);
            rebra[14] = new Rebro("6", "7", 19);
            Dictionary<string, int> Ans = new Dictionary<string, int>();
            List<string> vers = new List<string>();
            foreach (Rebro proverka in rebra)
            {
                if (!vers.Contains(proverka.v1)) vers.Add(proverka.v1);
                if (!vers.Contains(proverka.v2)) vers.Add(proverka.v2);
            }
            int Count = vers.Count();
            Ans.Add(rebra[0].v1, 0);
            vers.Remove(rebra[0].v1);
            while (Ans.Count != Count)
            {
                int buffer = 0;
                string Vbuffer = null;
                foreach (Rebro s in rebra)
                {
                    if (!Ans.TryGetValue(s.v1, out int value)) continue;
                    if (Ans.ContainsKey(s.v1) && !Ans.ContainsKey(s.v2) && (buffer > (s.weight + value) || buffer == 0))
                    {
                        buffer = s.weight + value;
                        Vbuffer = s.v2;
                    }
                }
                Ans.Add(Vbuffer, buffer);
            }
            foreach (KeyValuePair<string, int> kvp in Ans)
            {
                Console.WriteLine("Вершина = {0}, Кратчайший путь = {1}", kvp.Key, kvp.Value);
            }
        }
        public class Rebro
        {
            public string v1;
            public string v2;
            public int weight;
            public Rebro(string v1, string v2, int weight)
            {
                this.v1 = v1;
                this.v2 = v2;
                this.weight = weight;
            }
        }
    }
}