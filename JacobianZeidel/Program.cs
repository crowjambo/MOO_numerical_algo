using System;
using System.Collections.Generic;
using System.Linq;

namespace IterativeSolutions
{
    class Program
    {
        //compare jacobian vs zeidel speed etc.


        // jacobian solution
        public static double[] JacobianSolution(double[][] inputMatrix, double precision){
            // double x1 = 0;
            List<double> x1 = new List<double>();
            List<double> x2 = new List<double>();
            List<double> x3 = new List<double>();
            x1.Add(0);
            x2.Add(0);
            x3.Add(0);
            double calcResult;
            double calcResult1;
            double calcResult2;

            // double x2 =0;
            // double x3 = 0;
            // double tempx1 = 0;
            // double tempx2 = 0;
            // double tempx3 = 0;
            int i = 0;
            bool found = false;
            //some loop while, do epsilon check here
            System.Console.WriteLine("JACOBIAN");
            while(!found){

                //problem with writing the proper equation due to - + signs!!! fucks shit up
                //if [0][1] = - sign in front, it needs to be multiplied by -1 to maintain negative and not turn into +
                //same for [2][1] or [1][1](if it were a negative number, needs to be multiplied by -1)
                if(inputMatrix[0][1] < 0){
                    inputMatrix[0][1] *= -1;
                }
                if(inputMatrix[1][1] < 0){
                    inputMatrix[1][1] *= -1;
                }
                if(inputMatrix[2][1] < 0){
                    inputMatrix[2][1] *= -1;
                }

                calcResult = inputMatrix[0][0] * x2[i] - (inputMatrix[0][1] * x3[i]) + inputMatrix[0][2];
                x1.Add(calcResult);
                calcResult1 = inputMatrix[1][0] * x1[i] - inputMatrix[1][1] *x3[i] + inputMatrix[1][2];
                x2.Add(calcResult1);
                calcResult2 = inputMatrix[2][0] * x1[i] - (inputMatrix[2][1] * x2[i]) + inputMatrix[2][2];
                x3.Add(calcResult2); 
                //calc with current values
                // tempx1 = x1;
                // tempx2 = x2; 
                // tempx3 = x3; 
                // //iterat 1 x1=1.1 x2= 2.25 x3= 1.4
                // //iterat2 x1=0.905 x2=1.93 x3=0.955
                // x1 = (0.1 * tempx2) - (-0.3 * tempx3) + 1.1;
                // x2 = (-0.1 * tempx1) - (-0.3 * tempx3) + 2.25;
                // x3 = (-0.2 * tempx1) - (2.25 * tempx2) + 1.4;
                // x1 = (inputMatrix[0][0] * tempx2) - (inputMatrix[0][1] * tempx3) + inputMatrix[0][2];
                // x2 = (inputMatrix[1][0] * tempx1) - (inputMatrix[1][1] * tempx3) + inputMatrix[1][2];
                // x3 = (inputMatrix[2][0] * tempx1) - (inputMatrix[2][1] * tempx2) + inputMatrix[2][2];

                // System.Console.WriteLine($"Iteration {i} x1 = {x1} x2 = {x2} x3 = {x3}");

                i++;
                System.Console.WriteLine($"Iteration {i} x1 = {x1[i]} x2 = {x2[i]} x3 = {x3[i]}");
                //final precision check
                if(Math.Abs(x1[i] - x1[i-1]) < precision && Math.Abs(x2[i] - x2[i-1]) < precision && Math.Abs(x3[i] - x3[i-1]) < precision){
                    found = true;
                }
                // if(Math.Abs(tempx1-x1) < precision && Math.Abs(tempx2-x2) < precision && Math.Abs(tempx3-x3) < precision){
                //     found = true;
                // }
            }



            double[] results = new double[3];
            results[0] = x1[i];
            results[1] = x2[i];
            results[2] = x3[i];
            //return all x values in array
            return results;

        }

        //zeidels solution
        public static double[] ZeidelSolution(double[][] inputMatrix, double precision){
            double x1 = 0;
            double x2 =0;
            double x3 = 0;
            double tempx1 = 0;
            double tempx2 = 0;
            double tempx3 = 0;
            int i = 1;
            bool found = false;
            //some loop while, do epsilon check here
            System.Console.WriteLine("ZEIDEL");
            while(!found){
                //save previous values
                tempx1 = x1; tempx2 = x2; tempx3 = x3;
                //calc with current values
                x1 = inputMatrix[0][0] * x2 - inputMatrix[0][1] * x3 + inputMatrix[0][2];
                x2 = inputMatrix[1][0] * x1 - inputMatrix[1][1] * x3 + inputMatrix[1][2];
                x3 = inputMatrix[2][0] * x1 - inputMatrix[2][1] * x2 + inputMatrix[2][2];

                System.Console.WriteLine($"Iteration {i} x1 = {x1} x2 = {x2} x3 = {x3}");

                i++;
                //final precision check
                if(Math.Abs(tempx1-x1) < precision && Math.Abs(tempx2-x2) < precision && Math.Abs(tempx3-x3) < precision){
                    found = true;
                }
            }



            double[] results = new double[3];
            results[0] = x1;
            results[1] = x2;
            results[2] = x3;
            //return all x values in array
            return results;

        }




        static void Main(string[] args)
        {
            
            //already pretransformed into what I need ( can later exchange with function that transforms )
            double[][] inputMatrix = new double[][] {
                new double[]{0.1,-0.3,1.1},
                new double[]{-0.1,0.15,2.25},
                new double[]{-0.2,-0.1,1.4}
            };
 
            double precision = 0.001;
            //timer
            var watch = System.Diagnostics.Stopwatch.StartNew();
            // jacobian
            var result = JacobianSolution(inputMatrix, precision);
            watch.Stop();
            //loop for result Jacobian
            System.Console.WriteLine("Final answers Jacobian: \n ----------");
            foreach(var x in result){
                System.Console.WriteLine(Math.Round(x));
            }
            System.Console.WriteLine("\n" + watch.Elapsed + "\n ---------");

            // //zeidel
            // watch = System.Diagnostics.Stopwatch.StartNew();
            // result = ZeidelSolution(inputMatrix, precision);
            // watch.Stop();
            // System.Console.WriteLine("\n\n\n" + watch.Elapsed + "\n\n");
            // //loop for result ZEIDEL
            // System.Console.WriteLine("Final answers Zeidels: \n ----------");
            // foreach(var x in result){
            //     System.Console.WriteLine(x);
            // }


            
        }
    }
}
