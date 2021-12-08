#include <stdio.h>
#include <stdlib.h>
#include "Pilotos.h"

int hardcodearPilotos(ePiloto pilotos[], int tamPilotos, int cantidad)
{
    int i, contador = 0;
    ePiloto listaAuxiliar[] = {
    {1, "Neil", "Armstrong", 'm', 0},
    {2, "Yuri", "Gagarin", 'f', 0},
    {3, "David", "Scott", 'm', 0},
    {4, "Buzz", "Aldrin", 'm', 0},
    {5, "Sally", "Ride", 'f', 0},
    {6, "Michael", "Collins", 'm', 0},
    {7, "Alan", "Shepard", 'm', 0}
    };
    if(cantidad <= 7 && cantidad < tamPilotos)
    {
        for(i = 0; i < cantidad; i++)
        {
            pilotos[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}

void mostrarPiloto(ePiloto piloto)
{
    printf("     %1d   %15s     %15s            %c\n", piloto.codigo, piloto.nombre, piloto.apellido, piloto.sexo);
}

void mostrarPilotos(ePiloto pilotos[], int tamPilotos)
{
    int i;
    printf("--------- PILOTOS ACTIVOS | AGENCIA ---------\n\n");
    printf("  - ID -  ||   - NOMBRE -   ||   - APELLIDO -   ||  - SEXO -  ||\n\n");
    for (i = 0; i < tamPilotos; i++)
    {
        if (pilotos[i].isEmpty == 0)
        {
            mostrarPiloto(pilotos[i]);
        }
    }
}

void inicializarPilotos(ePiloto pilotos[], int tamPilotos)
{
    int i;
    for (i = 0; i < tamPilotos; i++)
    {
        pilotos[i].isEmpty = 1;
    }
}
