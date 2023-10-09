import java.util.Scanner;

public class Chert {
    public static void main(String[] args) {
        Scanner scn = new Scanner(System.in);
        int MaxN = scn.nextInt();                               //Ввод значения через консоль, либо убрать scn.nextInt() , и вставить желаемое значение
        int Combinations = 0;
        while (MaxN >= 1){
            for (int Z = 2; Z < Z+1; Z++) {
                if (MaxN % (Math.pow(2, Z) - 1) == 0){
                    Combinations++;
                }
                if (Math.pow(2, Z) > MaxN){break;}
            }
            Combinations++;
            MaxN--;
        }
        System.out.println(Combinations);
    }
}