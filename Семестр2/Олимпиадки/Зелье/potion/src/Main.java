import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    static ArrayList<String> casts = new ArrayList<>();

    public static void main(String[] args) {
        String mix = null, buf, start = null, end = null;
        int count = -1;
        try {
            File fl = new File("input.txt");
            Scanner reader = new Scanner(fl);
            while (reader.hasNext()) {
                if (reader.hasNextInt()){
                    if (mix == null) {
                        mix = casts.get(reader.nextInt()-1);
                    } else {
                        mix += casts.get(reader.nextInt()-1);
                    }
                }
                else {
                    buf = reader.next();
                    if (buf.equals("DUST") || buf.equals("WATER") || buf.equals("MIX") || buf.equals("FIRE")) { //добавляем в каст
                        if (count != -1) {
                            casts.add(start + mix + end);
                        }
                        mix = null;
                        switch (buf) {
                            case "DUST":
                                start = "DT";
                                end = "TD";
                                break;
                            case "WATER":
                                start = "WT";
                                end = "TW";
                                break;
                            case "MIX":
                                start = "MX";
                                end = "XM";
                                break;
                            case "FIRE":
                                start = "FR";
                                end = "RF";
                                break;
                        }
                        count++;
                    } else { //делаем микс
                        if (mix == null) {
                            mix = buf;
                        } else {
                            mix += buf;
                        }
                    }
                }
            }
            casts.add(start + mix + end);
            reader.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        try {
            File fl = new File("output.txt");
            FileWriter myWriter = new FileWriter(fl);
            myWriter.write(casts.get(count));
            myWriter.close();
            System.out.println("Программа сработала");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}