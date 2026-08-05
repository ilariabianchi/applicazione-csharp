using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libreria per lettura/scrittura file
using System.IO;

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


                //switch case
                switch (opzione)
                {
                    case 1:
                        Console.Write("\ninserisci i dati della via che vuoi aggiungere:\n");
                        Console.Write("classe: ");
                        //con ToUpper trasformo tutte le stringhe in maiuscolo
                        classe = Console.ReadLine().ToUpper();
                        Console.Write("descrizione: ");
                        descrizione= Console.ReadLine().ToUpper();
                        Console.Write("numero: ");
                        numero = Console.ReadLine().ToUpper();
                        Console.Write("subalterno: ");
                        subalterno = Console.ReadLine().ToUpper();
                        Console.Write("cap: ");
                        cap = Console.ReadLine().ToUpper();
                        Console.Write("istat: ");
                        istat = Console.ReadLine().ToUpper();
                        Console.Write("latitudine: ");
                        //converto a double
                        latitudine = Convert.ToDouble(Console.ReadLine());
                        Console.Write("longitudine: ");
                        //converto a double
                        longitudine = Convert.ToDouble(Console.ReadLine());
                        break;

                    case 2:
                        Console.Write("\ninserisci i dati della via che vuoi modificare:\n");
                        Console.Write("descrizione: ");
                        //prendo in input la descrizione e la trasformo in maiuscolo
                        descrizione = Console.ReadLine().ToUpper();
                        Console.Write("numero: ");
                        numero = Console.ReadLine();
                        break;

                    case 3:
                        Console.Write("\ninserisci i dati della via che vuoi cancellare:\n");
                        Console.Write("descrizione: ");
                        descrizione = Console.ReadLine().ToUpper();
                        Console.Write("numero: ");
                        numero = Console.ReadLine();
                        break;
                }

            } while (opzione != 0);
        }
    }
}

