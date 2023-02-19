// TODO. Try DRY as Denis've done.
// TODO. Add 'default' value for methods with 'ByInput' keyword.

using System;

namespace FirstLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }


        static void ConsoleMenuByInput()
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
                {
                    case '1':
                        // ShowAllTypeInfo();
                        break;
                    case '2':
                        SelectType();
                        break;
                    case '3':
                        ChangeConsoleView();
                        break;
                    default:
                        break;
                }
            }
        }

        static void ChangeConsoleViewByInput()
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
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

        static void ChangeTextColorByInput()
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
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

        static void ChangeBackgroundColorByInput()
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
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

        static void ShowTypeInfoByInput()
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
                {
                    case '1':
                        Type choosenType = typeof(int);
                        ShowSelectedTypeInfo(choosenType);
                        break;
                    case '0':
                        StartApp();
                        break;
                }
            }
        }

        static void StartApp()
        {
            ShowConsoleMenu();
            ConsoleMenuByInput();
        }

        static void SelectType()
        {
            ShowStandardTypes();
            ShowTypeInfoByInput();
        }

        static void ChangeBackgroundColor()
        {
            ShowStandardColors();
            ChangeBackgroundColorByInput();
        }

        static void ChangeConsoleView()
        {
            ShowChangeConsoleViewMenu();
            ChangeConsoleViewByInput();
        }

        static void ChangeTextColor()
        {
            ShowStandardColors();
            ChangeTextColorByInput();
        }

        static void ShowSelectedTypeInfo(Type choosenType)
        {
            string fields = string.Join(
                ", ",
                choosenType.GetFields().Select(field => field.Name)
            );

            string properties = string.Join(
                ", ",
                choosenType.GetProperties().Select(field => field.Name)
            );

            int elementsAmount = choosenType.GetMethods().Length +
                choosenType.GetProperties().Length +
                choosenType.GetFields().Length;
            

            Console.Clear();
            Console.WriteLine(
                $"Информация по типу: {choosenType} \n" +
                $"    Значимый тип: {(choosenType.IsValueType ? '+' : '-')} \n" +
                $"    Пространство имен: {choosenType.Namespace} \n" +
                $"    Сборка: {choosenType.Assembly.GetName().Name} \n" +
                $"    Общее число элементов: {elementsAmount} \n" +
                $"    Число методов: {choosenType.GetMethods().Length} \n" +
                $"    Число свойств: {choosenType.GetProperties().Length} \n" +
                $"    Число полей: {choosenType.GetFields().Length} \n" +
                $"    Список полей: {fields}\n" +
                $"    Список свойств: {properties}\n" 
            );
        }

        static void ShowStandardTypes()
        {
            Console.Clear();
            Console.WriteLine("Информация по типам");
            Console.WriteLine("Выберите тип:");
            Console.WriteLine("---------------------------");
            Console.WriteLine("    1 - uint");
            Console.WriteLine("    2 - int");
            Console.WriteLine("    3 - long");
            Console.WriteLine("    4 - float");
            Console.WriteLine("    5 - double");
            Console.WriteLine("    6 - char");
            Console.WriteLine("    7 - string");
            Console.WriteLine("    8 - Vector");
            Console.WriteLine("    9 - Matrix");
            Console.WriteLine("    0 - Выход в главное меню");
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
