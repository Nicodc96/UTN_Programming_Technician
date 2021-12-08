#include <stdio.h>
#include <stdlib.h>
#include "Misiones.h"
#include "Pilotos.h"
#include "Naves.h"

int altaMision(eMisiones misiones[], int tamMisiones, ePiloto pilotos[], int tamPilotos, eNave naves[], int tamNaves)
{
    int isOk = 0, checkMision;
    system("cls");
    printf("------ ALTAS MISIONES | AGENCIA ------\n\n");
    checkMision = buscarLibreMision(misiones, tamMisiones);
    if(checkMision == -1)
    {
        printf("No se pudo agregar una mision! Lista llena\n");
    } else
        {
            printf("Ingrese ")
        }
}

int buscarLibreMision(eMisiones misiones[], int tamMisiones)
{
    int i, indice = -1;
    for (i = 0; i < tamMisiones; i++)
    {
        if(misiones[i].isEmpty == 1)
        {
            indice = i;
        }
    }
    return indice;
}

void inicializarMisiones(eMisiones misiones[], int tamMisiones)
{
    int i;
    for(i = 0; i < tamMisiones; i++)
    {
        misiones[i].isEmpty = 1;
    }
}

void mostrarMision(eMisiones mision)
{
    printf(" %d  %d  %d  %10s %10s %d/%d/%d   %d/%d/%d\n", mision.codigoMision, mision.codigoNave, mision.codigoPiloto, mision.destino, mision.riesgo, mision.FechaLlegada.dia, mision.FechaLlegada.mes, mision.FechaLlegada.anio, mision.FechLanzamiento.dia, mision.FechLanzamiento.mes, mision.FechLanzamiento.anio);
}

void mostrarMisiones(eMisiones misiones[], int tamMisiones)
{
    int i;
    for(i = 0; i < tamMisiones; i++)
    {
        if(misiones[i].isEmpty == 0)
        {
            mostrarMision(misiones[i]);
        }
    }
}
