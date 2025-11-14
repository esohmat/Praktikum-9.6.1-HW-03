using System;
public class MyCutomException : Exception
{
    public MyCutomException() : base("Произошло мое собственное исключение!") { }
    public MyCutomException(string message) : base(message) { }
    public MyCutomException(string message, Exception inerException) : base(message, inerException) { } 
}
class Program
{
    static void Main()
    {
        Exception[] exceptions = new Exception[]
        {
            new MyCutomException("Ошибка в пользовательском коде"),
            new ArgumentNullException("paramName", "Параметр не может быть null"),
            new ArgumentOutOfRangeException("index", "Индекс вне допустимого диапозона"),
            new DivideByZeroException("Попытка деления на ноль"),
            new InvalidOperationException("Недопустимая операция для текущего состояния обьекта")
        };
        foreach(var exception in exceptions)
        {
            Console.WriteLine($"Обработка исключений типа: {exception.GetType().Name}");
            Console.WriteLine(new string('-', 50));
            try
            {
                throw exception;
            }
            catch (MyCutomException ex)
            {
                Console.WriteLine($"Поймано сообщение исключение: {ex.Message}");
            }
         
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Поймано ArgumentNullException: {ex.Message}");
                Console.WriteLine($"Имя параметра: {ex.ParamName}");
            }
          
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Поймано ArgumentOutOfRangeException: {ex.Message}");
                Console.WriteLine($"Имя параметра: {ex.ParamName}");
            }
           
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Поймано DivideByZeroException: {ex.Message}");
            }
           
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Поймано InvalidOperationException: {ex.Message}");
            }

            finally
            {
                Console.WriteLine("Блок finally выполнен!");
                Console.WriteLine();

                try
                {
                    try
                    {
                        throw new MyCutomException("Внешнее исключение");
                    }
                    catch (MyCutomException ex)
                    {
                        throw new ArgumentNullException("Внутреннее исключение", ex);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Внешнее исключение: {ex.Message}");
                    if(ex.InnerException != null)
                    {
                        Console.WriteLine($"Внутренее исключение: {ex.InnerException.Message}");
                    }
                }
            }
        }
       
    }
}

