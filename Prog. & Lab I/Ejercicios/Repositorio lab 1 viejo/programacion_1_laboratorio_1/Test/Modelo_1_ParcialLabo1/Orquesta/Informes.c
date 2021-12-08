#include <stdio.h>
#include <stdlib.h>
#include "Informes.h"
#include "Musicos.h"
#include "Orquestas.h"
#include "Instrumentos.h"

int informarOrquesta5Musicos(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas)
{
    int i, j, contador = 0, isOk = 0;
    for(i = 0; i < tamOrquestas; i++)
    {
        for(j = 0; j < tamMusicos; j++)
        {
            if(orquestas[i].isEmpty == 0 && musicos[i].isEmpty == 0 && orquestas[i].id == musicos[j].idOrquesta)
            {
                contador++;
            }
        }
        if(orquestas[i].isEmpty == 0 && contador >= 5)
        {
            printf("\nOrquesta ID: %d\n", orquestas[i].id);
            printf("Orquesta Tipo: %s\n", orquestas[i].descTipo);
            printf("Cantidad de Musicos: %d\n\n", contador);
            isOk = 1;
        }
        contador = 0;
    }
    if(contador < 5 && !isOk)
    {
        printf("No se registran orquestas con mas de 5 musicos!\n");
    }
    return isOk;
}

int listarMusicosDeOrquesta(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas, eInstrumento instrumentos[], int tamInstrumentos)
{
    int isOk = 0, i, j, auxIdOrquesta, checkIdOrquesta;
    system("cls");
    printf("--------- INFORMES | ORQUESTA ---------\n\n");
    mostrarOrquestas(orquestas, tamOrquestas);
    printf("Ingrese el ID de la orquesta: ");
    scanf("%d", &auxIdOrquesta);
    checkIdOrquesta = buscarIndiceOrquesta(orquestas, tamOrquestas, auxIdOrquesta);
    if(checkIdOrquesta == -1)
    {
        printf("No se ha encontrado la orquesta con el ID ingresado!\n");
    } else
        {
            printf("  - ID -  ||    - NOMBRE -    ||  - INSTRUMENTO -  || - ORQUESTA ACTUAL - \n\n");
            for(i = 0; i < tamMusicos; i++)
            {
                if(musicos[i].isEmpty == 0 && musicos[i].idOrquesta == auxIdOrquesta)
                {
                    for(j = 0; j < tamOrquestas; j++)
                    {
                        if(orquestas[j].isEmpty == 0 && orquestas[j].id == musicos[i].idOrquesta)
                        {
                            mostrarMusico(musicos[i], instrumentos, tamInstrumentos, orquestas, tamOrquestas);
                            isOk = 1;
                        }
                    }
                }
            }
            if(!isOk)
            {
                printf("No se registran musicos en la orquesta seleccionada!\n");
            }
        }
    return isOk;
}

int informarMusicosCuerdas(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos)
{
    int isOk = 0, i, j;
    char descInstrumento[50];
    printf("  - ID -  ||    - NOMBRE -    ||  - INSTRUMENTO -  || \n\n");
    for(i = 0; i < tamInstrumentos; i++)
    {
        if(instrumentos[i].isEmpty == 0 && instrumentos[i].tipo == 1)
        {
            for (j = 0; j < tamMusicos; j++)
            {
                if(musicos[j].isEmpty == 0 && musicos[j].idInstrumento == instrumentos[i].id)
                {
                    cargarDescIntrumento(instrumentos, tamInstrumentos, musicos[j].idInstrumento, descInstrumento);
                    printf("  %4d   %15s       %15s\n", musicos[j].id, musicos[j].nombre, descInstrumento);
                    isOk = 1;
                }
            }
        }
    }

    return isOk;
}
