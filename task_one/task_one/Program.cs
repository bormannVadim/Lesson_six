using System;

namespace task_one
{

    public delegate double Fun(double x);
    public delegate double Fun2(double x, double a);

    class Program
    {
        static void Main(string[] args)
        {
            //Савенко Вадим
            // изменённая таблица передающая double double // a*x^2 

            Console.WriteLine("Таблица функции a*x^2:");
            Table(new Fun2(MyFunc), -2, 2);

            //a*sin(x
            Console.WriteLine("Таблица функции a*sin(x):");
            Table(Math.Sin, -2, 2);      // использование 2 делегатов, не уверен, что правильно, но должно работать
        
        }

        public static void Table(Fun2 F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, b*F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x)
        {
            return x * x * x;
        }

        public static double MyFunc(double x, double a)
        {
            return  a* Math.Pow(x, 2);
        }

    }
}
