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
                        ShowAdditionalTypeInfoByInput(choosenType);
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

        static void ShowAdditionalTypeInfoByInput(Type choosenType)
        {
            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
                {
                    case 'm':
                        var typeData = GetTypeData(choosenType);
                        showTypeData(choosenType, typeData);
                        break;
                    case '0':
                        StartApp();
                        break;
                }

            }
        }

        // TODO. Clean code.
        static Dictionary<string, Dictionary<string, int>> GetTypeData(Type type)
        {
            var allMethods = type.GetMethods();
            var data = new Dictionary<string, Dictionary<string, int>>();

            foreach (var method in allMethods)
            {
                int paramAmount = method.GetParameters().Length;

                if (data.ContainsKey(method.Name))
                {
                    data[method.Name]["overloads"]++;

                    if (data[method.Name]["minParamAmount"] > paramAmount)
                    {
                        data[method.Name]["minParamAmount"] = paramAmount;
                    }

                    if (data[method.Name]["maxParamAmount"] < paramAmount)
                    {
                        data[method.Name]["maxParamAmount"] = paramAmount;
                    }
                }
                else
                {
                    var methodData = new Dictionary<string, int>();
                    methodData.Add("overloads", 1);
                    methodData.Add("minParamAmount", paramAmount);
                    methodData.Add("maxParamAmount", paramAmount);
                    data.Add(method.Name, methodData);
                }
            }

            return data;
        }

        static void showTypeData(Type type, Dictionary<string, Dictionary<string, int>> data)
        {
            Console.Clear();
            int columnWidth = 20;
            Console.WriteLine(
                $"Методы типа {type} \n" +
                $"{"Название".PadRight(columnWidth)}" +
                $"{"Число перегрузок".PadRight(columnWidth)}" +
                $"{"Число параметров".PadRight(columnWidth)}"
            );
            foreach (var key in data.Keys)
            {
                Console.Write(
                    $"{key}".PadRight(columnWidth) +
                    $"{data[key]["overloads"]}".PadRight(columnWidth)
                );

                if (data[key]["minParamAmount"] == data[key]["maxParamAmount"])
                {
                    Console.Write($"{data[key]["minParamAmount"]}".PadRight(columnWidth));
                }
                else
                {
                    Console.Write($"{data[key]["minParamAmount"]}..{data[key]["maxParamAmount"]}".PadRight(columnWidth));
                }
                Console.Write("\n");
            }

            Console.WriteLine("Нажмите '0', чтобы перейти в главное меню");

            while (true)
            {
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
                {
                    case '0':
                        StartApp();
                        break;
                }
            }
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

        static void ShowSelectedTypeInfo(Type type)
        {
            string fields = string.Join(
                ", ",
                type.GetFields().Select(field => field.Name)
            );

            string properties = string.Join(
                ", ",
                type.GetProperties().Select(field => field.Name)
            );

            int elementsAmount = type.GetMethods().Length +
                type.GetProperties().Length +
                type.GetFields().Length;


            Console.Clear();
            Console.WriteLine(
                $"Информация по типу: {type} \n" +
                $"    Значимый тип: {(type.IsValueType ? '+' : '-')} \n" +
                $"    Пространство имен: {type.Namespace} \n" +
                $"    Сборка: {type.Assembly.GetName().Name} \n" +
                $"    Общее число элементов: {elementsAmount} \n" +
                $"    Число методов: {type.GetMethods().Length} \n" +
                $"    Число свойств: {type.GetProperties().Length} \n" +
                $"    Число полей: {type.GetFields().Length} \n" +
                $"    Список полей: {fields}\n" +
                $"    Список свойств: {properties}\n" +
                "\n" +
                $"Нажмите 'M' для вывода дополнительной информации по методам: \n" +
                $"Нажмите '0' для выхода в главное меню"
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
