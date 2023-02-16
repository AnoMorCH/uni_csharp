using System;

namespace FirstLab // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowConsoleMenu();
        }

        static void ShowConsoleMenu()
        {
            Console.WriteLine("Информация по типам:");
            Console.WriteLine("1 - Общая информация по типам");
            Console.WriteLine("2 - Выбрать тип из списка");
            Console.WriteLine("3 - Параметры консоли");
            Console.WriteLine("0 - Выход из программы");
        }
    }
}
