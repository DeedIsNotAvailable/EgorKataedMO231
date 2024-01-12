class Program
{
    static void Main(string[] args)
    {
        int a = 106732567;
        int b = 152673836;
        double result_a = Math.Pow(a, 0.25);
        double result_b = Math.Pow(b, 0.25);
        int a_c = Convert.ToInt32(Math.Floor(result_a));
        int b_c = Convert.ToInt32(Math.Floor(result_b));
        for (int i = a_c + 1; i <= b_c; i++)
        {
            for (int k = 2; k <= i - 1; k++)
            {
                if (i % k == 0)
                {
                    break;
                }
            }
            Console.WriteLine("Число: " + Math.Pow(i, 4) + " Наибольший нетривиальный делитель : " + Math.Pow(i, 3));
        }
    }
}