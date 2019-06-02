using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method ReadNumber(int start, int end) that enters an integer number in a given range ( start, end ).
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers:	a1, a2, ..., a10, such that 1 < a1< ... < a10< 100
//Output
//Print 1 < a1< ... < a10< 100
//Or Exception if the above inequality is not true

namespace ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Intervalul este:");
                int x = Convert.ToInt32(Console.ReadLine());
                int y = Convert.ToInt32(Console.ReadLine());
                if (x > y)
                {
                    throw new Exception("Primul numar trebuie sa fie mai mic ca al doilea");
                }
                ReadNumbers(x, y);
            }
            catch (FormatException Form)
            {
                Console.WriteLine("Va rugam introduceti formatul corect " + Form.Message);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Va rugam nu lasati intervalul NULL.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numarul este prea lung pentru a fi Integer.");
            }
            finally
            {
                Console.WriteLine("Am ajuns la final");
            }
        }
        public static void ReadNumbers(int start,int end)
        {
            List<int> numere = new List<int>();
            Console.WriteLine($"Cititi numere in intervalul [{start} {end}]");
            try
            {
                for (int i = start; i <= end; i++)
                {
                    int numar = Convert.ToInt32(Console.ReadLine());
                    if (numar<start||numar>end)
                    {
                        throw new ArgumentOutOfRangeException($"Numarul nu este in intervalul {start} {end}");
                    }
                    else if (numar>start&&numar<end)
                    {
                        if (numere.Count==0)
                        {
                            numere.Add(numar);
                            
                        }
                        else
                        {
                            if (numar<numere[numere.Count-1])
                            {
                                throw new ArgumentOutOfRangeException("Numarul introdus nu este mai mic ca ultimul numar din interval!");
                                
                            }
                            else
                            {
                                numere.Add(numar);
                                Console.WriteLine($"Numarul {numar} a fost introdus si avem: ");
                                foreach (var a in numere)
                                {
                                    Console.Write(a + " ");
                                }

                            }
                            
                        }
                    }

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Numarul nu este Integer");
                ReadNumbers(start, end);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Nu acceptam valoarea Null!");

            }
            catch (OverflowException)
            {
                Console.WriteLine("Numarul nu este Integer");
            }
        }
}
}
