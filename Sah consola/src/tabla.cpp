#include "tabla.h"

tabla::tabla()
{
    C_En_passant=0;
    string _init = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
    size_t temp = _init.size();
    for (size_t i= 0; i < temp; i++)
    {
       FEN[i] = _init[i];
       Buffer_FEN[i] = _init[i];
       _size++;
    }
    C_Rocada = 0;
    Halfmove_clock = 0;
    Fullmove_number = 0;
    T_En_passant = 0;

    //ctor
}

tabla::~tabla()
{
    //dtor
}

tabla tabla::initializare_Tabla()
{
    char rezultat[this->_size];
    for(int i=0; i<=this->_size; i++)
        rezultat[i]=this->FEN[i];
    int x=0;
    for(int i=0; i<8; i++)
    {
        for(int j=0; j<8; j++)
        {
            if(rezultat[x] == '/')
                x++;
            this->Tabla[i][j]=rezultat[x++];
        }
    }
//-------------------------------------- initializarea celorlalte informatii
    x++;// nu scoate incrementarea asta sau se strica programul (nu stiu de ce)
    this->Turn=rezultat[x++];
    x++;
    int z=0;
    this->C_Rocada = 0;
    do{
        this->Rocada[z++]=rezultat[x++];
        this->C_Rocada++;
    }while(rezultat[x]!=' ');
    x++;
    z=0;
    this->C_En_passant = 0;
    do{
            if(rezultat[x] >= 'A' && rezultat[x] < 'Z')
            {
                this->En_passant[z++]=rezultat[x++] - 65;
            }else{
                this->En_passant[z++]=rezultat[x++];
            }
        this->C_En_passant++;

    }while(rezultat[x]!=' ');
    x++;
    this->Halfmove_clock=rezultat[x++]-48;
    x++;
//--------------------------------------- trebuie modificat, solutie temporara
    this->Fullmove_number=0;
    do{
        this->Fullmove_number=(this->Fullmove_number*10)+(rezultat[x++]-48);
    }while('0' <= rezultat[x] && rezultat[x] <= '9');

    return *this;
}


//--------------------------------------------------------------------------------

tabla tabla::ConversieAscii(char v[])
{
    int current_size=0; //the line we're on
    int i=0;//the line we're on v[]
    int j=0;//the line we're on FEN[]

    do
    {
        if(v[i]>='0' && v[i]<='9')
        {
            int nr=v[i]-'0';
            for(int x=0; x<nr; x++)
            {
                this->FEN[j++]='0';
                current_size++;
            }
        }else {
            this->FEN[j++]=v[i];
            current_size++;
        }
            i++;
    }while(v[i]!=' ');// we're until we find a blank space

    for(; i<this->_size;i++)
    {
        this->FEN[j++]=v[i];
        current_size++;
    }

    this->_size = current_size;

    return *this;
}



void tabla::afisare()
{
    int linii=1; // afisare numerotare linii
    int coloane=0; // contorizare coloane
    string alfabetic="abcdefgh"; // afisare numerotare coloane

    cout<<endl<<" ";
    for(;coloane<8;coloane++)
        cout<<" "<<alfabetic[coloane]; //afisare coloane
    cout<<endl;

    for(int i=0; i<8; i++)
    {
        cout <<linii<<" ";
        for(int j=0; j<8; j++)
           cout << this->Tabla[i][j]<<" ";
        linii++;
        cout<< endl;
    }
}


///luam conversia mutarilor si executam mutarea fara a verifica
tabla tabla::mutare(int aux)
{
    int i=0;
    char miscari[4];
    while(aux!=0)
    {
        miscari[i]=aux%10-1;
        aux/=10;
        i++;
    }
    this->Tabla[miscari[0]][miscari[1]]=this->Tabla[miscari[2]][miscari[3]];
    this->Tabla[miscari[2]][miscari[3]]='0';
    return *this;
}

tabla tabla::Actualizare_Mutare(tabla TABLA) //actualizeaza strict tabla in FEN
{
    this->_size=TABLA._size;
    int y = 0;
    int x = 0;
    for (size_t i= 0; i < TABLA._size; i++)
    {
        if(x==8 && i<7) //pune "/" urile intre randuri
        {
            x=0;
            this->FEN[x]='/';
            this->Buffer_FEN[x++] = '/';
            i--;
        }else{
            this->FEN[x] = TABLA.FEN[i];
            this->Buffer_FEN[x++] = TABLA.FEN[i];
        }
    }
    this->initializare_Tabla();

    return *this;
}

//--------------------------------------------------------------------------------
tabla tabla::ActualizareFEN()
{
    int x=0;
    for(int i=0 ; i<8 ; i++ ) // tabla
    {
        for(int j=0 ; j<8 ; j++)
        {
            this->FEN[x++]=Tabla[i][j];
        }
        if(i<7)
            this->FEN[x++]='/';  ///adaugata acum
    }
    //--------------------------------------------
    this->FEN[x++]=' ';
    this->FEN[x++]=this->Turn; // turn
    //--------------------------------------------
    this->FEN[x++]=' ';
    for(int i = 0; i < this->C_Rocada ; i++ )
    {
        this->FEN[x++]=this->Rocada[i];
    }
    //--------------------------------------------
    this->FEN[x++]=' ';
    for(int i=0 ; i < this->C_En_passant; i++) // En passant
    {
        if(this->En_passant[i] != '-' && i == 0)
        {
            this->FEN[x++]=this->En_passant[i] + 17;
        }else{
            this->FEN[x++]=this->En_passant[i];
        }

    }

    //--------------------------------------------
    this->FEN[x++]=' ';
    this->FEN[x++]=this->Halfmove_clock + 48;
    //--------------------------------------------
    this->FEN[x++]=' ';
    cout<<this->Fullmove_number<<endl;
    this->FEN[x++]=this->Fullmove_number + 48;
    this->_size = x;

    for(int i=0; i<this->_size;i++)
    {
        this->Buffer_FEN[i]=this->FEN[i];
    }
    return *this;
}
