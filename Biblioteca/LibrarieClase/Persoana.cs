using System;

namespace LibrarieClase
{
    public class Persoana
    {
        //constanta
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        //constante folosite la citirea din fisier
        private const int ID = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int CNP = 3;

        //proprietati auto-implemented
        public int idPersoana { get; set; }
        public string nume { get; set; }
        public string prenume { get; set; }
        public string cnp { get; set; }


        public Persoana(string NUME, string PRENUME, string CNP, int id)
        {
            nume = NUME;
            prenume = PRENUME;
            cnp = CNP;
            idPersoana = id;
        }

        public Persoana()
        {
            nume = prenume = cnp = string.Empty;
        }

        public Persoana(string linieFisier)
        {
            var dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);
            idPersoana = Convert.ToInt32(dateFisier[ID]);
            nume = dateFisier[NUME];
            prenume = dateFisier[PRENUME];
        }

        public void Citire_Persoana_Tastatura(int iD)
        {
            idPersoana = iD + 1;
            string v = "";

            Console.WriteLine("Introduceti Numele persoanei");
            v = Console.ReadLine();
            nume = v;

            Console.WriteLine("Introduceti Prenumele persoanei");
            v = Console.ReadLine();
            prenume = v;

            Console.WriteLine("Introduceti CNP-ul persoanei");
            v = Console.ReadLine();
            cnp = v;

        }
        public string ConversieLaSirPersoana_PentruFisier()
        {
            string obiectPersoanaPentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idPersoana.ToString(),
                (nume ?? " NECUNOSCUT "),
                (prenume ?? " NECUNOSCUT "),
                (cnp ?? " NECUNOSCUT "));

            return obiectPersoanaPentruFisier;
        }

        public int GetIdPersoana()
        {
            return idPersoana;
        }

        public string GetNumeP()
        {
            return nume;
        }

        public string GetPrenumeP()
        {
            return prenume;
        }

        public string GetCnpP()
        {
            return cnp;
        }
    }
}