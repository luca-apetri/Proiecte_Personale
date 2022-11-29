#ifndef TABLA_H
#define TABLA_H
#include <iostream>
#include <string.h>
#include <stdlib.h>

using namespace std;

class tabla
{
    public:
        static const unsigned short _capacitate = 120;
        unsigned short _size = 0;
        char FEN[_capacitate];
        char Buffer_FEN[_capacitate];
        //----------FEN VARIABLES------------------
        char Tabla[8][8];
        char Turn;
        char Rocada[4];
        int C_Rocada;
        char En_passant[2];
        int C_En_passant;
        int T_En_passant;
        int Halfmove_clock;
        int Fullmove_number;
        //----------------------------

        tabla();
        virtual ~tabla();
        tabla ActualizareFEN();
        tabla ConversieAscii(char v[]);
        void afisare();
        tabla initializare_Tabla();
        tabla mutare(int aux);
        tabla Actualizare_Mutare(tabla TABLA);
};

#endif // TABLA_H
