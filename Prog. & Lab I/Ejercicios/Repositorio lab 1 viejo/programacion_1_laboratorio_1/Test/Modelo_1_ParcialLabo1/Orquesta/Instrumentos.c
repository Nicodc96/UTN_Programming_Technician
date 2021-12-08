#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "Instrumentos.h"

eInstrumento new_Instrumento(int idInstrumento, char nombre[], int tipo, char descTipo[])
{
    eInstrumento nuevo;

    nuevo.id = idInstrumento;
    strcpy(nuevo.nombre, nombre);
    nuevo.tipo = tipo;
    strcpy(nuevo.descTipo, descTipo);
    nuevo.isEmpty = 0;

    return nuevo;
}

int agregarInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int idInstrumento)
{
    int isOk = 0, checkIndice, intentos = 3;
    char auxNombre[50];
    char auxTipoDesc[50];
    int tipo;

    system("cls");
    printf("--------- AGREGAR INSTRUMENTOS | ORQUESTAS ---------\n\n");
    checkIndice = buscarLibreInstrumento(instrumentos, tamInstrumentos);
    if(checkIndice == -1)
    {
        printf("No es posible agregar un instrumento! Lista llena!\n");
    } else
        {
            printf("Ingrese el nombre del instrumento: ");
            fflush(stdin);
            gets(auxNombre);
            while(strlen(auxNombre) > 15 && intentos != 0)
            {
                intentos--;
                printf("Error! Nombre del instrumento ingresado demasiado largo!\n");
                printf("Intentos restantes: %d\n", intentos);
                printf("Reingrese nombre del instrumento: ");
                fflush(stdin);
                gets(auxNombre);
            }
            if(!intentos)
            {
                printf("Se han agotados los intentos disponibles! No se pudo agregar el instrumento!\n");
                return isOk;
            }
            strlwr(auxNombre);
            auxNombre[0] = toupper(auxNombre[0]);
            mostrarTiposInstrumentos();
            printf("Ingrese el tipo de instrumento: ");
            scanf("%d", &tipo);
            while(checkInstrumento(tipo, auxTipoDesc) == 0 && intentos != 0)
            {
                intentos--;
                printf("Error! Tipo de instrumento incorrecto!\n");
                printf("Intentos restantes: %d\n", intentos);
                printf("Reingrese el tipo de instrumento: ");
                scanf("%d", &tipo);
            }
            if(!intentos)
            {
                printf("Se han agotados los intentos disponibles! No se pudo agregar el instrumento!\n");
                return isOk;
            }
            instrumentos[checkIndice] = new_Instrumento(idInstrumento, auxNombre, tipo, auxTipoDesc);
            printf("Se ha agregado exitosamente el instrumento!\n");
            isOk = 1;
        }
    return isOk;
}

int buscarLibreInstrumento(eInstrumento instrumentos[], int tamInstrumentos)
{
    int indice = -1, i;
    for (i = 0; i < tamInstrumentos; i++)
    {
        if(instrumentos[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }

    return indice;
}

int buscarIndiceInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int idParametro)
{
    int i, indice = -1;
    for(i = 0; i < tamInstrumentos; i++)
    {
        if(idParametro == instrumentos[i].id)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

void inicializarInstrumentos(eInstrumento instrumentos[], int tamInstrumentos)
{
    int i;
    for(i = 0; i < tamInstrumentos; i++)
    {
        instrumentos[i].isEmpty = 1;
    }
}

void mostrarTiposInstrumentos()
{
    printf("--- TIPO DE INSTRUMENTOS -----\n");
    printf("1) Cuerdas\n");
    printf("2) Viento-madera\n");
    printf("3) Viento-metal\n");
    printf("4) Percusion\n");
}

int checkInstrumento(int tipo, char* descTipo)
{
    int isOk = 0;
    if(tipo > 0 && tipo <= 4)
    {
        switch(tipo)
        {
        case 1:
            //*descTipo = "Cuerdas";
            strcpy(descTipo, "Cuerdas");
            isOk = 1;
            break;
        case 2:
            //*descTipo = "Viento-madera";
            strcpy(descTipo, "Viento-madera");
            isOk = 1;
            break;
        case 3:
            //*descTipo = "Viento-metal";
            strcpy(descTipo, "Viento-metal");
            isOk = 1;
            break;
        case 4:
            //*descTipo = "Percusion";
            strcpy(descTipo, "Percusion");
            isOk = 1;
            break;
        }
    }
    return isOk;
}

void mostrarInstrumento(eInstrumento instrumento)
{
    printf("   %2d       %15s             %15s\n", instrumento.id, instrumento.nombre, instrumento.descTipo);
}

void mostrarInstrumentos(eInstrumento instrumentos[], int tamInstrumento)
{
    int i;
    printf("---------- LISTA DE INSTRUMENTOS | ORQUESTAS ---------\n\n");
    printf(" - ID -  ||     - NOMBRE -     ||     - TIPO - INSTRUMENTO -     ||\n\n");
    for(i = 0; i < tamInstrumento; i++)
    {
        if(instrumentos[i].isEmpty == 0)
        {
            mostrarInstrumento(instrumentos[i]);
        }
    }
}

int buscarIDInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int id)
{
    int i, isOk = 0;
    for (i = 0; i < tamInstrumentos; i++)
    {
        if (instrumentos[i].id == id)
        {
            isOk = 1;
            break;
        }
    }
    return isOk;
}

int cargarDescIntrumento(eInstrumento instrumentos[], int tamInstrumentos, int id, char descripcion[])
{
    int i, isOk = 0;
    for(i = 0; i < tamInstrumentos; i++)
    {
        if(id == instrumentos[i].id)
        {
            strcpy(descripcion, instrumentos[i].nombre);
            isOk = 1;
            break;
        }
    }
    return isOk;
}

int hardcodearInstrumentos(eInstrumento instrumentos[], int tamInstrumentos, int cantidad)
{
    int i, contador = 0;
    eInstrumento listaAuxiliar[] = {
    {0, "Guitarra", 1, "Cuerdas", 0},
    {1, "Flauta Andina", 2, "Viento-madera", 0},
    {2, "Trompeta", 3, "Viento-metal", 0},
    {3, "Xilofono", 4, "Percusion", 0},
    {4, "Harmonica", 3, "Viento-metal", 0},
    {5, "Pandereta", 4, "Percusion", 0}
    };
    if(cantidad <= 7 && cantidad < tamInstrumentos)
    {
        for(i = 0; i < cantidad; i++)
        {
            instrumentos[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}
