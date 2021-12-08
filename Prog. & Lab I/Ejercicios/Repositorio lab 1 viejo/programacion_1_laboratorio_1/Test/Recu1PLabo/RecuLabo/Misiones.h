#ifndef MISIONES_H_INCLUDED
#define MISIONES_H_INCLUDED
#include "Fecha.h"
typedef struct
{
    int codigoMision;
    int codigoNave;
    int codigoPiloto;
    char destino[20];
    char riesgo[20];
    eFecha FechLanzamiento;
    eFecha FechaLlegada;
    int isEmpty;
}eMisiones;

int buscarLibreMision(eMisiones misiones[], int tamMisiones);
void inicializarMisiones(eMisiones misiones[], int tamMisiones);
void mostrarMision(eMisiones mision);
void mostrarMisiones(eMisiones misiones[], int tamMisiones);

#endif // MISIONES_H_INCLUDED
