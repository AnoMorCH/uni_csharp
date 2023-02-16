// TODO. Clean code.

using System;

namespace FirstLab // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }


        static void ConsoleMenuWaitInput() {
            while(true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar); 
                switch(inputedKey)
                {
                    case '1': 
                        // ShowAllTypeInfo();
                        break;
                    case '2':
                        // SelectType();
                        break;
                    case '3':
                        ChangeConsoleView();
                        break;
                    default:
                        break;
                }
            }
        }

        static void ChangeConsoleViewWaitInput() {
            while(true) 
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar); 
                switch(inputedKey)
                {
                    case '1':
                        StartApp();
                        break;
                    case '2':
                        ChangeTextColor();
                        break;
                    case '3':
                        ChangeBackgroundColor();
                        break;
                }
            }
        }

        static void ChangeTextColorByInput() {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar); 
                switch(inputedKey) 
                {
                    case '1':
                        Console.ForegroundColor = ConsoleColor.White;
                        StartApp();
                        break;
                    case '2':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        StartApp();
                        break;
                    case '3':
                        Console.ForegroundColor = ConsoleColor.Red;
                        StartApp();
                        break;
                    case '4':
                        Console.ForegroundColor = ConsoleColor.Black;
                        StartApp();
                        break;
                }
            }
        }

        static void ChangeBackgroundColorByInput() {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar); 
                switch(inputedKey) 
                {
                    case '1':
                        Console.BackgroundColor = ConsoleColor.White;
                        StartApp();
                        break;
                    case '2':
                        Console.BackgroundColor = ConsoleColor.Blue;
                        StartApp();
                        break;
                    case '3':
                        Console.BackgroundColor = ConsoleColor.Red;
                        StartApp();
                        break;
                    case '4':
                        Console.BackgroundColor = ConsoleColor.Black;
                        StartApp();
                        break;
                }
            }
        }

        static void StartApp() 
        {
            ShowConsoleMenu();
            ConsoleMenuWaitInput();
        }

        static void ChangeBackgroundColor()
        {
            ShowStandardColors();
            ChangeBackgroundColorByInput();
        }

        static void ChangeConsoleView() 
        {
            ShowChangeConsoleViewMenu();
            ChangeConsoleViewWaitInput();
        }

        static void ChangeTextColor()
        {
            ShowStandardColors();
            ChangeTextColorByInput();
        }

        static void ShowStandardColors()
        {
            Console.Clear();
            Console.WriteLine("Выберите цвет");
            Console.WriteLine("1 - Белый");
            Console.WriteLine("2 - Синий");
            Console.WriteLine("3 - Красный");
            Console.WriteLine("4 - Черный");
        }

        static void ShowConsoleMenu()
        {   
            Console.Clear();
            Console.WriteLine("Информация по типам");
            Console.WriteLine("1 - Общая информация по типам");
            Console.WriteLine("2 - Выбрать тип из списка");
            Console.WriteLine("3 - Параметры консоли");
            Console.WriteLine("0 - Выход из программы");
        }

        static void ShowChangeConsoleViewMenu() 
        {
            Console.Clear();
            Console.WriteLine("Выберите пункт");
            Console.WriteLine("1 - Вернуться в меню");
            Console.WriteLine("2 - Изменить цвет шрифта");
            Console.WriteLine("3 - Изменить цвет фона");
        }
    }
}
