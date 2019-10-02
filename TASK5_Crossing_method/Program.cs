using System;

namespace TASK5_Crossing_method
{
    class Program
    {
        static void Main(string[] args)
        {

            CrossingMethod equation = new CrossingMethod();
            Func<double,double> f = x => Math.Pow(x,3)-x-0.231;
            //derivative
            Func<double,double> g = x => 3*Math.Pow(x,2)-1;

            double? root = equation.ExecuteNewCrossing();

            Console.WriteLine($"Root is {root}");
        }
    }
}
