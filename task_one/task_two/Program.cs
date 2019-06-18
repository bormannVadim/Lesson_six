using System;
using System.IO;

namespace task_two
{
    class Program
    {
        //Савенко Вадим 
        // Модификация программы вывода минимума функции

        public delegate double Function(double x);

        public static double ChouseF(Function fn,double x)
        {
            return fn(x);
        }

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x - 100 * x + 20;
        }

        public static double F3(double x)
        {
            return x * x - 200 * x + 30;
        }

        public static void SaveFunc(Function fn, string fileName, double a, double b, double h)
        {
            // создание и запись в файл
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(fn(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        public static double Load(string fileName)
        {
            // чтение из файла
            // и вывод на экран

            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Введите начальное значение отрезка:");
                double x1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Введите окончание отрезка значение отрезка:");
                double x2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Выберите опцию от 1 до 3...");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        SaveFunc(F, "data.bin", x1, x2, 0.5);
                        break;
                    case 2:
                        SaveFunc(F2, "data.bin", x1, x2, 0.5);
                        break;
                    case 3:
                        SaveFunc(F3, "data.bin", x1, x2, 0.5);
                        break;
                    default:
                        Console.WriteLine("Функция не найдена...\nПопробуйте ещё раз...");
                        break;
                }
                Console.WriteLine(Load("data.bin"));
            }
        }
    }

}
