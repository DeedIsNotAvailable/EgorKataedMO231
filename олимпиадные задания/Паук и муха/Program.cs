using Microsoft.VisualBasic.FileIO;

namespace muha
{
    internal class Program
    {
        const int X = 0;
        const int Y = 1;
        const int Z = 2;
        static void Main(string[] args)
        {
            string path = "\\input.txt"; //Расположение файла
            StreamReader reader = new StreamReader(path);
            string state = "none";
            bool sw = false;
            double answer = 0;
            int[] size = new int[3];
            int[] spider = new int[3];
            int[] fly = new int[3];
            size = Array.ConvertAll(reader.ReadLine().Split(' ').ToArray(), int.Parse);
            spider = Array.ConvertAll(reader.ReadLine().Split(' ').ToArray(), int.Parse);
            fly = Array.ConvertAll(reader.ReadLine().Split(' ').ToArray(), int.Parse);

            for (int i = 0; i < 3; i++) {
                if ((spider[i] == 0 && fly[i] == 0) || (spider[i] == size[i] && fly[i] == size[i])){
                    state = "easy";
                    break;
                }
                else if ((spider[i] == 0 && fly[i] == size[i]) || (spider[i] == size[i] && fly[i] == 0)){
                    state = "hard";
                }
                if (spider[i] == fly[i] && spider[i] != 0 && spider[i] != size[i]){
                    sw = true;
                }
            }
            if (state == "none"){
                state = "normal";
            }
            if (state == "easy"){
                if (sw){
                    answer = Math.Abs(spider[X] - fly[X]) + Math.Abs(spider[Y] - fly[Y]) + Math.Abs(spider[Z] - fly[Z]);
                }
                else{
                    answer = Math.Sqrt(Math.Pow(Math.Abs(spider[X] - fly[X]), 2) + Math.Pow(Math.Abs(spider[Y] - fly[Y]), 2) + Math.Pow(Math.Abs(spider[Z] - fly[Z]), 2));
                }
            }
            else if (state == "normal"){
                if (sw){
                    answer = Math.Abs(spider[X] - fly[X]) + Math.Abs(spider[Y] - fly[Y]) + Math.Abs(spider[Z] - fly[Z]);
                }
                else{
                    int spiderSide = -1;
                    int flySide = -1;
                    int otherSide = -1;
                    for (int i = 0; i < 3; i++){
                        if ((spider[i] == 0 || spider[i] == size[i]) && spiderSide == -1){
                            spiderSide = i;
                        }
                        else if ((fly[i] == 0 || fly[i] == size[i]) && flySide == -1){
                            flySide = i;
                        }
                        else{
                            otherSide = i;
                        }
                    }
                    answer = Math.Sqrt(Math.Pow(Math.Abs(spider[flySide] - fly[flySide]) + Math.Abs(spider[spiderSide] - fly[spiderSide]), 2) + Math.Pow(Math.Abs(spider[otherSide] - fly[otherSide]), 2));
                }
            }
            else if (state == "hard"){
                bool just_HARDLine = false;
                int common_Side = -1;
                int[] other_Side = new int[2];
                for (int i = 0, n = 0; i < 3; i++){
                    if (((spider[i] == 0 && fly[i] == size[i]) || (spider[i] == size[i] && fly[i] == 0)) && common_Side == -1){
                        common_Side = i;
                    }
                    else {
                        other_Side[n++] = i;
                    }
                }
                if ( spider[other_Side[0]] == fly[other_Side[0]] && spider[other_Side[1]] == fly[other_Side[1]]) just_HARDLine = true;

                double[] paths = new double[4];
                paths[0] = size[common_Side] + (size[other_Side[0]] - spider[other_Side[0]]) + (size[other_Side[0]] - fly[other_Side[0]]);
                paths[1] = size[common_Side] + spider[other_Side[0]] + fly[other_Side[0]];
                paths[2] = size[common_Side] + (size[other_Side[1]] - spider[other_Side[1]]) + (size[other_Side[1]] - fly[other_Side[1]]);
                paths[3] = size[common_Side] + spider[other_Side[1]] + fly[other_Side[1]];

                if (just_HARDLine){
                    answer = paths[0];
                    for (int i = 1; i < 4; i++) {answer = Math.Min(answer, paths[i]);}
                }
                else{
                    paths[0] = Math.Sqrt(Math.Pow(paths[0], 2) + Math.Pow(Math.Abs(spider[other_Side[1]] - fly[other_Side[1]]), 2));
                    paths[1] = Math.Sqrt(Math.Pow(paths[1], 2) + Math.Pow(Math.Abs(spider[other_Side[1]] - fly[other_Side[1]]), 2));
                    paths[2] = Math.Sqrt(Math.Pow(paths[2], 2) + Math.Pow(Math.Abs(spider[other_Side[0]] - fly[other_Side[0]]), 2));
                    paths[3] = Math.Sqrt(Math.Pow(paths[3], 2) + Math.Pow(Math.Abs(spider[other_Side[0]] - fly[other_Side[0]]), 2));
                    answer = paths[0];
                    for (int i = 1; i < 4; i++){answer = Math.Min(answer, paths[i]);}
                }
            }
            Console.WriteLine(Math.Round(answer, 3));
        }
    }
}