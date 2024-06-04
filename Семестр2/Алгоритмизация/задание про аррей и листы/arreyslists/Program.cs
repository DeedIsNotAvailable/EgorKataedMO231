using System.Collections;

class Program
{
    static void Main()
    {
        // Array
        Console.WriteLine("Для Array\n");
        int[] array = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
        Console.WriteLine("Первоначальный массив: " + string.Join(", ", array));
        Array.Sort(array);
        Console.WriteLine("Сортированный массив: " + string.Join(", ", array));
        Console.WriteLine("Бинарный поиск индекса 9(требуется предварительная сортировка): " + Array.BinarySearch(array, 9));
        Console.WriteLine("Общее кол-во: " + array.Length);
        Console.WriteLine("Индекс для 4: " + Array.IndexOf(array, 4));
        Console.WriteLine("Индекс для 0, его нет, возврат отрицательной единицы: " + Array.IndexOf(array, 0));
        int[] copy = new int[array.Length];
        Array.Copy(array, copy, array.Length);
        Console.WriteLine("Копия: " + string.Join(", ", copy));
        Array.Reverse(array);
        Console.WriteLine("Ревёрс: " + string.Join(", ", array));
        Console.WriteLine("Индекс с конца от 1: " + Array.LastIndexOf(array, 1));
        Array.Resize(ref array, 10);
        Console.WriteLine("Увеличение длинны массива до 10: " + array.Length);
        Console.WriteLine("первый найденный четный элемент: " + Array.Find(array, x => x % 2 == 0));

        // ArrayList
        Console.WriteLine("\nДля ArrayList\n");
        ArrayList arrayList = new ArrayList(array);
        Console.WriteLine("Первоначальный ArrayList: " + string.Join(", ", arrayList.ToArray()));
        arrayList.Add(7);
        Console.WriteLine("Добавлнеие 7 в лист: " + string.Join(", ", arrayList.ToArray()));
        arrayList.Insert(2, 0);
        Console.WriteLine("Добавлнеие во 2 индекс 0: " + string.Join(", ", arrayList.ToArray()));
        arrayList.Sort();
        Console.WriteLine("Сортировка: " + string.Join(", ", arrayList.ToArray()));
        arrayList.CopyTo(2, array, 0, 3);
        Console.WriteLine("Копирование начинается с 2 индекса листа в массив с 0 индекса в количестве 3 раз: " + string.Join(", ", array));
        Console.WriteLine("Бинарный поиск индекса 7: " + arrayList.BinarySearch(7));
        arrayList.Reverse();
        Console.WriteLine("Ревёрс: " + string.Join(", ", arrayList.ToArray()));
        Console.WriteLine("Индекс 9: " + arrayList.IndexOf(9));
        Console.WriteLine("Общее кол-во: " + arrayList.Count);

        // SortedList
        Console.WriteLine("\nДля SortedList\n");
        SortedList sortedList = new SortedList();
        sortedList.Add(3, "Three");
        sortedList.Add(1, "One");
        sortedList.Add(2, "Two");
        Console.WriteLine("Оригинальный вид SortedList\n");
        for (int i = 0; i < sortedList.Count; i++)
        {
            Console.WriteLine("{0} : {1}", sortedList.GetKey(i), sortedList.GetByIndex(i));
        }

        Console.WriteLine("Ключ 1 индеса: " + sortedList.GetKey(1));
        Console.WriteLine("Значение от ключа 1 индекса: " + sortedList.GetByIndex(1));
        Console.WriteLine("Индекс ключа 2: " + sortedList.IndexOfKey(2));
        Console.WriteLine("Индекс значения Three: " + sortedList.IndexOfValue("Three"));
    }
}