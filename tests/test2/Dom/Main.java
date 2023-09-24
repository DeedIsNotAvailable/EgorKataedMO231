import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;
import java.io.FileWriter;
import java.io.IOException;

public class Main
{
    public static void main(String[] args) {
        int x = 0;
        int y = 0;
        int l = 0;
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int c4 = 0;
        int c5 = 0;
        int c6 = 0;

        try {
            File myObj = new File("C:\\Users\\Deed\\Desktop\\inputs\\input_s1_01.txt"); //Сюда вставить место расположения файла, с форматом .txt
            Scanner reader = new Scanner(myObj);
            x = reader.nextInt();
            y = reader.nextInt();
            l = reader.nextInt();
            c1 = reader.nextInt();
            c2 = reader.nextInt();
            c3 = reader.nextInt();
            c4 = reader.nextInt();
            c5 = reader.nextInt();
            c6 = reader.nextInt();
            reader.close();
        } catch (FileNotFoundException e) {
            System.out.println("Ошибка");
            e.printStackTrace();
        }

        int MinPrice = 0;
        int LongWall = Math.max(x, y);
        int ShortWall = Math.min(x, y);
        int LO = l - LongWall;
        int LeftOver = 0;

        int POBANW = c4 + c5;
        int POBWUOM = c2 + c3;
        int PODAWABUNM = c2 + c4 + c5 + c6;

        //не оптимизированно
        int POANW = (2 * (ShortWall + LongWall) - l) * POBANW;
        int P1 = ((2 * ShortWall) + LongWall) * POBANW;
        int P2 = ((2 * ShortWall) + LongWall - LO) * POBANW;
        if (P2 < 0){P2 = 0;}
        if (LO > (2 * ShortWall) + LongWall){
            LeftOver = LO - ((2 * ShortWall) + LongWall);
            LO = (2 * ShortWall) + LongWall;}

        boolean IsRedWallLonger = l > LongWall;
        boolean IsRestotingTheBest = c1 < POBWUOM & c1 < POBANW;
        boolean IsBuildigUsingOMTheBest = POBWUOM < PODAWABUNM;

        boolean IsBlack = PODAWABUNM < c1 & PODAWABUNM < POBWUOM;
        boolean IsRed = c1 < PODAWABUNM & c1 < POBWUOM;
        boolean IsOrange = POBWUOM < c1 & POBWUOM < PODAWABUNM;
        boolean IsAppendixOrange = POBWUOM < PODAWABUNM;

        if (IsRedWallLonger) {
            if (IsBlack){
                if(IsAppendixOrange){
                    MinPrice = P2 + POBWUOM * LO + PODAWABUNM * LongWall + LeftOver * (c6 + c2);
                }else {
                    MinPrice = P1 + PODAWABUNM * LongWall + (LO + LeftOver) * (c6 + c2);
                }
            } else if (IsRed) {
                if(IsAppendixOrange){
                    MinPrice = P2 + POBWUOM * LO + c1 * LongWall + LeftOver * (c6 + c2);
                }else {
                    MinPrice = P1 + c1 * LongWall + LO * (c6 + c2);
                }
            } else if (IsOrange) {
                if(IsAppendixOrange){
                    MinPrice = P2 + POBWUOM * LO + POBWUOM * LongWall + LeftOver * (c6 + c2);
                }else {
                    MinPrice = P1 + POBWUOM * LongWall + LO * (c6 + c2);
                }
            }
        }
        else {
            if (IsRestotingTheBest){
                MinPrice = POANW + l * c1;
            } else if (IsBuildigUsingOMTheBest) {
                MinPrice = POANW + l * POBWUOM;
            } else {
                MinPrice = POANW + l * PODAWABUNM;
            }
        }

        System.out.println(MinPrice);

        try {
            FileWriter myWriter = new FileWriter("output.txt"); //Сюда вставить место куда надо отправить выходной файл
            myWriter.write(String.valueOf(MinPrice));
            myWriter.close();
        } catch (IOException e) {
            System.out.println("Ошибка");
            e.printStackTrace();
        }
    }
}