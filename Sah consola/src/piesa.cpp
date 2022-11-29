#include "piesa.h"

piesa::piesa()
{
    culoare_Piesa='w';
    //ctor
}


piesa piesa::initializare_Piesa(char piesa)
{
    if( 'a' < piesa && piesa < 'z' )
    {
        this->tip_Piesa = piesa;
        this->culoare_Piesa = 'w';
    }else{
        this->culoare_Piesa = 'b';
        this->tip_Piesa = piesa+32;

    }
    return *this;
}

piesa::~piesa()
{
    //dtor
}


bool piesa::miscari_piesa(tabla TABLA)
{
    if(this->culoare_Piesa != TABLA.Turn)
        return false;

    int x = this->pozitie_Piesa[2];
    int y = this->pozitie_Piesa[1];
    int X = this->pozitie_Finala[2];
    int Y = this->pozitie_Finala[1];
    int s;
    if(TABLA.Turn == 'w')
    {
        s=32;
    }else{
        s=0;
    }
    switch(this->tip_Piesa) //-------------------switch---------------
        {
            case 'p':
                if(this->miscare_pion(x, y, X, Y, TABLA) == true)
                    return true;
                return false;
                break;

            case 'r':
                if(this->miscare_in_cruce(s, x, y, X, Y, TABLA) == true)
                    return true;
                return false;
                break;

            case 'n':
                if(this->miscare_cal(s, x, y, X, Y, TABLA) == true)
                     return true;
                return false;
                break;

            case 'b':
                if(this->miscare_pe_diagonala(s , x, y, X, Y, TABLA) == true)
                    return true;
                return false;
                break;

            case 'q':
                if(this->miscare_in_cruce(s, x, y, X, Y, TABLA) == true || this->miscare_pe_diagonala(s , x, y, X, Y, TABLA) == true)
                    return true;
                return false;
                break;

            case 'k':
                if(this->miscare_cal(s, x, y, X, Y, TABLA) || this->miscare_in_cruce(s, x, y, X, Y, TABLA) == true || this->miscare_pe_diagonala(s , x, y, X, Y, TABLA) == true)
                    return true;
                return false;
                break;
        }
    return false;
}


tabla piesa::mutare(int aux, tabla TABLA)
{
    int i=0;
    char miscari[4];
    char piece;
    int xua= aux;
    while(aux!=0)
    {
        miscari[i]=aux%10-1;
        aux/=10;
        i++;
    }
    piece = TABLA.Tabla[miscari[2]][miscari[3]];
    int x =this->pozitie_Piesa[2]=miscari[2]; //x
    int y =this->pozitie_Piesa[1]=miscari[3]; //y
    int X =this->pozitie_Finala[2]=miscari[0]; //X
    int Y =this->pozitie_Finala[1]=miscari[1]; //Y

    // apelam clasa piesa si lucram cu funtiile specifice ei pentru validare
    this->initializare_Piesa(piece);

    if(TABLA.C_En_passant != 1)
    {
        TABLA.C_En_passant = 1;
        TABLA.En_passant[1]= '-';
        TABLA.En_passant[0]= '-';
    }

    if(this->miscari_piesa(TABLA) == true)
    {
        if(this->tip_Piesa == 'p')
        {
            if(x==1 && x+2 == X && y == Y)
            {
                TABLA.C_En_passant=2;
                TABLA.En_passant[1]=X + 48;
                TABLA.En_passant[0]=Y + 48;
            }
            else if(x == 6 && x-2 == X && y == Y)
            {
                TABLA.C_En_passant=2;
                TABLA.En_passant[1]=X + 48;
                TABLA.En_passant[0]=Y + 48;
            }
        }
        TABLA.mutare(xua);
        if(TABLA.Turn == 'w')
        {
            TABLA.Turn ='b';
            TABLA.Halfmove_clock = 1;
        }else{
            TABLA.Turn ='w';
            TABLA.Halfmove_clock = 0;
        }


        TABLA.Fullmove_number+= 1;
        cout<<TABLA.Fullmove_number<<endl;

    }else{
        cout<<endl<<"Miscarea pe care incercati sa o realizati este invalida! Try again, input format: A2A4"<<endl;
    }
    TABLA.ActualizareFEN();
    return TABLA;
}

bool piesa::miscare_in_cruce(int s, int x, int y, int X, int Y, tabla TABLA)
{
    bool loop1= true;
    bool loop2= true;
    bool loop3= true;
    bool loop4= true;
    //cout << x << y << X << Y;
    //TABLA.afisare();
    for(int i=1; i < 8; i++) // incepe de la 1 deoarece se oprea citindu-se pe sine
    {
        if(0 <= (x+i) && (x+i)  < 8 && loop1 != false)            //loop1
        {
            if(TABLA.Tabla[x+i][y] == '0' && loop1 != false)
            {
                if((x+i)==X && y == Y)
                    return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x+i][y] && TABLA.Tabla[x+i][y] < ('z'-s) && loop1 != false)
                {
                    if((x+i)==X && y == Y)
                        return true;
                    }
                loop1 = false;
                //cout<< "loop1";
            }
        }

        if(0 <= (x-i) && (x-i)  < 8 && loop2 != false)            //loop2
        {
            if(TABLA.Tabla[x-i][y] == '0' && loop1 != false)
            {
                if((x-i)==X && y == Y)
                    return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x-i][y] && TABLA.Tabla[x-i][y] < ('z'-s) && loop2 != false)
                {
                    if((x-i)==X && y == Y)
                        return true;
                }
                loop2 = false;
                //cout<< "loop2";
            }
        }

        if(0 <= (y+i) && (y+i)  < 8 && loop3 != false)            //loop3
        {
            if(TABLA.Tabla[x][y+i] == '0' && loop3 != false)
            {
                if(x==X && (y+i) == Y)
                    return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x][y+i] && TABLA.Tabla[x][y+i] < ('z'-s) && loop3 != false)
                {
                    if(x==X && (y+i) == Y)
                        return true;
                }
                loop3 = false;
                //cout<< "loop3";
            }
        }

        if(0 <= (y-i) && (y-i)  < 8 && loop4 != false)            //loop4
        {
            if(TABLA.Tabla[x][y-i] == '0' && loop4 != false)
            {
                if(x==X && (y-i) == Y)
                    return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x][y-i] && TABLA.Tabla[x][y-i] < ('z'-s) && loop4 != false)
                {
                    if(x==X && (y-i) == Y)
                        return true;
                }
                loop4 = false;
                //cout<< "loop4";
            }
        }
    }
    return false;
}

bool piesa::miscare_pe_diagonala(int s, int x, int y, int X, int Y, tabla TABLA)
{
    bool loop1= true;
    bool loop2= true;
    bool loop3= true;
    bool loop4= true;

    for(int i=1; i < 8; i++)
    {
        if(0 <= (x+i) &&(x+i) < 8 && 0 <= (y+i) && (y+i) < 8 && loop1 != false)         //loop1
        {
            if(TABLA.Tabla[x+i][y+i] == '0' && loop1 != false)
            {
                if((x+i)==X && (y+i) == Y)
                return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x+i][y+i] && TABLA.Tabla[x+i][y+i] < ('z'-s) && loop1 != false)
                {
                    if((x+i)==X && (y+i) == Y)
                    return true;
                }
                loop1 = false;
            }
        }

        if(0 <= (x-i) &&(x-i) < 8 && 0 <= (y-i) && (y-i) < 8 && loop2 != false)         //loop2
        {
            if(TABLA.Tabla[x-i][y-i] == '0' && loop2 != false)
            {
                if((x-i)==X && (y-i) == Y)
                return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x-i][y-i] && TABLA.Tabla[x-i][y-i] < ('z'-s) && loop2 != false)
                {
                    if((x-i)==X && (y-i) == Y)
                    return true;
                }
                loop2 = false;
            }
        }

        if(0 <= (x-i) &&(x-i) < 8 && 0 <= (y+i) && (y+i) < 8 && loop3 != false)         //loop3
        {
            if(TABLA.Tabla[x-i][y+i] == '0' && loop3 != false)
            {
                if((x-i)==X && (y+i) == Y)
                return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x-i][y+i] && TABLA.Tabla[x-i][y+i] < ('z'-s) && loop3 != false)
                {
                    if((x-i)==X && (y+i) == Y)
                    return true;
                }
                loop3 = false;
            }

        }

        if(0 <= (x+i) &&(x+i) < 8 && 0 <= (y-i) && (y-i) < 8 && loop4 != false)         //loop4
        {
            if(TABLA.Tabla[x+i][y-i] == '0' && loop4 != false)
            {
                if((x+i)==X && (y-i) == Y)
                return true;
            }else{
                if(('a'-s) < TABLA.Tabla[x+i][y-i] && TABLA.Tabla[x+i][y-i] < ('z'-s) && loop4 != false)
                {
                    if((x+i)==X && (y-i) == Y)
                    return true;
                }
                loop4 = false;
            }
        }


    }
    return false;
}

bool piesa::miscare_cal(int s, int x, int y, int X, int Y, tabla TABLA)
{
    if(0 <= (x+1) < 8 && 0 <= (y+2) < 8)
    {
        if(TABLA.Tabla[x+1][y+2] == '0'   || (('a'-s) < TABLA.Tabla[x+1][y+2] && TABLA.Tabla[x+1][y+2] < ('z'-s)) )
        {
            if((x+1)==X && (y+2) == Y)
            return true;
        }
    }
    if(0 <= (x+1) < 8 && 0 <= (y-2) < 8)
    {
        if(TABLA.Tabla[x+1][y-2] == '0'   || (('a'-s) < TABLA.Tabla[x+1][y-2] && TABLA.Tabla[x+1][y-2] < ('z'-s)) )
        {
            if((x+1)==X && (y-2) == Y)
            return true;
        }
    }
    if(0 <= (x-1) < 8 && 0 <= (y+2) < 8)
    {
        if(TABLA.Tabla[x-1][y+2] == '0'   || (('a'-s) < TABLA.Tabla[x-1][y+2]&& TABLA.Tabla[x-1][y+2] < ('z'-s)) )
        {
            if((x-1)==X && (y+2) == Y)
            return true;
        }
    }
    if(0 <= (x-1) < 8 && 0 <= (y-2) < 8)
    {
        if(TABLA.Tabla[x-1][y-2] == '0'   || (('a'-s) < TABLA.Tabla[x-1][y-2] && TABLA.Tabla[x-1][y-2] < ('z'-s)) )
        {
            if((x-1)==X && (y-2) == Y)
            return true;
        }
    }
    if(0 <= (x+2) < 8 && 0 <= (y-1) < 8)
    {
        if(TABLA.Tabla[x+2][y-1] == '0'   || (('a'-s) < TABLA.Tabla[x+2][y-1] && TABLA.Tabla[x+2][y-1] < ('z'-s)) )
        {
            if((x+2)==X && (y-1) == Y)
            return true;
        }
    }
    if(0 <= (x+2) < 8 && 0 <= (y+1) < 8)
    {
        if(TABLA.Tabla[x+2][y+1] == '0'   || (('a'-s) < TABLA.Tabla[x+2][y+1] && TABLA.Tabla[x+2][y+1]< ('z'-s)) )
        {
            if((x+2)==X && (y+1) == Y)
            return true;
        }
    }
    if(0 <= (x-2) < 8 && 0 <= (y-1) < 8)
    {
        if(TABLA.Tabla[x-2][y-1] == '0'   || (('a'-s) < TABLA.Tabla[x-2][y-1] && TABLA.Tabla[x-2][y-1] < ('z'-s)) )
        {
            if((x-2)==X && (y-1) == Y)
            return true;
        }
    }
    if(0 <= (x-2) < 8 && 0 <= (y+1) < 8)
    {
        if(TABLA.Tabla[x-2][y+1] == '0'   || (('a'-s) < TABLA.Tabla[x-2][y+1] && TABLA.Tabla[x-2][y+1] < ('z'-s)) )
        {
            if((x-2)==X && (y+1) == Y)
            return true;
        }
    }
    return false;
}

bool piesa::miscare_pion(int x, int y, int X, int Y, tabla TABLA)
{
    if(this->culoare_Piesa == 'w')
    {
        if(x+1 == X && y == Y)//--------------
        {
            if(TABLA.Tabla[X][Y] =! '0' )
                    return false;
                return true;
        }
        if(x==1 && x+2 == X && y == Y) //---------------
        {
            if(TABLA.Tabla[X][Y] =! '0' )
                return false;
            /*
            TABLA.C_En_passant=2;
            TABLA.En_passant[1]=Y + 48;
            TABLA.En_passant[0]=X + 48;*/

            return true;
        }
        if(x+1 == X && y-1 == Y)//--------------
        {
            if('A' < TABLA.Tabla[X][Y] && TABLA.Tabla[X][Y] < 'Z')
            {
                return true;
            }
            return false;
        }
        if(x+1 == X && y+1 == Y)//------------------------
        {
            if('A' < TABLA.Tabla[X][Y] && TABLA.Tabla[X][Y] < 'Z')
            {
                return true;
            }
            return false;
        }
        return false;
    }else{ //---------------------------------------------- ELSE-UL IF-ULUI MARE
            if(x-1 == X && y == Y)
            {
                if(TABLA.Tabla[X][Y] =! '0' )
                    return false;
                return true;
            }
            if(x == 6 && x-2 == X && y == Y) // verificare En_Passant
            {
                if(TABLA.Tabla[X][Y] =! '0' )
                    return false;
                /*
                TABLA.C_En_passant=2;
                TABLA.En_passant[1]=Y + 48;
                TABLA.En_passant[0]=X + 48;*/
                return true;
            }
            if(x-1 == X && y-1 == Y)
            {
                if('a' < TABLA.Tabla[X][Y] && TABLA.Tabla[X][Y] < 'z')
                    return true;
                return false;
            }
            if(x-1 == X && y+1 == Y)
            {
                if('a' < TABLA.Tabla[X][Y] && TABLA.Tabla[X][Y] < 'z')
                    return true;
                return false;
            }
            return false;

    }
    return false;
}
