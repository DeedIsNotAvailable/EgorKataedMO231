class chetn
{
    static void Main()
    {
        int[] arr = { 544, 1, 0, 24, 144, 57, 146, 10, 51, 11111, 14789, 12345678, 123456789, 951473, 24578 };
        int[] Nums = arr.Where(n => n % 2 == 0).ToArray();
        for (int i = 1; i < Nums.Length; i += 2)
        {
            Nums[i] = 2;
        }
        int[] ans = Nums.Where(n => n % 2 == 0).ToArray();

        foreach (int num in ans)
        {
            Console.WriteLine(num);
        }
    }
}