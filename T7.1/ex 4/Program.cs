using System;
using System.Linq;
using System.Threading.Tasks;

//Define a class BitArray64 to hold 64 bit values inside an ulong value.

//Implement IEnumerable<int> and Equals(…), GetHashCode(), [], == and !=

namespace ex_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 simpleArray = new BitArray64();

            simpleArray.Add(1);

            simpleArray.Add(2);

            simpleArray.Add(3);

            simpleArray.Add(3);

            Console.WriteLine(simpleArray[2] == simpleArray[3]);



            foreach (var value in simpleArray)

            {

                Console.WriteLine(value);

            }



        }
    }
}
