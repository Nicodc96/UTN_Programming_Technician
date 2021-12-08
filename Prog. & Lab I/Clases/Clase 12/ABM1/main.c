#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include "funcionesABM1.h"
#include "deportes.h"
#include "fechas.h"

#define TAM 20
#define TAMDEP 6

int main()
{
    ePersona listaPersonas[TAM];
    eDeporte listaDeportes[TAMDEP] = {
        {1000, "No practica"},
        {1001, "Bicicleta"},
        {1002, "Patin"},
        {1003, "Esqui"},
        {1004, "Surf"},
        {1005, "Parapente"}
    };
    char seguir = 's';
    char confirma;
    int listaLegajos = 100;
    char auxSexo;

    inicializarPersonas(listaPersonas, TAM);
    listaLegajos = listaLegajos + hardcodearPersonas(listaPersonas, TAM, 10);
    do
    {
        switch(menu())
        {
        case 'a':
            if (altaPersonas(listaPersonas, TAM, listaLegajos, listaDeportes, TAMDEP))
            {
                printf("Se ha ingresado exitosamente una persona!\n");
                listaLegajos++;
            } else
                    {
                        printf("No hay espacio en la lista de personas!\n");
                    }
            break;
        case 'b':
            if (bajaPersona(listaPersonas, TAM, listaDeportes, TAMDEP))
            {
                printf("Se ha dado de baja a la persona exitosamente!\n");
            }
            break;
        case 'c':
            break;
        case 'd':
            if (!mostrarPersonas(listaPersonas, TAM, listaDeportes, TAMDEP))
            {
                printf("\nLa lista se encuentra vacia!\n\n");
            }
            break;
        case 'e':
            mostrarDeportes(listaDeportes, TAMDEP);
            break;
        case 'f':
            informeMenuCases(listaPersonas, TAM, listaDeportes, TAMDEP);
            break;
        case 'g':
            printf("Ingrese que sexo quiere ver 'm' o 'f': ");
            fflush(stdin);
            scanf("%c", &auxSexo);
            while (auxSexo != 'f' && auxSexo != 'm')
            {
                printf("ERROR! Reingrese 'm' o 'f': ");
                fflush(stdin);
                scanf("%c", &auxSexo);
            }
            mostrarPorSexo(listaPersonas, TAM, auxSexo, listaDeportes, TAMDEP);
            break;
        case 'z':
            printf("Confirma salida? (s/n): ");
            fflush(stdin);
            scanf("%c", &confirma);
            confirma = tolower(confirma);
            if(confirma == 's')
            {
                seguir = 'n';
            }
            break;
        default:
            printf("Opcion invalida!\n\n");
        }
        system("pause");
    }
    while( seguir == 's');

    return 0;
}
