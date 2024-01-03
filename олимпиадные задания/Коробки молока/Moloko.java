import java.io.File;
import java.io.FileNotFoundException;
import java.util.Locale;
import java.util.Scanner;
import java.io.FileWriter;
import java.io.IOException;

public class Moloko {
    public static void main(String[] args) {
        Integer N = 0, X1 = 0, Y1 = 0, Z1 = 0, X2 = 0, Y2 = 0, Z2 = 0;
        float C1 = 0, C2 = 0;
        //HashMap<Integer, Float> prices = new HashMap<Integer, Float>();
        float minF = 0;
        int minI = 0;
        try {
            File myObj = new File("C:\\Users\\Deed\\Desktop\\inputs\\input6.txt"); //Сюда вставить место расположения файла, с форматом .txt
            Scanner reader = new Scanner(myObj);
            reader.useLocale(Locale.US);
            N = reader.nextInt();
            float[] floats = new float[N];
            int[] ints = new int[N];
            for (int i = 0; i < N; i++) {
                X1 = reader.nextInt();
                Y1 = reader.nextInt();
                Z1 = reader.nextInt();
                X2 = reader.nextInt();
                Y2 = reader.nextInt();
                Z2 = reader.nextInt();
                C1 = reader.nextFloat();
                C2 = reader.nextFloat();
                float S1 = X1 * Y1 * 2 + X1 * Z1 * 2 + Z1 * Y1 * 2;
                float S2 = X2 * Y2 * 2 + X2 * Z2 * 2 + Z2 * Y2 * 2;
                float V1 = X1 * Y1 * Z1;
                float V2 = X2 * Y2 * Z2;
                Float price = (C1 - (S1 * C2 / S2)) / ((-1 * V2 * S1 / S2) + V1) * 1000;
                floats[i] = price;
                ints[i] = i+1;
            }
            reader.close();
            minF = floats[N-1];
            minI = ints[N-1];
            for (int i = N; i > 0; i--) {
                if (floats[i-1]<=minF){
                    minF = floats[i-1];
                    minI = ints[i-1];
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        if (minF <= 0){minF = minF * (-1);}
        String result = String.format(Locale.US,"%.2f",minF);
        System.out.println(minI + " " + result);
        try {
            FileWriter myWriter = new FileWriter("output.txt"); //Сюда вставить место куда надо отправить выходной файл, с форматом .txt
            myWriter.write(String.valueOf(minI + " " + result));
            myWriter.close();
        } catch (IOException e) {
            System.out.println("Ошибка");
            e.printStackTrace();
        }
    }
}
