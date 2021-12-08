#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include "funcionesABM1.h"

#define TAM 10

int main()
{
    ePersona listaPersonas[TAM];
    char seguir = 's';
    char confirma;
    int listaLegajos = 100;
    char auxSexo;

    inicializarPersonas(listaPersonas, TAM);
    //listaLegajos = listaLegajos + hardcodearPersonas(listaPersonas, TAM, 5);
    do
    {
        switch(menu())
        {
        case 'a':
            if (altaPersonas(listaPersonas, TAM, listaLegajos))
            {
                printf("Se ha ingresado exitosamente una persona!\n");
                listaLegajos++;
            } else
                    {
                        printf("No hay espacio en la lista de personas!\n");
                    }
            break;
        case 'b':
            if (bajaPersona(listaPersonas, TAM) == 1)
            {
                printf("Se ha dado de baja a la persona exitosamente!\n");
            }
            break;
        case 'c':
            break;
        case 'd':
            if (!mostrarPersonas(listaPersonas, TAM))
            {
                printf("\nLa lista se encuentra vacia!\n\n");
            }
            break;
        case 'e':
            break;
        case 'f':
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
            mostrarPorSexo(listaPersonas, TAM, auxSexo);
            break;
        case 'z':
            printf("Confirma salida?: ");
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
