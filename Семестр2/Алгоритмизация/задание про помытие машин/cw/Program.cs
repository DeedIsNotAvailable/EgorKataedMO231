class Program
{
    delegate void Washing();
    static void Main(string[] args)
    {
        Garage gr = new Garage();
        gr.AddCar(new car("Авто 1"));
        gr.AddCar(new car("Авто 2"));
        gr.AddCar(new car("Авто 3"));
        Washing washcar;
        washcar = wash;
        washcar();
        void wash()
        {
            foreach (var car in Garage.cars)
            {
                Garage.carwash(car);
            }
        }
    }
}
public class car
{
    public string name;
    public car(string name)
    {
        this.name = name;
    }
}
class Garage
{
    static public List<car> cars = new List<car>();
    public void AddCar(car car)
    {
        cars.Add(car);
    }
    static public void carwash(car car)
    {
        Console.WriteLine($"Автомобиль {car.name} отмыт");
    }
}