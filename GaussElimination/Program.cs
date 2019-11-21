using System;


namespace GaussElimination
{

    class Program
    {

        //helper method
        public static bool IsValidSolution(double reuslt){
            return !(double.IsNaN(reuslt) || double.IsInfinity(reuslt));
        }

        //substitute row values into other rows to get final answers
        public static double[] BackSubstition(double[][] rowsMatrix){
            double val = 0;
            int length = rowsMatrix[0].Length;
            double[] result = new double[rowsMatrix.Length];
            for (int i = rowsMatrix.Length - 1; i >= 0; i--)
            {
                val = rowsMatrix[i][length-1];
                for (int x = length-2; x > i-1; x--)
                {
                    val -= rowsMatrix[i][x] * result[x];
                }
                result[i] = val / rowsMatrix[i][i];

                //if divide by 0 etc
                if(!IsValidSolution(result[i])){
                    return null;
                }
            }

            return result;
        }

        //swap rows
        static public bool SwapRows(double[][] rowsMatrix, int row, int column){
            bool isSwapped = false;
            for (int z = rowsMatrix.Length-1; z > row; z--)
            {
                if(rowsMatrix[z][row] != 0){
                    double[] temp = new double[rowsMatrix[0].Length];
                    temp = rowsMatrix[z];
                    rowsMatrix[z] = rowsMatrix[column];
                    rowsMatrix[column] = temp;
                    isSwapped = true;
                }
            }
            return isSwapped;
        }


        //do row operations
        static public double[] GetReducedForm(double[][] rowsMatrix){
            int length = rowsMatrix[0].Length;

            for (int i = 0; i < rowsMatrix.Length; i++)
            {
                //first row is equal 0 and we cannot swap = no solution
                if(rowsMatrix[i][i] == 0 && !SwapRows(rowsMatrix,i,i)){
                    return null;
                }
                
                //diving rows by itself to create nicer row values
                for (int j = 0; j < rowsMatrix.Length; j++)
                {
                    double[] d = new double[length];
                    for (int k = 0; k < length; k++)
                    {
                        d[k] = rowsMatrix[j][k];
                        if(rowsMatrix[j][i] != 0){
                            d[k] = d[k] / rowsMatrix[j][i];
                        }
                    }
                    //update current matrix after calc
                    rowsMatrix[j] = d;
                }

                //more calc, subtracting rows one from another
                for (int y = i+1; y < rowsMatrix.Length; y++)
                {
                    double[] f = new double[length];
                    for (int g = 0; g < length; g++)
                    {
                        f[g] = rowsMatrix[y][g];
                        if(rowsMatrix[y][i] != 0 ){
                            f[g] = f[g] - rowsMatrix[i][g];
                        }
                    }
                    rowsMatrix[y] = f;

                }
            }
            //sub values to get final answers
            return BackSubstition(rowsMatrix);
        }

        //init + convert string input into matrix and continue solving
        static public double[] GaussEliminationFunc(string[] coefficients){
            double[][] rowsMatrix = new double[coefficients.Length][];
            for (int i = 0; i < rowsMatrix.Length; i++)
            {
                //creates new arrays(in memory) and appends to array of arrays
                rowsMatrix[i] = (double[])Array.ConvertAll(coefficients[i].Split(" "),double.Parse);
            }

            return GetReducedForm(rowsMatrix);
        }


        //main
        static void Main(string[] args)
        {
            //string[] coefficients = new string[2] { "1 2 3", "4 5 6"}; 
            //string[] coefficients = new string[3] {"2 2 2 10","3 3 3 15", "1 2 3 5"}; //fails cuz 3rd row is 0 0 0 0
            //string[] coefficients = new string[3] {"2 -1 2 10","1 -2 1 8", "3 -1 2 11"};
            //string[] coefficients = new string[3] {"2 1 -3 -10","0 -2 1 -2", "0 0 1 6"};
            //string[] coefficients = new string[3] {"3 4 -1 -6","0 -2 10 -8", "0 4 -2 -2"};
            //string[] coefficients = new string[3] {"-7 -3 3 12","2 2 2 0", "-1 -4 3 -9"};
            // string[] coefficients = new string[3] {"1 -1 -1 4", "2 -2 -2 8", "5 -5 -5 20"};
            string[] coefficients = new string[3] {"-2 0 1 -4", "-1 7 1 -50", "5 -1 1 -26"};

            double[] result = GaussEliminationFunc(coefficients);

            if(result != null){
                foreach(var x in result){
                System.Console.WriteLine(Math.Floor(x));
                
                }
            }
            else{
                //infinite solutions etc.
                System.Console.WriteLine("Null answer");
            }

            
        }
    }
}
