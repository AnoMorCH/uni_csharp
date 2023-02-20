// TODO. Think about separating the project on multiple files to improve readability.

using System.Numerics;

namespace FirstLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartApp();
        }

        static void StartApp()
        {
            ShowConsoleMenu();
            ConsoleMenuByInput();
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
                Type choosenType = null;
                char inputedKey = char.ToLower(Console.ReadKey().KeyChar);
                switch (inputedKey)
                {
                    case '1':
                        choosenType = typeof(uint);
                        break;
                    case '2':
                        choosenType = typeof(int);
                        break;
                    case '3':
                        choosenType = typeof(long);
                        break;
                    case '4':
                        choosenType = typeof(float);
                        break;
                    case '5':
                        choosenType = typeof(double);
                        break;
                    case '6':
                        choosenType = typeof(char);
                        break;
                    case '7':
                        choosenType = typeof(string);
                        break;
                    case '8':
                        choosenType = typeof(Vector);
                        break;
                    case '9':
                        choosenType = typeof(Matrix4x4);
                        break;
                    case '0':
                        StartApp();
                        break;
                }

                if (choosenType is not null) {
                    ShowSelectedTypeInfo(choosenType);
                    ShowAdditionalTypeInfoByInput(choosenType);
                }
            }
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
                        ShowTypeData(choosenType, typeData);
                        GoHomeByInput();
                        break;
                    case '0':
                        StartApp();
                        break;
                }

            }
        }

        static void GoHomeByInput()
        {
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

        static Dictionary<string, Dictionary<string, int>> GetTypeData(Type type)
        {
            void UpdateExistingParameter(
                int paramAmount, 
                Dictionary<string, Dictionary<string, int>> data,
                System.Reflection.MethodInfo method
            )
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

            void AddAnotherParameter(
                int paramAmount, 
                Dictionary<string, Dictionary<string, int>> data,
                System.Reflection.MethodInfo method
            ) {
                var methodData = new Dictionary<string, int>();
                methodData.Add("overloads", 1);
                methodData.Add("minParamAmount", paramAmount);
                methodData.Add("maxParamAmount", paramAmount);
                data.Add(method.Name, methodData);
            }

            var data = new Dictionary<string, Dictionary<string, int>>();
            var allMethods = type.GetMethods();

            foreach (var method in allMethods)
            {
                int paramAmount = method.GetParameters().Length;

                if (data.ContainsKey(method.Name))
                {
                    UpdateExistingParameter(paramAmount, data, method);
                }
                else
                {
                    AddAnotherParameter(paramAmount, data, method);
                }
            }

            return data;
        }

        static void ShowTypeData(Type type, Dictionary<string, Dictionary<string, int>> data)
        {
            bool DoesMethodHaveOnlyOneParam(string key)
            {
                return data[key]["minParamAmount"] == data[key]["maxParamAmount"];
            }

            void ShowHeader(int columnWidth) {
                string header = $"Методы типа {type} \n" +
                    $"{"Название".PadRight(columnWidth)}" +
                    $"{"Число перегрузок".PadRight(columnWidth)}" +
                    $"{"Число параметров".PadRight(columnWidth)}";

                Console.WriteLine(header);
            }

            void ShowData(int columnWidth)
            {
                foreach (string param in data.Keys)
                {
                    string paramName = $"{param}".PadRight(columnWidth);
                    string overloadsAmount = $"{data[param]["overloads"]}".PadRight(columnWidth);
                    string paramsAmount = "";

                    if (DoesMethodHaveOnlyOneParam(param))
                    {
                        paramsAmount = $"{data[param]["minParamAmount"]}".PadRight(columnWidth);
                    }
                    else
                    {
                        paramsAmount = $"{data[param]["minParamAmount"]}" +
                            ".." +
                            $"{data[param]["maxParamAmount"]}".PadRight(columnWidth);
                    }

                    string paramData = paramName + overloadsAmount + paramsAmount;
                        
                    Console.Write($"{paramData} \n");
                }
            }

            Console.Clear();
            int columnWidth = 30;
            ShowHeader(columnWidth);
            ShowData(columnWidth);
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
            Console.WriteLine(
                "Информация по типам \n" +
                "Выберите тип: \n" +
                "--------------------------- \n" +
                "    1 - uint \n" +
                "    2 - int \n" +
                "    3 - long \n" +
                "    4 - float \n" +
                "    5 - double \n" +
                "    6 - char \n" +
                "    7 - string \n" +
                "    8 - Vector \n" +
                "    9 - Matrix \n" +
                "    0 - Выход в главное меню"
            );
        }

        static void ShowStandardColors()
        {
            Console.Clear();
            Console.WriteLine(
                "Выберите цвет \n" +
                "1 - Белый \n" +
                "2 - Синий \n" +
                "3 - Красный \n" +
                "4 - Черный \n"
            );
        }

        static void ShowConsoleMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Информация по типам \n" +
                "1 - Общая информация по типам \n" +
                "2 - Выбрать тип из списка \n" +
                "3 - Параметры консоли \n" +
                "0 - Выход из программы \n"
            );
        }

        static void ShowChangeConsoleViewMenu()
        {
            Console.Clear();
            Console.WriteLine(
                "Выберите пункт \n" +
                "1 - Вернуться в меню \n" +
                "2 - Изменить цвет шрифта \n" +
                "3 - Изменить цвет фона \n"
            );
        }
    }
}
