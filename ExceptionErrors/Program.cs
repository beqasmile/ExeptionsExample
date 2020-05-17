using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionErrors
{
    class Program
    {
        static void Main(string[] args)
        {
            try 
            {
                int a=0, b=0;
                string c="";
                Console.WriteLine("Please input first number >");
                bool aArgumentOK = false;
                bool bArgumentOK = false;
                bool cOperationOK = false;


                while (!aArgumentOK || !bArgumentOK ||!cOperationOK)
                {
                    if (!aArgumentOK)
                    {
                        try
                        {
                            a = int.Parse(Console.ReadLine());
                            aArgumentOK = true;
                        }
                        catch (ArgumentException argEx)
                        {
                            Console.WriteLine("Argument first numnber error was thrown " + argEx.Message + "please fix " +
                                "and try again");
                        }

                    }


                    Console.WriteLine("Please input second number >");

                    if (!bArgumentOK)
                    {
                        try
                        {
                            b = int.Parse(Console.ReadLine());

                        }
                        catch (ArgumentException argEx)
                        {
                            Console.WriteLine("Argument second numnber error was thrown " + argEx.Message + "please fix " +
                                    "and try again");

                        }

                    }


                    Console.WriteLine("Please input operation >");
                    if (!cOperationOK)
                    {
                        try
                        {
                            c = Console.ReadLine();
                            Console.WriteLine(Calculation(a, c, b));

                            cOperationOK = true;

                        }
                        catch (NotValidOperationException argEx)
                        {
                            Console.WriteLine(argEx);

                        }

                    }
                    
                    c = Console.ReadLine();



                }
            }
            catch (DivideByZeroException divEx)
            {
                Console.WriteLine("Divide by 0 error was thrown " + divEx.Message);
 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error was thrown " + ex.Message);
            }


            Console.ReadKey();
        }

        public static int Calculation(int a, string operation, int b)
        {
            if (a<0 || a>1000)
            {
                ArgumentOutOfRangeException argumentOutOfRangeException = new ArgumentOutOfRangeException("first number is our of range");
                throw argumentOutOfRangeException;
            }

            if (b < 0 || b > 1000)
            {
                ArgumentOutOfRangeException argumentOutOfRangeException = new ArgumentOutOfRangeException("second number is our of range");
                throw argumentOutOfRangeException;
            }


            int result;
            switch (operation)
            {
                case "+": 
                    result= a + b;
                    break;
                case "-":
                    result = a - b;
                    break;
                case "*":
                    result = a * b;
                    break;
                case "/":
                    result = a / b;
                    if (b==0)
                    {
                        DivideByZeroException divideByZeroException = new DivideByZeroException("the second number is equal to zero");
                        throw divideByZeroException;
                    }
                    break;

                default:
                    NotValidOperationException notOurSign = new NotValidOperationException(operation,"This is not one of the next operations (+, -, * /) ");
                    throw notOurSign;

            }
            return result;
        }
    }
}
