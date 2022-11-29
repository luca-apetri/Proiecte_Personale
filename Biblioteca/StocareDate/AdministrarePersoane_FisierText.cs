using System.IO;
using LibrarieClase;

namespace StocareDate
{
    public class AdministrarePersoane_FisierText
    {
        private const int NR_MAX_PERSOANE = 50;
        private string numeFisierP;

        public AdministrarePersoane_FisierText(string numeFisier)
        {
            this.numeFisierP = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddPersoana(Persoana persoana)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierP, true))
            {
                streamWriterFisierText.WriteLine(persoana.ConversieLaSirPersoana_PentruFisier());
            }
        }

        public Persoana[] GetPersoane(out int nrPersoane)
        {
            Persoana[] persoane = new Persoana[NR_MAX_PERSOANE];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisierP))
            {
                string linieFisier;
                nrPersoane = 0;

                // citeste cate o linie si creaza un obiect de tip Peroana
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    persoane[nrPersoane++] = new Persoana(linieFisier);
                }
            }

            return persoane;
        }
    }
}
