import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;

public class Main {
    public static void main(String[] args) {
        Program prg = new Program();
    }
}

class Program{
    static Map<Integer, String> NumNam = new HashMap<>();
    static Map<Integer, ArrayList<Integer>> SupInf = new HashMap<>();
    static ArrayList<Integer> slaves = new ArrayList<>();

    int supNum, infNum, mainKey;
    String supName, infName, check, mainSup;
    boolean eter = false;

    Program(){
        try {
            File input = new File("input.txt");
            Scanner reader = new Scanner(input);
            while (true) {


                if (!reader.hasNextInt()){break;}



                supNum = reader.nextInt(); //Босс




                if (!reader.hasNextInt()) {
                    supName = reader.next();
                    if (!reader.hasNextInt()) { supName = supName + " " + reader.next(); }
                }else {
                    if (NumNam.get(supNum) == null){ supName = null; }
                }





                infNum = reader.nextInt();


                if (!reader.hasNextInt()) { //ужас
                    check = reader.next();
                    if(check.equals("END")){
                        infName = null;
                        eter = true;
                    }
                    else {
                        if (!reader.hasNextInt()) { //либо энд либо вторая часть имени раба
                            infName = check;
                            check = reader.next();
                            if (check.equals("END")) {
                                eter = true;
                            } else {
                                infName = infName + " " + check;
                            }
                        }
                        else {
                            infName = check;
                        }
                    }
                }else {
                    if (NumNam.get(infNum) == null){ infName = null; }
                }




                NumNam.put(supNum, supName);
                NumNam.put(infNum, infName);

                if (SupInf.containsKey(supNum)) {
                    SupInf.get(supNum).add(infNum);
                }else {
                    SupInf.put(supNum, new ArrayList<Integer>());
                    SupInf.get(supNum).add(infNum);
                }





                if (eter) { break; }
            }

            if (reader.hasNextInt()){mainKey = reader.nextInt();}
            else {
                mainSup = reader.next();
                if (reader.hasNext()) { mainSup = mainSup + " " + reader.next(); }

                mainKey = 0;

                for(Map.Entry<Integer, String> item : NumNam.entrySet()){
                    if (item.getValue() != null) {
                        if (item.getValue().equals(mainSup)) { //тут не работает вааще е сли у последнего есть имя
                            mainKey = item.getKey();
                        }
                    }
                }
            }

            reader.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        adder(mainKey);

        slaves.sort(Comparator.naturalOrder());

        try {
            File myObj = new File("output.txt");
            FileWriter myWriter = new FileWriter("output.txt");
            for (int a:
                    slaves) {
                if (NumNam.get(a) == null){myWriter.write(a + " Unknown Name");}
                else {myWriter.write(a + " " + NumNam.get(a));}
                myWriter.write("\n");
            }
            myWriter.close();
            System.out.println("Программа сработала");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    //как то рекурсия должна работать
    public void adder(int key){ // сделать проверку что не нуль ли ваще (почему то не до конца работает)
        if (SupInf.get(key) != null) {
            for (int a : SupInf.get(key)) { // это памяти съедает дай боже
                slaves.add(a);
                adder(a);
            }
        }
    } // с именами рекурсия работает, надо обработать когда там нуль, если не нуль то фиг знает
}