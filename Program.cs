using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace applicazione_csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiaro variabili
            int opzione;
            string classe, descrizione, numero, subalterno, cap, istat;
            double longitudine, latitudine;

            //do while
            do
            {
                //Console.Write non va a capo
                //Console.WriteLine alla fine va a capo
                Console.Write("APPLICAZIONE CSV\n1 - inserisci\n2 - modifica\n3 - cancella\n0 - stop");
                Console.Write("\nopzione: ");
                //Console.ReadLine legge stringhe, converto la variabile in un intero con Convert.ToInt32 (libreria System)
                opzione = Convert.ToInt32(Console.ReadLine());

            } while (opzione != 0);
        }
    }
}

