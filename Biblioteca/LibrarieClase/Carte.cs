using System;

namespace LibrarieClase
{
    public class Carte
    {
        //constanta
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';

        //constante folosite la citirea din fisier
        private const int ID = 0;
        private const int TITLU = 1;
        private const int AUTOR = 2;
        private const int DATA = 3;

        //proprietati auto-implemented
        public int idCarte { get; set; }
        public string titlu { get; set; }
        public string autor { get; set; }
        public string dataAparitiei { get; set; }

        public Carte()
        {
            titlu = autor = dataAparitiei = string.Empty;
        }

        //constructor cu parametri
        public Carte(int id, string TITLU, string AUTOR, string data)
        {
            titlu = TITLU;
            dataAparitiei = data;
            autor = AUTOR;
            idCarte = id;
        }

        //constructor cu un singur parametru de tip string care reprezinta o linie dintr-un fisier text
        public Carte(string linieFisier)
        {
            var dateFisier = linieFisier.Split(';');

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            idCarte = Convert.ToInt32(dateFisier[ID]);
            titlu = dateFisier[TITLU];
            autor = dateFisier[AUTOR];
            dataAparitiei = dateFisier[DATA];
        }

        public void Citire_Carte_Tastatura(int iD)
        {
            idCarte = iD + 1;
            string v = "";

            Console.WriteLine("Introduceti Titlul carii");
            v = Console.ReadLine();
            titlu = v;

            Console.WriteLine("Introduceti Autorul cartii [format sugerat]{Ion_Creanga}");
            v = Console.ReadLine();
            autor = v;

            Console.WriteLine("Introduceti data aparitiei");
            v = Console.ReadLine();
            dataAparitiei = v;
        }

        public string ConversieLaSirCarte_PentruFisier()
        {
            string obiectCartePentruFisier = string.Format("{1}{0}{2}{0}{3}{0}",
                SEPARATOR_PRINCIPAL_FISIER,
                idCarte.ToString(),
                (titlu ?? " NECUNOSCUT "),
                (autor ?? " NECUNOSCUT "),
                (dataAparitiei ?? " NECUNOSCUT "));

            return obiectCartePentruFisier;
        }

        public int GetIdCarte()
        {
            return idCarte;
        }

        public string GetTitluC()
        {
            return titlu;
        }

        public string GetAutorC()
        {
            return autor;
        }

        public string GetDataC()
        {
            return dataAparitiei;
        }
    }
}
