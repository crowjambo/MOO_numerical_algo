using System;

namespace correction
{
    class Program
    {
        static void Main(string[] args)
        {
            //uesd for correcting errors for rounding/using floating point numbers with computers in calculations
            Console.WriteLine("Error correction algorithm...");
            //input vars
            double a,b,x,y;
            a = Convert.ToDouble(Console.ReadLine());
            b = Convert.ToDouble(Console.ReadLine());
            x = Convert.ToDouble(Console.ReadLine());
            y = Convert.ToDouble(Console.ReadLine());


            /*
            a = 10000 exact number
            b = 9999
            x = 10012 approximate number
            y = 9995
             */
            
            //results
            double AEA, AEB, REA, REB, AE,DE;
            //absolute error of A , abs error of B, relative error of A, relative error of B, amount error, difference error


            AEA = Math.Abs(a-x);
            AEB = Math.Abs(b-y);
            REA = AEA / a;
            REB = AEB / b;
            AE = Math.Abs((a+b)-(x+y));
            DE = Math.Abs((a-b)+(x-y));

            Console.WriteLine($"Absolute error of A {AEA}\nAbsolute error of B {AEB}\nRelative error of A {REA}\nRelative error of B {REB}\nAmount error is {AE}\nDifference error {DE}\n");


        }
    }
}


