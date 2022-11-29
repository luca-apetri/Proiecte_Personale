#ifndef PIESA_H
#define PIESA_H

#include <tabla.h>


class piesa : public tabla
{
    public:
    char culoare_Piesa;
    char tip_Piesa;
    char pozitie_Piesa[3];
    char pozitie_Finala[3];

    public:
        piesa();
        virtual ~piesa();
        tabla mutare(int aux, tabla TABLA);
        piesa initializare_Piesa(char piesa);
        //------------------------validare miscari-------------------------
        bool miscari_piesa(tabla TABLA);
        bool miscare_in_cruce(int s,int x, int y, int X, int Y, tabla TABLA);
        bool miscare_pe_diagonala(int s, int x, int y, int X, int Y, tabla TABLA);
        bool miscare_cal(int s, int x, int y, int X, int Y, tabla TABLA);
        bool miscare_pion(int x, int y, int X, int Y, tabla TABLA);
    protected:

    private:
};

#endif // PIESA_H
