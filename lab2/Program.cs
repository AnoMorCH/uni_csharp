using System;

namespace SecondLab
{
    internal class Program
    {
        public class Matrix 
        {
            int rowsAmount;
            int columnsAmount;
            double[] data;

            public Matrix(int columnsAmount, int rowsAmount)
            {
                int dataLength = rowsAmount * columnsAmount;

                this.rowsAmount = rowsAmount;
                this.columnsAmount = columnsAmount;
                data = new double[dataLength];
            } 

            public double this[int columnNumber, int rowNumber]
            {
                
                get 
                {
                    int index = rowNumber * columnsAmount + columnNumber;
                    return data[index];
                }
                
                set
                {
                    int index = rowNumber * columnsAmount + columnNumber;
                    data[index] = value;
                }
            }
        }

        static int GetTaskOption(char nameFirstChar, char surnameFirstChar)
        {
            return (nameFirstChar + surnameFirstChar) % 7;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine($"Вариант - {GetTaskOption('A', 'M')}");
        }
    }
}
