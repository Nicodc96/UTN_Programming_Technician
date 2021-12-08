#ifndef MUSICOS_H_INCLUDED
#define MUSICOS_H_INCLUDED
typedef struct
{
    int id;
    char nombre[50];
    int idInstrumento;
    int idOrquesta;
    int isEmpty;

}eMusico;
#include "Orquestas.h"
#include "Instrumentos.h"

eMusico new_Musico(int idMusico, char nombre[], int idInstrumento, int idOrquesta);
int agregarMusico(eMusico musico[], int idMusico, int tamMusicos, eInstrumento instrumento[],int tamInstrumento, eOrquesta orquesta[], int tamOrquesta);

void inicializarMusicos(eMusico musicos[], int tamMusicos);
int buscarIndiceMusico(eMusico musicos[], int tamMusicos, int idParametro);
int buscarLibreMusico(eMusico musicos[], int tamMusicos);
int bajaMusico(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas, eInstrumento instrumentos[], int tamInstrumentos);
void mostrarMusico(eMusico musico, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas);
void mostrarMusicos(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas);

int modificarMusico(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas);
int menuDeModificacionesMusico(eMusico musico, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquesta);

int hardcodearMusicos(eMusico musicos[], int tamMusicos, int cantidad);


#endif // MUSICOS_H_INCLUDED
