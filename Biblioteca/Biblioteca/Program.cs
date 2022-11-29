using System;
using LibrarieClase;
using StocareDate;

namespace Biblioteca
{
    class Program
    {
        static void Main()
        {
            string numeFisierC = "Carti.txt";
            AdministrareCarti_FisierText adminCarti = new AdministrareCarti_FisierText(numeFisierC);
            int nrCarti = 0;
            Carte[] Cartile1 = adminCarti.GetCarti(out nrCarti);
            int idCarte = 0;

            string numeFisierP = "Persoane.txt";
            AdministrarePersoane_FisierText adminPersoane = new AdministrarePersoane_FisierText(numeFisierP);
            int nrPersoane = 0;
            Persoana[] Persoanele1 = adminPersoane.GetPersoane(out nrPersoane);

            int idPersoana = 0;

            string optiune;
            do
            {
                Console.WriteLine("Q. Afisare Carti din fisier");
                Console.WriteLine("W. Afisare Persoane din fisier");

                Console.WriteLine("E. Salvare Persoane in fisier");
                Console.WriteLine("R. Salvare Carte in fisier");

                Console.WriteLine("A. Citire carte de la tastatura");
                Console.WriteLine("S. Citire Persoana de la tastatura");

                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();
                switch (optiune.ToUpper())
                {


                    case "Q":
                        Carte[] Cartile = adminCarti.GetCarti(out nrCarti);
                        AfisareCarti(Cartile, nrCarti);
                        break;
                    case "W":
                        Persoana[] Persoanele = adminPersoane.GetPersoane(out nrPersoane);
                        AfisarePersoane(Persoanele, nrPersoane);
                        break;


                    case "E":
                        idPersoana = nrPersoane + 1;
                        nrPersoane = nrPersoane + 1;
                        Persoana persoana = new Persoana("Apetri", "Luca", "59283478293", idPersoana);
                        //adaugare persoana in fisier
                        adminPersoane.AddPersoana(persoana);
                        break;
                    case "R":
                        idCarte = nrCarti + 1;
                        nrCarti = nrCarti + 1;
                        Carte carte = new Carte(idCarte, "Baltagul", "Mihail_Sadoveanu", "noiembrie_1930");
                        //adaugare student in fisier
                        adminCarti.AddCarte(carte);
                        break;


                    case "X":
                        return;


                    case "A":
                        idCarte = nrCarti + 1;
                        nrCarti = nrCarti + 1;
                        Carte Ccarte = new Carte();
                        Ccarte.Citire_Carte_Tastatura(idCarte);
                        //adaugare student in fisier
                        adminCarti.AddCarte(Ccarte);
                        break;
                    case "S":
                        idPersoana = nrPersoane + 1;
                        nrPersoane = nrPersoane + 1;
                        Persoana Cpersoana = new Persoana();
                        Cpersoana.Citire_Persoana_Tastatura(idPersoana);
                        //adaugare student in fisier
                        adminPersoane.AddPersoana(Cpersoana);
                        break;


                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }


        public static void AfisareCarti(Carte[] carti, int nrCarti)
        {
            Console.WriteLine("Cartile sunt:");
            for (int contor = 0; contor < nrCarti; contor++)
            {
                string infoCarti = string.Format("Cartea cu id-ul #{0} are titlul: {1} , aurotul: {2} , data lansarii: {3}",
                   carti[contor].GetIdCarte(),
                   carti[contor].GetTitluC() ?? " NECUNOSCUT ",
                   carti[contor].GetAutorC() ?? " NECUNOSCUT ",
                   carti[contor].GetDataC() ?? " NECUNOSCUT ");

                Console.WriteLine(infoCarti);
            }
        }

        public static void AfisarePersoane(Persoana[] persoane, int nrPersoane)
        {
            Console.WriteLine("Persoanele sunt:");
            for (int contor = 0; contor < nrPersoane; contor++)
            {
                string infoPersoana = string.Format("Persoana cu id-ul #{0} are numele: {1} {2} si CNP-ul: {3}",
                   persoane[contor].GetIdPersoana(),
                   persoane[contor].GetNumeP() ?? " NECUNOSCUT ",
                   persoane[contor].GetPrenumeP() ?? " NECUNOSCUT ",
                   persoane[contor].GetCnpP() ?? " NECUNOSCUT ");

                Console.WriteLine(infoPersoana);
            }
        }
    }
}

