using System;

namespace task3_half_cut_bisection
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            Bisection equations = new Bisection();

            //function
            // Func<double,double> f = x => Math.Pow(Math.E,-2*x)+2*Math.Pow(x,2)-2;
            //Func<double,double> f = x => Math.Pow(x,3)+3*Math.Pow(x,2)-3;
            //Func<double,double> f = x => Math.Pow(Math.E,-2*x)+2*Math.Pow(x,2)-2;
            Func<double,double> f = x => Math.Pow(Math.E,-x)-5*x-3;

            // double? root = equations.ExecuteBisectionMethod(f,0,1,0.001);
            double? root = equations.ExecuteBisectionMethod(f,-1,1,0.05);


            watch.Stop();
            Console.WriteLine($"Root value: {root}");
            System.Console.WriteLine("\nTime to run: " +watch.Elapsed.TotalMilliseconds + " milisec");

           
        }
    }
}
