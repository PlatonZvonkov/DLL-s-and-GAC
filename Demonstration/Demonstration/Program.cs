using ArrayHelper;
using RectangleHelper;
using System;

namespace Demonstration
{
    internal class Program
    {
        private const string WELCOME_MSG = "WELCOME TO DEMONSTRATION APP1";
        private const string WELCOME_OPTIONS = "1 - You can calculate Rectangle square or perimeter\n 2 - So you can do operations with Arrays\n 0 - Exit";

        private static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
            //сразу выходим в динамический контекст
        }
        //
        //метод старта программы со вложенными циклами меню
        private void Start()
        {
            Console.WriteLine(WELCOME_MSG);
            while (true)
            {
                Console.WriteLine(WELCOME_OPTIONS);

                string input = Console.ReadLine();

                try
                {
                    int option = Int32.Parse(input);

                    if (option == 1)
                    {
                        RectangleLogic();
                    }
                    else if (option == 2)
                    {
                        ArraysLogic();
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        //
        //метод для демонстрации библиотеки RectangleHepler
        private void RectangleLogic()
        {
            Console.WriteLine("Enter Dimentions of Your New Rectangle: \nWidth:");
            double width = Double.NaN;
            do
            {
                string rawWidth = Console.ReadLine();
                try
                {
                    width = Double.Parse(rawWidth);
                }
                catch (Exception)
                {
                    Console.WriteLine("Parse error:");
                }
            } while (width == Double.NaN);

            Console.WriteLine("Now enter Length:");
            double length = Double.NaN;
            do
            {
                string rawLength = Console.ReadLine();
                try
                {
                    length = Double.Parse(rawLength);
                }
                catch (Exception)
                {
                    Console.WriteLine("Parse error");
                }
            } while (length == Double.NaN);

            try
            {
                Rectangle rectangle = new Rectangle(width, length);

                while (true)
                {
                    Console.WriteLine("What do you want to calculate? " +
                        "\n1 - Perimeter\n2 - Square\n0 - Exit");
                    string input = Console.ReadLine();

                    try
                    {
                        int option = Int32.Parse(input);

                        if (option == 1)
                        {
                            Console.WriteLine("Perimeter is  " + rectangle.Perimeter());
                        }
                        else if (option == 2)
                        {
                            Console.WriteLine("Square is  " + rectangle.Square());
                        }
                        else if (option == 0)
                        {
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("I cant understand you, try again:");
                    }
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //
        //метод для демонстрации библиотеки ArrayHelper
        private void ArraysLogic()
        {

            while (true)
            {
                Console.WriteLine("1 - One dimention array demo\n" +
                    "2 - Two dimention array demo\n" +
                    "0 - Exit");

                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);

                    if (option == 1)
                    {
                        OneDArrayDemo();
                    }
                    else if (option == 2)
                    {
                        TwoDArrayDemo();
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("I cant understand you, try again:");
                }
            }
        }
        //
        //расчеты сортировки по одномерному массиву
        private void OneDArrayDemo()
        {
            Console.WriteLine("\n you are given an Array of 10 random whole numbers, what do you want to do with it?");
            int[] array = RandomArray();
            foreach (var x in array)
            {
                Console.Write(x + " ");
            }

            
            while (true)
            {
                Console.WriteLine("\n1 - Sort it by Ascending" +
                    "\n2 - Sort it by Descending" +
                    "\n0 - Exit");

                string input = Console.ReadLine();
                try
                {
                    int option = Int32.Parse(input);

                    if (option == 1)
                    {
                        BubbleSort.BubbleSortBy(array);
                        foreach (var x in array)
                        {
                            Console.Write(x + " ");
                        }
                        Console.WriteLine("Sorted");
                    }
                    else if (option == 2)
                    {
                        BubbleSort.BubbleSortBy(array, BubbleSort.Direction.Desc);
                        foreach (var x in array)
                        {
                            Console.Write(x + " ");
                        }
                        Console.WriteLine("Sorted");
                    }
                    else if (option == 0)
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("I cant understand you, try again:");
                }
            }
        }
        //
        //превращение одномерного массива в многомерный и расчет положительной суммы всех элементов
        private void TwoDArrayDemo()
        {
            Console.WriteLine("\n you are given an Array of 10 random whole numbers");
            int[] array = RandomArray();
            foreach (var x in array)
            {
                Console.Write(x + " ");
            }
            
            Console.WriteLine("\nType 10 new random whole numbers: (like -1 -2 0 4 5 ...ect)");
            var input = Console.ReadLine();
            int[] newArr = new int[10];
            string[] tempArr = input.Split(' ');
            int i = 0;
            foreach (var x in tempArr)
            {
                newArr[i] = Int32.Parse(x);
                i++;
            }
            if (tempArr.Length != 10)
            {
                Console.WriteLine("Thats not 10 numbers! Returning to menu.");
            }
            else { Console.WriteLine($"\n The sum of all positive elements from random array and your" +
                $" array is: {PositiveElementSum.DoubleArrayPositSum(Merge(array, newArr))}");}
            

        }
        //
        //обьединение генерируемого массива и массива введённого пользователем
        public int[,] Merge(int[] array, int[] temparray)
        {
            int[,] newArr = new int[array.Length, temparray.Length];

            for (var i = 0; i < temparray.Length; i++)
            {
                newArr[0, i] = array[i];
                newArr[1, i] = temparray[i];
            }
            return newArr;
        }
        //
        //Генерируем случайный массив от -10 до +10
        public int[] RandomArray()
        {
            Random rnd = new Random();
            int[] array = new int[10];

            for (int number = 0; number < 10; ++number)
            {
                array[number] = rnd.Next(-10, 10);

            }
            return array;
        }

    }
}
