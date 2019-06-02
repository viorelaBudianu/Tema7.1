using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

//Write a program that enters file name along with its full file path(e.g.C:\WINDOWS\win.ini), 
//reads its contents and prints it on the console.Find in MSDN how to use System.IO.File.ReadAllText(...). 
//Be sure to catch all possible exceptions and print user-friendly error messages

namespace T7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            // sa vedem daca path-u e in formatul corect : @"C:\Users\vbudianu\Desktop\New folder\ConfigFile.xml";
            if (filePath.Contains("/"))
            {
                throw new FormatException("Formatul adresei nu este corect");
            }

            if(!filePath.Contains(".xml")|| !filePath.Contains(".txt")|| !filePath.Contains(".docx"))
            {
                throw new UnauthorizedAccessException("Calea introdusa nu contine un fisier");
            }

            try
            {
                Console.WriteLine(File.ReadAllText(filePath));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Fisierul nu a fost gasit la adresa introdusa!");
            }
            catch (PathTooLongException)
            {               
                Console.WriteLine("Calea, numele fisierului sau ambele depasesc lungimea maxima definita de sistem");
                Console.WriteLine("Calea trebuie sa aiba mai putin de 248 de caractere iar numele fisierelor sa aiba mai putin de 260 caractere");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Folderul nu a fost gasit la adresa introdusa");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Calea este incorecta.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Verificati daca documentul nu este read only\nAceasta operatiune nu e suportata de platforma\nCalea specifica un document, nu un fisier");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Calea are formatul invalid");
            }
            catch (IOException)
            {
                Console.WriteLine("o eroare I/O a aparul la deschiderea fisierului");
            }
            catch (SecurityException)
            {
                Console.WriteLine("Nu aveti permisiune sa deschideti documentul");
            }

          
        
    }
    }
}
