#include <iostream>
#include "piesa.h"
#include "tabla.h"
#include <string.h>
#include <stdlib.h>

using namespace std;



///conversia scoate 2 coordonate xyxy sub forma x+1 y x+1 y pentru a evita situatiile precum int = 0123
///trebuie sa decrementati cu 1 valoarea fiecaruia
int conversie(char v[])
{
    char alfabetic[]="abcdefgh";
    int mutare=0;
    int nr=0;
    for(int i=0; i<4; i++)
    {
        if(v[i]>='A' && v[i]<='H') //conversie de la LITERE MARI la litere mici
        {
            v[i]=alfabetic[v[i]-'A'];
        }
//------------------------------------------------------------------------------------------------------------

        if(v[i]>='0' && v[i]<='9') // verificare numar in aschii
        {
            nr=v[i]-'0';
        }else if(v[i]>='a' && v[i]<='h')
        {
            for(int j=0; j<8;j++) //verific litera alfabetului daca corespunde si o transform in numar
            {
                if(v[i]==alfabetic[j])
                {
                    nr=j+1;
                }
            }
        }else{
        exit -1;
        }
        mutare=mutare*10+nr;// concatenez numerele obtinute din converie pentru a forma echivalentul sau
    }
    return mutare;/// nu uita sa decrementezi fiecare valoare la iesire!!
}


int main()
{
    int x=0;
    piesa dummy;
    tabla joc1;
    joc1.ConversieAscii(joc1.Buffer_FEN);
    joc1.initializare_Tabla();
    joc1.afisare();
    x=0;
    do{
        char input[4];
        cin.getline(input,5);
        x= conversie(input);
        system("CLS");
        // x= aux
        joc1.Actualizare_Mutare(dummy.mutare(x, joc1));
        for(int i= 0 ; i < joc1._size ; i++)
            cout<<joc1.FEN[i];
        joc1.afisare();
    }while(x>0);

    return 0;
}
