using System.IO;
using LibrarieClase;

namespace StocareDate
{
    public class AdministrareCarti_FisierText
    {
        private const int NR_MAX_CARTI = 50;
        private string numeFisierC;


        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.numeFisierC = numeFisier;
            // se incearca deschiderea fisierului in modul OpenOrCreate
            // astfel incat sa fie creat daca nu exista
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
        }

        public void AddCarte(Carte carte)
        {
            // instructiunea 'using' va apela la final streamWriterFisierText.Close();
            // al doilea parametru setat la 'true' al constructorului StreamWriter indica
            // modul 'append' de deschidere al fisierului
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierC, true))
            {
                streamWriterFisierText.WriteLine(carte.ConversieLaSirCarte_PentruFisier());
            }
        }

        public Carte[] GetCarti(out int nrCarti)
        {
            Carte[] carti = new Carte[NR_MAX_CARTI];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisierC))
            {
                string linieFisier;
                nrCarti = 0;

                // citeste cate o linie si creaza un obiect de tip Carte
                // pe baza datelor din linia citita
                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    carti[nrCarti++] = new Carte(linieFisier);
                }
            }
            return carti;
        }
        /*
        public void RemoveCarte(int ID)
        {

            Carte[] carti = new Carte[NR_MAX_CARTI];

            using (StreamReader streamReader = new StreamReader(numeFisierC))
            {
                string linieFisier = string.Empty;
                int nrCarti = 0;

                while (nrCarti != (ID-1))
                {
                    linieFisier = string.Empty;
                    carti[nrCarti++] = new Carte(linieFisier);
                    using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisierC, true))
                    {
                        streamWriterFisierText.WriteLine(carti.ConversieLaSirCarte_PentruFisier());
                    }
                }
                
            }

        }*/
    }
}
