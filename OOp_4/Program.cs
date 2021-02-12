using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOp_4
{
    class Dot
    {
        private double _x;
        private double _y;
        public Dot(double xValue = 0, double yValue = 0)
        {
            _x = xValue;
            _y = yValue;
        }
        public double xCoord
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public double yCoord
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public void InputCoords(double x,double y)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть х координату: ");
                    x = Convert.ToDouble(Console.ReadLine());
                    xCoord = x;
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильно введені данні");
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Введіть y координату: ");
                    y = Convert.ToDouble(Console.ReadLine());
                    yCoord = y;
                    break;
                }
                catch
                {
                    Console.WriteLine("Неправильно введені данні");
                }
            }
        }
    }

    class Side
    {
        private double _lenght;
        public double GetSide
        {
            get
            {
                return _lenght;
            }
        }
        public double CreateSide(Dot a, Dot b)
        {
            _lenght = Math.Abs(Math.Sqrt(Math.Pow(b.xCoord - a.xCoord, 2) + Math.Pow(b.yCoord - a.yCoord, 2)));
            return _lenght;
        }
    }
    static class Triangle
    {
        public static double Area(Side ab, Side bc, Side ca)
        {
            double p = (ab.GetSide + bc.GetSide + ca.GetSide) / 2;
            return Math.Sqrt(p * (p - ab.GetSide) * (p - bc.GetSide) * (p - ca.GetSide));
        }

        public static double Perimeter(Side ab, Side bc, Side ca)
        {
            return ab.GetSide + bc.GetSide + ca.GetSide;
        }

        public static double Сircumscribed(Side ab, Side bc, Side ca)
        {

            return (ab.GetSide * bc.GetSide * ca.GetSide) / (4 * Area(ab, bc, ca));
        }

        public static double Inscribed(Side ab, Side bc, Side ca)
        {
            return Area(ab, bc, ca) / (Perimeter(ab, bc, ca) / 2);
        }
        public static void CheckTriangle(Side ab, Side bc, Side ca)
        {
            if ((ab.GetSide + bc.GetSide > ca.GetSide) && (ab.GetSide + ca.GetSide > bc.GetSide) && (bc.GetSide + ca.GetSide > ab.GetSide))
            {
                Console.WriteLine("Все добре, трикутник існує");
            }
            else
            {
                Console.WriteLine("Такий трикутник не існує, натисніть будь-яку клавішу щоб вийти");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Dot A = new Dot();
            Dot B = new Dot();
            Dot C = new Dot();
            A.InputCoords(A.xCoord, A.yCoord);
            B.InputCoords(B.xCoord, B.yCoord);
            C.InputCoords(C.xCoord, C.yCoord);
            Side AB = new Side();
            Side BC = new Side();
            Side CA = new Side();
            AB.CreateSide(A, B);
            BC.CreateSide(B, C);
            CA.CreateSide(C, A);
            Triangle.CheckTriangle(AB, BC, CA);
            Console.WriteLine($"Периметр: {Triangle.Perimeter(AB, BC, CA)}");
            Console.WriteLine($"Площа: {Triangle.Area(AB, BC, CA)}");
            Console.WriteLine($"Описаний: {Triangle.Сircumscribed(AB, BC, CA)}");
            Console.WriteLine($"Вписаний: {Triangle.Inscribed(AB, BC, CA)}");
            Console.WriteLine($"Цей рядок написано у браузері");
            Console.ReadKey();
        }
    }
}
