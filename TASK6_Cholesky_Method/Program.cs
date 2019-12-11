using System;

namespace TASK6_Cholesky_Method
{

    /* Algorithm

            A * x = B
            Input = Coefficient Matrix + B numbers array
            Find X values
            STEPS:
                - Find A using Cholesky decomposition ( A = L*L(transposed) )
                
                - Do backwards substitution to find X vales
                - return answer array

    */

    class Program
    {
        //Simple display in console
        static void MatrixDisplaySingle(double[,] lower){
            for (int i = 0; i < 3; i++)  
            {  
                for (int j = 0; j < 3; j++) 
                    Console.Write($"{lower[i, j]:0.0} + \t"); 
                Console.WriteLine(); 
            } 
        }



        //Solve LowerTriangular * Z = B,  Solve L(transpose) * X = Z
        static double[] Substitution(double[,] matrix, double[] bMatrix){
            //output var
            double[] outputMatrix = new double[3];

            //first row
            outputMatrix[0] = bMatrix[0] / matrix[0,0];

            //second row
            outputMatrix[1] = (bMatrix[1] + ((matrix[1,0] *outputMatrix[0])*(-1))) / matrix[1,1];

            //third row
            outputMatrix[2] = (bMatrix[2] + (outputMatrix[0]*matrix[2,0]*(-1)) + (outputMatrix[1]*matrix[2,1]*(-1))) / matrix[2,2];



            //return Z or X vars
            return outputMatrix; 
        }

        static double[] Substitution_Transposed(double[,] matrix, double[] bMatrix){
            //output var
            double[] outputMatrix = new double[3];

            //third row
            outputMatrix[2] = bMatrix[2] / matrix[2,2];

            //second row
            outputMatrix[1] = (bMatrix[1] + ((matrix[1,2] *outputMatrix[2])*(-1))) / matrix[1,1];

            //first row
            outputMatrix[0] = (bMatrix[0] + (outputMatrix[2]*matrix[0,2]*(-1)) + (outputMatrix[1]*matrix[0,1]*(-1))) / matrix[0,0];

            //return Z or X vars
            return outputMatrix; 
        }

        /* Cholesky formula


        Lower          Lower Tranposed
        {a, 0, 0}         {a, b, d} 
        {b, c, 0}         {0, c, e}
        {d, e, f}         {0, 0, f}

        L*L(transpose)
        {Math.Pow(a,2), a*b, a*d}
        {a*b, Math.Pow(b,2)+Math.Pow(c,2), b*d+c*e}
        {a*d, b*d+c*e, Math.Pow(d,2)+Math.Pow(e,2)+Math.Pow(f,2)}



        */
        /* Theory
                The Cholesky decomposition or Cholesky factorization is a decomposition of a Hermitian, positive-definite matrix into the product of a lower triangular matrix and its conjugate transpose. The Cholesky decomposition is roughly twice as efficient as the LU decomposition for solving systems of linear equations.


                //WORKS ONLY FOR HERMITIAN MATRIXES (that is equal to its own conjugate transpose) A = A(transpose)

        */
        //Find A
        static double[,] Cholesky_Decomposition(double[,] matrix){ 
                
            // Output var
            double[,] lower = new double[3, 3]; 
        
            // Decomposing a matrix into Lower Triangular 
            for (int i = 0; i < 3; i++){ 
                for (int j = 0; j <= i; j++){ 
                    double sum = 0; 
                    // summation for diagonals
                    if (j == i) { 
                        for (int k = 0; k < j; k++) {
                            sum += Math.Pow(lower[j, k], 2); 
                        }      
                        lower[j, j] = Math.Sqrt(matrix[j, j] - sum); 
                    }  
                    else{ 
                        // Evaluating L(i, j)  using L(j, j) 
                        for (int k = 0; k < j; k++){
                            sum += (lower[i, k] * lower[j, k]); 
                        }
                        lower[i, j] = (matrix[i,j] - sum) / lower[j, j]; 
                    } 
                } 
            } 

            return lower;
        } 
        //Use LowerTriangular and turn it into Transposed
        static double[,] TransposeMatrix(double[,] matrix){
            double[,] outputM = new double[3,3];
            for (int i = 0; i < 3; i++)  
                { 
                for (int j = 0; j < 3; j++) 
                    outputM[i,j] = matrix[j,i];
                } 
            return outputM;
        }


        //Main driver
        static void Main(string[] args){

            //input vars
            //coefficients matrix
            // double[,] matrix = {
            //         {1,-1,2},
            //         {-1,5,-4},
            //         {2,-4,6} 
            //         };
            double[,] matrix = {
                {2,1,1},
                {1,2.5,1},
                {1,1,3} 
                };
            //B matrix
            double[] bMatrix = {
                3,
                5,
                0
            };

            double[,] lowerTmatrix = Cholesky_Decomposition(matrix);
            double[,] lowerTransposed = TransposeMatrix(lowerTmatrix);

            //display
            System.Console.WriteLine("Normal");
            MatrixDisplaySingle(lowerTmatrix);
            System.Console.WriteLine("Transposed");
            MatrixDisplaySingle(lowerTransposed);


            System.Console.WriteLine();
            double[] outputTest = Substitution(lowerTmatrix, bMatrix);
            // foreach(var x in outputTest){
            //     System.Console.WriteLine(x);
            // }
            System.Console.WriteLine();
            outputTest = Substitution_Transposed(lowerTransposed, outputTest);
            foreach(var x in outputTest){
                System.Console.WriteLine($"{x:0.00}");
            }

        }
    }
}

