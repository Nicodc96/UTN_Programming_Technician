#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "Orquestas.h"

eOrquesta new_Orquesta(int id, int tipoOrquesta, char descTipo[])
{
    eOrquesta nuevo;

    nuevo.id = id;
    nuevo.tipo = tipoOrquesta;
    strcpy(nuevo.descTipo, descTipo);
    nuevo.isEmpty = 0;

    return nuevo;
}

int agregarOrquesta(eOrquesta orquesta[], int tamOrquesta, int idOrquesta)
{
    int isOk = 0, intentos = 3;
    int indiceOrquesta;
    char auxNombre[50];
    int auxTipo;

    system("cls");
    printf("--------- AGREGAR ORQUESTA | ORQUESTAS ---------\n\n");
    indiceOrquesta = buscarLibreOrquesta(orquesta, tamOrquesta);
    if(indiceOrquesta == -1)
    {
        printf("No es posible agregar Orquestas! Lista llena!\n");
    } else
        {
            mostrarTiposOrquesta();
            printf("Ingrese el tipo de Orquesta: ");
            fflush(stdin);
            gets(auxNombre);
            strlwr(auxNombre);
            while(checkOrquesta(auxNombre) == -1 && intentos != 0)
            {
                intentos--;
                printf("El tipo de orquesta ingresado no existe\n");
                printf("Intentos restantes: %d!\n", intentos);
                printf("Reingrese tipo de orquesta: ");
                fflush(stdin);
                gets(auxNombre);
                strlwr(auxNombre);
            }
            if(intentos == 0)
            {
                printf("\nNumero de intentos agotados! No se pudo agregar la Orquesta!\n");
            } else
                {
                    auxTipo = valorOrquesta(auxNombre);
                    auxNombre[0] = toupper(auxNombre[0]);
                    orquesta[indiceOrquesta] = new_Orquesta(idOrquesta, auxTipo, auxNombre);
                    printf("\nSe ha agregado una nueva Orquesta exitosamente!\n");
                    isOk = 1;
                }
        }

    return isOk;
}

void inicializarOrquestas(eOrquesta orquesta[], int tamOrquesta)
{
    int i;
    for(i = 0; i < tamOrquesta; i++)
    {
        orquesta[i].isEmpty = 1;
    }
}

int buscarIndiceOrquesta(eOrquesta orquesta[], int tamOrquesta, int idParametro)
{
    int i, isOk = -1;
    for(i = 0; i < tamOrquesta; i++)
    {
        if (idParametro == orquesta[i].id)
        {
            isOk = i;
            break;
        }
    }
    return isOk;
}

int buscarLibreOrquesta(eOrquesta orquesta[], int tamOrquesta)
{
    int i, indice = -1;
    for(i = 0; i < tamOrquesta; i++)
    {
        if (orquesta[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

void mostrarTiposOrquesta()
{
    printf("--- TIPOS DE ORQUESTA DISPONIBLES ---\n");
    printf("- Sinfonica\n");
    printf("- Filarmonica\n");
    printf("- Camara\n");
}

int checkOrquesta(char* nombreOrquesta)
{
    int existeOrquesta = -1;
    if(strcmp(nombreOrquesta, "sinfonica") == 0 || strcmp(nombreOrquesta, "filarmonica") == 0 || strcmp(nombreOrquesta, "camara") == 0)
    {
        existeOrquesta = 0;
    }
    return existeOrquesta;
}

int valorOrquesta(char* nombreOrquesta)
{
    int tipoOrquesta;
    if(strcmp(nombreOrquesta, "sinfonica") == 0)
    {
        tipoOrquesta = 0;
    }
    if(strcmp(nombreOrquesta, "filarmonica") == 0)
    {
        tipoOrquesta = 1;
    }
    if(strcmp(nombreOrquesta, "camara") == 0)
    {
        tipoOrquesta = 2;
    }
    return tipoOrquesta;
}

void mostrarOrquesta(eOrquesta orquesta)
{
    printf("   %2d                %d          %15s\n", orquesta.id, orquesta.tipo, orquesta.descTipo);
}

void mostrarOrquestas(eOrquesta orquesta[], int tamOrquesta)
{
    int i;
    printf("--------- ORQUESTAS ACTIVAS | ORQUESTAS ---------\n\n");
    printf(" - ID - || - TIPO DE ORQUESTA - || - DESCRIPCION -\n");
    for (i = 0; i < tamOrquesta; i++)
    {
        if(orquesta[i].isEmpty == 0)
        {
            mostrarOrquesta(orquesta[i]);
        }
    }
}

int buscarIDOrquesta(eOrquesta orquesta[], int tamOrquesta, int id)
{
    int i, isOk = 0;
    for (i = 0; i < tamOrquesta; i++)
    {
        if(orquesta[i].id == id)
        {
            isOk = 1;
            break;
        }
    }
    return isOk;
}

int bajaOrquesta(eOrquesta orquesta[], int tamOrquesta)
{
    int isOk = 0, intentos = 3, idOrquesta, checkIndice;
    char respuesta;
    system("cls");
    printf("--------- BAJA ORQUESTA | ORQUESTAS ---------\n\n");
    mostrarOrquestas(orquesta, tamOrquesta);
    printf("Ingrese el ID de la Orquesta: ");
    scanf("%d", &idOrquesta);

    checkIndice = buscarIndiceOrquesta(orquesta, tamOrquesta, idOrquesta);
    if (checkIndice == -1)
    {
        printf("No se ha encontrado la orquesta con el ID ingresado!\n");
    } else
        {
            printf("Confirmar baja (y/n): ");
            fflush(stdin);
            scanf("%c", &respuesta);
            while(respuesta != 'y' && respuesta != 'n' && intentos != 0)
            {
                intentos--;
                printf("Intentos restantes: %d\n", intentos);
                printf("Respuesta incorrecta! Ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &respuesta);
            }
            if(!intentos)
            {
                printf("Demasiados intentos fallidos! Se ha cancelado la operacion!\n");
                return isOk;
            }
            if(respuesta == 'y')
            {
                orquesta[checkIndice].isEmpty = 1;
                isOk = 1;
            } else
                {
                    printf("Se ha cancelado exitosamente la operacion!\n");
                }
        }
    return isOk;
}

int cargarDescOrquesta(eOrquesta orquesta[], int tamOrquesta, int idOrquesta, char descripcion[])
{
    int i, isOk = 0;
    for(i = 0; i < tamOrquesta; i++)
    {
        if(idOrquesta == orquesta[i].id)
        {
            strcpy(descripcion, orquesta[i].descTipo);
            isOk = 1;
            break;
        }
    }
    return isOk;
}

int hardcodearOrquestas(eOrquesta orquesta[], int tamOrquesta, int cantidad)
{
    int contador = 0, i;
    eOrquesta listaAuxiliar[] = {
    {50, 2, "Camara", 0},
    {51, 1, "Filarmonica", 0},
    {52, 2, "Camara", 0},
    {53, 0, "Sinfonica", 0},
    {54, 1, "Filarmonica", 0},
    {55, 0, "Sinfonica", 0},
    {56, 2, "Camara", 0}
    };
    if(cantidad <= 7 && cantidad <= tamOrquesta)
    {
        for(i = 0; i < cantidad; i++)
        {
            orquesta[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}
