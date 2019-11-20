using System;

namespace TASK4_Newton_method
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            NewtonMethod equation =  new NewtonMethod();
            // Func<double,double> f = x => Math.Pow(x,3)-x-0.231;
            // //derivative
            // Func<double,double> g = x => 3*Math.Pow(x,2)-1;

            // Func<double,double> f = x => x-Math.Sin(x) - 0.25;
            // Func<double, double> g = x=> 1-Math.Cos(x);

            // Func<double,double> f = x => Math.Pow(Math.E,-x)-5*x-3;
            // Func<double,double> g = x => Math.Pow(Math.E,-x)-5;

            Func<double,double> f = x => Math.Pow(x,2)-612;
            Func<double,double> g = x => 2*x;

            //double? root = equation.ExecuteNewtonRaphson(f,g,3,0.00001);
            double? root = equation.ExecuteNewtonRaphson(f,g,24,0.05);

            watch.Stop();
            Console.WriteLine($"Root is {root}");
            System.Console.WriteLine("\nTime to run: " +watch.Elapsed.TotalMilliseconds + " milisec");
        }
    }
}
