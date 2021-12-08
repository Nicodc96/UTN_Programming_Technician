#ifndef INFORMES_H_INCLUDED
#define INFORMES_H_INCLUDED
#include "Musicos.h"
#include "Orquestas.h"
#include "Instrumentos.h"

int informarOrquesta5Musicos(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas);
int listarMusicosDeOrquesta(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas, eInstrumento instrumentos[], int tamInstrumentos);
int informarMusicosCuerdas(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos);

#endif // INFORMES_H_INCLUDED
