import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        ArrayList<Person> persons = new ArrayList<Person>();
        try {
            int counter = 0;
            File input = new File("input.txt");
            Scanner reader = new Scanner(input);
            while (reader.hasNextLine()) {
                if(counter % 2 == 0) {
                    String data = reader.nextLine();
                    System.out.println(data);
                    System.out.println(counter);

                }
                counter++;
                if(counter == 10){
                    break;
                }
            }
            reader.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}

class Person {
    int number;
    String name;
    ArrayList<Person> infs = new ArrayList<Person>();
}