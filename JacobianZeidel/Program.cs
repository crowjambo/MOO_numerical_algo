using System;
using System.Collections.Generic;
using System.Linq;

namespace IterativeSolutions
{
    class Program
    {
        //compare jacobian vs zeidel speed etc.


        //zeidels solution
        public static double[] ZeidelSolution(double[][] inputMatrix, double precision){
            double x1 = 0;
            double x2 =0;
            double x3 = 0;
            double tempx1 = 0;
            double tempx2 = 0;
            double tempx3 = 0;

            //previous test
            double prev1 = 0;
            double prev2 = 0;
            double prev3 = 0;

            int i = 0;
            bool found = false;
            System.Console.WriteLine("ZEIDEL");
            while(!found){

                prev1 = x1;
                prev2 = x2;
                prev3 = x3;

                //difference is that, we use our calc values in next calculation without waiting for next iteration
                x1 = (inputMatrix[0][0] * tempx2) + (inputMatrix[0][1] * tempx3) + inputMatrix[0][2];
                tempx1 = x1;
                x2 = (inputMatrix[1][0] * tempx1) + (inputMatrix[1][1] * tempx3) + inputMatrix[1][2];
                tempx2 = x2;
                x3 = (inputMatrix[2][0] * tempx1) + (inputMatrix[2][1] * tempx2) + inputMatrix[2][2];
                tempx3 = x3;

                i++;
                System.Console.WriteLine($"Iteration {i} x1 = {x1} x2 = {x2} x3 = {x3}");

                //final precision check
                if(Math.Abs(x1 - prev1) < precision && Math.Abs(x2 - prev2) < precision && Math.Abs(x3 - prev3) < precision){
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

        //jacobian solution
        public static double[] JacobianSolution(double[][] inputMatrix, double precision){
            double x1 = 0;
            double x2 =0;
            double x3 = 0;
            double tempx1 = 0;
            double tempx2 = 0;
            double tempx3 = 0;
            int i = 0;
            bool found = false;
            System.Console.WriteLine("JACOBIAN");
            while(!found){

                //calc with current values
                tempx1 = x1;
                tempx2 = x2; 
                tempx3 = x3; 
                x1 = (inputMatrix[0][0] * tempx2) + (inputMatrix[0][1] * tempx3) + inputMatrix[0][2];
                x2 = (inputMatrix[1][0] * tempx1) + (inputMatrix[1][1] * tempx3) + inputMatrix[1][2];
                x3 = (inputMatrix[2][0] * tempx1) + (inputMatrix[2][1] * tempx2) + inputMatrix[2][2];

                i++;
                System.Console.WriteLine($"Iteration {i} x1 = {x1} x2 = {x2} x3 = {x3}");

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

        public static double[][] MatrixConvert(double[][] inputMatrix){
            double[][] newMatrix = new double[3][]{
                new double[3],
                new double[3],
                new double[3]
            };
        
            for (int i = 0; i < 3; i++)
            {
                //convert 3x4 straight input matrix into 3x3 where its divided and prepared for operations
                for (int j = 0; j < 3; j++)
                {
                    
                    //first row, skip first element x1
                    if(i==0){
                        newMatrix[i][j] = (inputMatrix[i][j+1] / inputMatrix[i][i]) *(-1);
                    }
                    //in 2nd row, skip second element (x2)
                    else if(i==1){
                        if(j==1){
                            newMatrix[i][j] = (inputMatrix[i][j+1] / inputMatrix[i][i]) *(-1);
                        }
                        else if(j==2){
                            newMatrix[i][j] = (inputMatrix[i][j+1] / inputMatrix[i][i]) *(-1);
                        }
                        else{
                            newMatrix[i][j] = (inputMatrix[i][j] / inputMatrix[i][i]) *(-1);
                        }
                        
                    }
                    //3rd row, skip x3 element
                    else{
                        if(j==2){
                            newMatrix[i][j] = (inputMatrix[i][j+1] / inputMatrix[i][i]) *(-1);
                        }  
                        else{
                            newMatrix[i][j] = (inputMatrix[i][j] / inputMatrix[i][i]) *(-1);
                        }
                        
                    }
                    //reverse -1 multipication on last number ( normal numbers ) as they dont get moved
                    if(j+1 == 3){
                        newMatrix[i][j] *= -1;
                    }
                }
            }

            return newMatrix;

        }

        static void Main(string[] args)
        {
            
            // ---------------------------------------------------------------- VARS

            //already pretransformed into what I need ( can later exchange with function that transforms )
            // double[][] inputMatrix = new double[][] {
            //     new double[]{0.1,-0.3,1.1},
            //     new double[]{-0.1,0.15,2.25},
            //     new double[]{-0.2,-0.1,1.4}
            // };

            //non converted input
            double[][] inputMatrix = new double[][]{
                    new double[]{5,-1,2,12},
                    new double[]{3,8,-2,-25},
                    new double[]{1,1,4,6}
            };
            // double[][] inputMatrix = new double[][]{
            //         new double[]{10,-1,3,11},
            //         new double[]{2,20,3,45},
            //         new double[]{2,1,10,14}
            // };
            //convert
            inputMatrix = MatrixConvert(inputMatrix); //converts into top commented example format
 
            double precision = 0.001;


            // -------------------------------------------------------------- JACOBIAN
            

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var result = JacobianSolution(inputMatrix, precision);
            watch.Stop();
            
            //output
            System.Console.WriteLine("Final answers Jacobian: \n ----------");
            foreach(var x in result){
                System.Console.WriteLine(Math.Round(x));
            }
            System.Console.WriteLine("\n" + watch.Elapsed + "\n ---------");

            // --------------------------------------------------------------- ZEIDEL

            watch = System.Diagnostics.Stopwatch.StartNew();
            result = ZeidelSolution(inputMatrix, precision);
            watch.Stop();

            //output
            System.Console.WriteLine("Final answers Jacobian: \n----------");
            foreach(var x in result){
                System.Console.WriteLine(Math.Round(x));
            }
            System.Console.WriteLine("\n" + watch.Elapsed + "\n ---------");

            
        }
    }
}
