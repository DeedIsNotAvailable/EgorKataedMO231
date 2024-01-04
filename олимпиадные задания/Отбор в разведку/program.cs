class Otbor_v_razvedky
{
    static void Main()
    {
        try
        {
            StreamReader sr = new StreamReader("\\input.txt"); //ввод
            int number = Convert.ToInt32(sr.ReadLine());
            int[] array = new int[number];
            try{
                StreamWriter sw = new StreamWriter("output.txt"); //вывод
                sw.WriteLine(div(array));
                sw.Close();
            }
            finally{
            }
            sr.Close();
        }
        finally{
        }
    }
    public static int div(int[] array){
        int sum = 0;
        int n = 0;
        int len_n = 0;
        for (; n < array.Length; n += 2){
            len_n++;
        }
        int[] odd = new int[len_n];
        int t = 0;
        for (n = 0; n < array.Length; n += 2){
            array[n] = odd[t];
            t++;
        }
        int m = 1;
        int len_m = 0;
        for (; m < array.Length; m += 2){
            len_m++;
        }
        int[] even = new int[len_m];
        t = 0;
        for (m = 1; m < array.Length; m += 2){
            array[m] = even[t];
            t++;
        }
        if (even.Length == 3){
            sum++;
        }
        if (odd.Length == 3){
            sum++;
        }
        if (odd.Length <= 3 & even.Length <= 3){
            return sum;
        }
        else{
            return div(even) + div(odd) + sum;
        }
    }
}