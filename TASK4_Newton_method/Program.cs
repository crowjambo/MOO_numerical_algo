using System;

namespace TASK4_Newton_method
{
    class Program
    {
        static void Main(string[] args)
        {
            NewtonMethod equation =  new NewtonMethod();
            Func<double,double> f = x => Math.Pow(x,3)-x-0.231;
            //derivative
            Func<double,double> g = x => 3*Math.Pow(x,2)-1;
            double? root = equation.ExecuteNewtonRaphson(f,g,3,0.00001);

            Console.WriteLine($"Root is {root}");
        }
    }
}
