#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "deportes.h"

void mostrarDeportes(eDeporte sports[], int tamDep)
{
    system("cls");
    int i;

    printf("------ LISTA DE DEPORTES ------\n\n");
    printf(" -ID-                -NOMBRE-\n");
    for (i = 0; i < tamDep; i++)
    {
        if(sports != NULL)
        {
            mostrarDeporte(sports[i]);
        }
    }
    printf("\n\n");
}
void mostrarDeporte(eDeporte sport)
{
    printf(" %d   %20s\n", sport.id, sport.descripcion);
}

void cargarDescDeporte(int idSport, eDeporte sports[], int tamSports, char desc[])
{
    int i;
    for (i = 0; i < tamSports; i++)
    {
        if (sports[i].id == idSport)
        {
            strcpy(desc, sports[i].descripcion);
        }
    }
}
