using System;

namespace task3_half_cut_bisection
{
    class Program
    {
        static void Main(string[] args)
        {
            Bisection equations = new Bisection();

            //function
            Func<double,double> f = x => Math.Pow(Math.E,-2*x)+2*Math.Pow(x,2)-2;
            
            double? root = equations.ExecuteBisectionMethod(f,0,1,0.001);

            Console.WriteLine($"Root value: {root}");

           
        }
    }
}
