using System;
using System.Collections.Generic;
public class InvalidOptionException : Exception
{
public InvalidOptionException() : base("Необходимый вариант сортировки. Допустимые значения: 1 или 2") { }
    public InvalidOptionException(string message) : base(message) { }
}
public class SurNameManager
{
    private List<string> surnames;
    public event Action<int> SortRequested;
    public SurNameManager()
    {
        surnames = new List<string>
        {
            "Иванов",
            "Петров",
            "Сидоров",
            "Кузнецов",
            "Смирнов",
        };
    }
    public void DisplaySurnames()
    {
        Console.WriteLine("\n Текущий список фамилий:");

        for (int i = 0; i < surnames.Count; i++)
            {
            Console.WriteLine($"{i + 1}. {surnames[i]}");
        }
        Console.WriteLine();
    }
    public void RequestSort (int sortOption)
    {
        SortRequested?.Invoke(sortOption);
    }
    private void PerformSort(int sortOption)
    {
        switch (sortOption)
        {
            case 1:
                surnames.Sort();
        Console.WriteLine("Список отсортирован по возрастанию (А-Я)");
        break;

            case 2:
                surnames.Sort();
        surnames.Reverse();
        Console.WriteLine("Список отсортирован по убыванию (Я-А)");
        break;
    }
    }
public void Initialize()
{
        SortRequested += PerformSort;
    }
}
class Program
{
    static void Main(string[] args)
    {
        SurNameManager manager = new SurNameManager();
        manager.Initialize();

        Console.WriteLine("Программа для сортировки списка фамилий");
        Console.WriteLine("Исходный список");
        manager.DisplaySurnames();

        while (true)
        {
            try
            {

                Console.WriteLine("Выберите вариант сортировки:");
                Console.WriteLine("1 - Сортировка А-Я (по возрастанию)");
                Console.WriteLine("2 - Сортировка Я - А (по убыванию)");
                Console.WriteLine("0 - Выход из программы:");

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Программа завершена.");
                    break;
                }
                if (!int.TryParse(input, out int sortOption))
                {
                    throw new InvalidOptionException("Введено не числовое значение.");
                }
                if (sortOption != 1 && sortOption != 2)
                {
                    throw new InvalidOptionException();
                }
                manager.RequestSort(sortOption);
                manager.DisplaySurnames();
            }
            catch (InvalidOptionException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("--------------------");
            }
        }
        Console.WriteLine("Нажмити любую клавишу для выхода...");
        Console.ReadKey();
    }
}

