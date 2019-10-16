using System;

//draw line (main idea)
public class CrossingMethod{
    //root is between two initial guess intervals (between F and its derivative)
    public double? ExecuteNewCrossing(
        Func<double,double> function,
        Func<double,double> derivative,
        double initialGuess,
        double initialGuess2,
        double error
    ){
        //variables
        Func<double,double> f = function;
        Func<double,double> g = derivative; //use it to determine whether a or b is x0
        double x0 = initialGuess;
        double x1 = initialGuess2;
        double err = error;
        bool Converged = false;

        int n = 0; //divisions

        double[] x = new double[100];
        x[n] = x0;
        x[n+1] = x1;

        //we do constant refinement to find root with desired accuracy using the formula
        do{

            x[n+2] = x[n+1] - (f(x[n+1])*(x[n+1]-x[n]))/(f(x[n+1])-f(x[n]));
            

            Console.Write($"divisions: {n}\nCurrent xn+2 : {x[n+2]}\n ----\n\n");

            if(Math.Abs(x[n+2]-x[n+1])<err){
                Converged = true;
            } else {
                n++;

            }


        }   while (!Converged);   


        if(Converged){
            return x[n+2];
        } else {
            return null;
        }
    }
}