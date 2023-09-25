using System;
class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("количество элементов в последовательности");
        int N = Convert.ToInt32(Console.ReadLine());

        int nBuffer = Convert.ToInt32(Console.ReadLine());

        int counter1 = 0;
        int counter1Buffer1 = 0;
        int counter1Buffer2 = 0;
        int counter1Buffer3 = 0;

        bool statement1 = true;

        int counter2 = 0;
        int counter2Buffer1 = 0;
        int counter2Buffer3 = 0;

        bool statement2 = true;
        


        for (int i = 2; i < N+1; i++)
        {
            int n = Convert.ToInt32(Console.ReadLine());


            // одинаковые элементы
            if (n == nBuffer)
            {
                counter1++;
            }
            else
            {
                if (counter1Buffer1 == 0)
                {
                    counter1Buffer1 = counter1;
                    counter1Buffer3 = counter1;
                }
                else
                {
                    if (counter1 < counter1Buffer1)
                    {
                        counter1Buffer3 = counter1;
                        counter1Buffer1 = counter1;
                    }
                }
                counter1 = 0;
            }


            // кратность
            if(statement1 == true)
            {
                if((n % i) != 0)
                {
                    statement1 = false;
                }
            }


            // разные элементы
            if (n != nBuffer)
            {
                counter2++;
            }
            else
            {
                if (counter2Buffer1 == 0)
                {
                    counter2Buffer1 = counter2;
                    counter2Buffer3 = counter2;
                }
                else
                {
                    if (counter2 > counter2Buffer1)
                    {
                        counter2Buffer3 = counter2;
                        counter2Buffer1 = counter2;
                    }
                }
                counter2 = 0;
            }


            // убывание
            if(statement2 == true)
            {
                /*if ((n + 1) != nBuffer)
                {
                    statement2 = false;
                }*/

                if (n >= nBuffer)
                {
                    statement2 = false;
                }
            }

            nBuffer = n;
        }




        if (counter1 < counter1Buffer3 & counter1 != 0)
        {
            counter1++;
            Console.WriteLine("Наименьшая длинна подпоследовательности из одинаковых элемов " + counter1);
        }
        else
        {
            counter1Buffer3++;
            Console.WriteLine("Наименьшая длинна подпоследовательности из одинаковых элемов " + counter1Buffer3);
        }




        Console.WriteLine("Все ли кратны своему номеру " + statement1);




        if (counter2 > counter2Buffer3)
        {
            counter2++;
            Console.WriteLine("Наибольшая длинна последовательности из разных элементов " + counter2);
        }
        else
        {
            counter2Buffer3++;
            Console.WriteLine("Наибольшая длинна последовательности из разных элементов " + counter2Buffer3);
        }




        Console.WriteLine("Является ли последовательность увыбвающей " + statement2);
    }
}