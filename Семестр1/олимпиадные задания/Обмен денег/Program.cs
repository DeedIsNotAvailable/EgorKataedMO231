
class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("input.txt");
            int[] rate1; int[] rate2; int[] factor1; int[] factor2; int[] money2;

            try{
                string[] kurs01 = reader.ReadLine().Split(" ", 2)[1].Split(" "); rate1 = new int[kurs01.Length];
                for (int i = 0; i < kurs01.Length; i++){
                    rate1[i] = Convert.ToInt32(kurs01[i]);
                }
            } catch { rate1 = new int[1]; }
            try{
                string[] lucky01 = reader.ReadLine().Split(" ", 2)[1].Split(" "); factor1 = new int[lucky01.Length];
                for (int i = 0; i < lucky01.Length; i++){
                    factor1[i] = Convert.ToInt32(lucky01[i]);
                }
            } catch { factor1 = new int[1]; }
            try{
                string[] kurs02 = reader.ReadLine().Split(" ", 2)[1].Split(" "); rate2 = new int[kurs02.Length];
                for (int i = 0; i < kurs02.Length; i++)
                {
                    rate2[i] = Convert.ToInt32(kurs02[i]);
                }
            } catch { rate2 = new int[1]; }
            try{
                string[] lucky02 = reader.ReadLine().Split(" ", 2)[1].Split(" "); factor2 = new int[lucky02.Length];
                for (int i = 0; i < lucky02.Length; i++)
                {
                    factor2[i] = Convert.ToInt32(lucky02[i]);
                }
            } catch { factor2 = new int[1]; }
            string[] money01= reader.ReadLine().Split(" "); int[] money1 = new int[money01.Length];
            for (int i = 0; i < money1.Length; i++){
                money1[i]= Convert.ToInt32(money01[i]);
            }
            if (rate2[0] != 0) {  money2 = new int[rate2.Length + 1]; } else { money2 = new int[1]; } 


            Array.Sort(factor1); Array.Sort(factor2);Array.Reverse(factor1);

            for (int i = 0; i < money1.Length; i++){
                for(int t=0; t<factor1.Length; t++){
                    if (factor1[t] <= money1[i])
                    {
                        money1[i]--;
                    }
                }
            }
            for (int i = 0; i < money1.Length - 1; i++){
                money1[i + 1] += money1[i] * rate1[i];
            }
            money2[money2.Length-1] = money1[money1.Length-1];

            for (int i = money2.Length-1;i>0; i--){

                money2[i - 1] = money2[i] / rate2[i-1];
                money2[i] = money2[i] % rate2[i - 1];
            }

            for (int i = 0; i < money2.Length; i++){
                for (int t = 0; t < factor2.Length; t++){
                    if (factor2[t] <= money2[i]){
                        money2[i]++;
                    }
                }
            }
            for (int i = 0;i < money2.Length; i++){
                Console.Write("{0} ", money2[i]);
            }
        }
    }
