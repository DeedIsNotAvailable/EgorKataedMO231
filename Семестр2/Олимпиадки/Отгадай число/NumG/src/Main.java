import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        int amount, result = 0, answer = 0;

        try {
            File fl = new File("input.txt");
            Scanner reader = new Scanner(fl);
            amount = reader.nextInt();
            int i = 0;
            String[] nums = new String[amount];
            String[] ops = new String[amount];
            while (reader.hasNextLine()){
                if(reader.hasNextInt()){
                    result = reader.nextInt();
                    break;
                }
                else {
                    ops[i] = reader.next();
                    nums[i] = reader.next();
                    i++;
                }
            }
            reader.close();

            int xN = 1;
            int nN = 0;

            for(int d = 0; d < amount; d++){
                if(ops[d].equals("+")){
                    if (nums[d].equals("x")){ xN++; }
                    else { nN += Integer.parseInt(nums[d]); }
                } else if (ops[d].equals("-")) {
                    if (nums[d].equals("x")){ xN--; }
                    else { nN -= Integer.parseInt(nums[d]); }
                } else if (ops[d].equals("*")) {
                    nN = nN * Integer.parseInt(nums[d]);
                    xN = xN * Integer.parseInt(nums[d]);
                }
            }
            answer = (result - nN) / xN;
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        try {
            File fl = new File("output.txt");
            FileWriter myWriter = new FileWriter(fl);

            myWriter.write(Integer.toString(answer));

            myWriter.close();
            System.out.println("Программа сработала");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}