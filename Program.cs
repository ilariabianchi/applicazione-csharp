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
                        //richiamo funzione
                        bool inserisci = Aggiungi(classe, descrizione, numero, subalterno, cap, istat, latitudine, longitudine);
                        if (inserisci)
                        {
                            //cancello il file
                            File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
                            //in c# il rename del c++ si fa con File.Move
                            File.Move("file2.csv", "Comune_Bergamo_-_Numerazione_civica.csv");
                            Console.Write("\nelemento aggiunto\n\n");
                        }
                        else
                        {
                            Console.Write("\nerrore nell'inserimento\n\n");
                        }
                        break;

                    case 2:
                        Console.Write("\ninserisci i dati della via che vuoi modificare:\n");
                        Console.Write("descrizione: ");
                        //prendo in input la descrizione e la trasformo in maiuscolo
                        descrizione = Console.ReadLine().ToUpper();
                        Console.Write("numero: ");
                        numero = Console.ReadLine();
                        //cerco nel file se la via è presente
                        int posiz = Cerca(descrizione, numero);
                        if (posiz != -1)
                        {
                            Console.Write("\ninserisci i dati modificati:\n");
                            Console.Write("classe: ");
                            //con ToUpper trasformo tutte le stringhe in maiuscolo
                            classe = Console.ReadLine().ToUpper();
                            Console.Write("descrizione: ");
                            descrizione = Console.ReadLine().ToUpper();
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
                            //richiamo la funzione
                            bool mod = Modifica(posiz, classe, descrizione, numero, subalterno, cap, istat, longitudine, latitudine);
                            if (mod)
                            {
                                //se va a buon fine cancello il vecchio file e rinomino il nuovo
                                //cancello il file
                                File.Delete("Comune_Bergamo_-_Numerazione_civica.csv");
                                //in c# il rename del c++ si fa con File.Move
                                File.Move("file2.csv", "Comune_Bergamo_-_Numerazione_civica.csv");
                                Console.Write("\nmodifica effettuata\n\n");
                            }
                            else
                            {
                                Console.Write("\nerrore nella modifica\n\n");
                            }
                        }
                        else
                        {
                            Console.Write("\nelemento non trovato\n\n");
                        }


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

        //le funzioni si mettono tra la fine del main e la fine di Program

        //funzione Cerca
        static int Cerca (string descrizione, string numero)
        {
            //leggo il file
            StreamReader Leggi = new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
            string riga, desc, num;
            //salto le prima riga di intestazione
            riga = Console.ReadLine();
            int i = 0;
            //leggo tutte le righe fino alla fine del file
            while ((riga = Leggi.ReadLine()) != null)
            {
                //Split divide la riga in tanti pezzi ogni volta che è separato dalla virgola e la riga diventa un array di stringhe
                string[] campi = riga.Split(',');
                //campi[0] è la classe e la salto
                desc = campi[1];
                num = campi[2];
                //controllo che corrispondano a quello che sto cercando
                if (desc == descrizione && num == numero)
                {
                    //chiudo
                    Leggi.Close();
                    //restituisco la posizione
                    return i;
                }

                //se non corrisponde vado avanti alla prossima riga
                i++;
            }

            //chiudo il file
            Leggi.Close();
            //se non trovo nulla restituisco -1
            return -1;
        }

        //funzione AGGIUNGI
        static bool Aggiungi (string classe, string descrizione, string numero, string subalterno, string cap, string istat, double longit, double lat)
        {
            //leggo il file
            StreamReader Leggi = new StreamReader ("Comune_Bergamo_-_Numerazione_civica.csv");
            //ne scrivo uno nuovo, true = ios:app in c++
            StreamWriter Scrivi = new StreamWriter ("file2.csv", true);
            string riga;
            //se il file da scrivere non è aperto ritorno falso
            if (Scrivi == null)
            {
                return false;
            }
            //controllo che il file ci sia
            if (File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
            {
                //leggo tutte le righe fino alla fine del file
                while ((riga = Leggi.ReadLine()) != null)
                {
                    //copio la riga
                    Scrivi.WriteLine(riga);
                }
            }
            Scrivi.WriteLine(classe+","+descrizione+","+numero+","+subalterno+","+cap+","+istat+","+longit+","+lat+",\"("+longit+","+lat+")\"");
            //chiudo entrambi i file
            Leggi.Close();
            Scrivi.Close();

            return true;
        }

        //funzione MODIFICA
        static bool Modifica (int posiz, string classe, string descrizione, string numero, string subalterno, string cap, string istat, double longit, double lat)
        {
            //leggo il file
            StreamReader Leggi = new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
            //ne scrivo uno nuovo
            StreamWriter Scrivi = new StreamWriter("file2.csv");
            string riga;
            //salto la prima riga
            riga = Console.ReadLine();
            Scrivi.WriteLine(riga);
            int i = 0;
            //se il file da scrivere non è aperto ritorno falso
            if (Scrivi == null)
            {
                return false;
            }
            //controllo che il file ci sia
            if (File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
            {
                //leggo tutte le righe fino alla fine del file
                while ((riga = Leggi.ReadLine()) != null)
                {
                    if (i != posiz)
                    {
                        //se non trovo quello che voglio modificare continuo a copiare
                        Scrivi.WriteLine(riga);

                    }
                    else
                    {
                        //quando lo trovo scrivo la riga modificata
                        Scrivi.WriteLine(classe + "," + descrizione + "," + numero + "," + subalterno + "," + cap + "," + istat + "," + longit + "," + lat + ",\"(" + longit + "," + lat + ")\"");

                    }
                    i++;
                }

            }
            return true;
        }

        //funzione Cancella
        static bool Cancella (int posiz)
        {
            //leggo il file
            StreamReader Leggi = new StreamReader("Comune_Bergamo_-_Numerazione_civica.csv");
            //ne scrivo uno nuovo
            StreamWriter Scrivi = new StreamWriter("file2.csv");
            string riga;
            //salto la prima riga
            riga = Console.ReadLine();
            Scrivi.WriteLine(riga);
            int i = 0;
            //se il file da scrivere non è aperto ritorno falso
            if (Scrivi == null)
            {
                return false;
            }
            if (File.Exists("Comune_Bergamo_-_Numerazione_civica.csv"))
            {
                while ((riga = Leggi.ReadLine()) != null)
                {
                    //finchè non trovo quello che sto cercando lo copio e quello da eliminare lo salto e non faccio nulla
                    if (i != posiz)
                    {
                        Scrivi.WriteLine(riga);
                    }
                    i++;
                }
            }
            return false;
        }
    } 
}
