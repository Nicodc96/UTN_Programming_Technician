#include <stdio.h>
#include <stdlib.h>
#include "Cachorro.h"
#include "Parser.h"
#include "Linkedlist.h"
#include "Controller.h"

int controller_loadArchive(char* path, LinkedList* lista)
{
    int isOk = 0;
    int checkParser = 0;

    checkParser = parser_text(path, lista);

    if (checkParser)
    {
        printf("\n------ Se ha cargado correctamente los datos del Archivo! ------\n");
        printf("------ Datos cargados: %d\n",ll_len(lista));
        isOk = 1;
    } else
        {
            printf("------ Error! No se ha podido cargar los datos del Archivo! ------\n");
        }
    return isOk;
}

int controller_listArchive(LinkedList* lista)
{
    int isOk = 0;
    int i;
    eCachorro* auxCachorro;
    system("cls");
    printf("------------------ LISTA DE CACHORROS ------------------\n\n");
    printf("  -ID-  -NOMBRE- -DIAS-  -RAZA-  -RESERVADO-  -GENERO- \n");

    for(i = 0; i < ll_len(lista); i++)
    {
        auxCachorro = ll_get(lista, i);
        cachorro_getInfo(auxCachorro);
        isOk = 1;
    }
    printf("------ Dato(s) cargado(s): %d\n",ll_len(lista));
    return isOk;
}

int controller_filter45Days(LinkedList* lista)
{
    LinkedList* nuevaLista = NULL;
    int isOk = 0;
    int i;
    int id;
    char nombre[50];
    int dias;
    char raza[50];
    char reservado[10];
    char genero[10];
    FILE* fArchivo;
    eCachorro* auxCachorro = NULL;

    if(lista != NULL)
    {
        nuevaLista = ll_newLinkedList();
        if (nuevaLista != NULL)
        {
            nuevaLista = ll_filter(lista, cachorro_filtrarPorDias);
            isOk = 1;
        }
    fArchivo = fopen("cachorrosMayores45Dias.csv", "w");
    fprintf(fArchivo, "ID_Cachorro,Nombre,Dias,Raza,Reservado,Genero\n");
    for (i = 0; i < ll_len(nuevaLista); i++)
    {
        auxCachorro = (eCachorro*) ll_get(nuevaLista, i);
        cachorro_getID(auxCachorro, &id);
        cachorro_getNombre(auxCachorro, nombre);
        cachorro_getDias(auxCachorro, &dias);
        cachorro_getRaza(auxCachorro, raza);
        cachorro_getReservado(auxCachorro, reservado);
        cachorro_getGenero(auxCachorro, genero);
        fprintf(fArchivo, "%d,%s,%d,%s,%s,%s\n", id, nombre, dias, raza, reservado, genero);
    }
    fclose(fArchivo);
    }
    return isOk;
}

int controller_filterMachos(LinkedList* lista)
{
    LinkedList* nuevaLista = NULL;
    int isOk = 0;
    int i;
    int id;
    char nombre[50];
    int dias;
    char raza[50];
    char reservado[10];
    char genero[10];
    FILE* fArchivo;
    eCachorro* auxCachorro = NULL;

    if(lista != NULL)
    {
        nuevaLista = ll_newLinkedList();
        if (nuevaLista != NULL)
        {
            nuevaLista = ll_filter(lista, cachorro_filtrarMachos);
            isOk = 1;
        }
    fArchivo = fopen("cachorrosHembras.csv", "w");
    fprintf(fArchivo, "ID_Cachorro,Nombre,Dias,Raza,Reservado,Genero\n");
    for (i = 0; i < ll_len(nuevaLista); i++)
    {
        auxCachorro = (eCachorro*) ll_get(nuevaLista, i);
        cachorro_getID(auxCachorro, &id);
        cachorro_getNombre(auxCachorro, nombre);
        cachorro_getDias(auxCachorro, &dias);
        cachorro_getRaza(auxCachorro, raza);
        cachorro_getReservado(auxCachorro, reservado);
        cachorro_getGenero(auxCachorro, genero);
        fprintf(fArchivo, "%d,%s,%d,%s,%s,%s\n", id, nombre, dias, raza, reservado, genero);
    }
    fclose(fArchivo);
    }
    return isOk;
}

int controller_listCallejeros(LinkedList* lista)
{
    int isOk = 0;
    int i;
    eCachorro* auxCachorro = NULL;
    LinkedList* listaCallejeros = NULL;
    if (lista != NULL)
    {
        listaCallejeros = ll_newLinkedList();
        if(listaCallejeros != NULL)
        {
            listaCallejeros = ll_filter(lista, cachorro_filtrarCallejeros);
        }
        system("cls");
        printf("------------------ LISTA DE CACHORROS ------------------\n\n");
        printf("  -ID-  -NOMBRE- -DIAS-  -RAZA-  -RESERVADO-  -GENERO- \n");
        for(i = 0; i < ll_len(listaCallejeros); i++)
        {
            auxCachorro = (eCachorro*) ll_get(listaCallejeros, i);
            cachorro_getInfo(auxCachorro);
            isOk = 1;
        }
        printf("------ Cachorros Callejeros = %d\n", ll_len(listaCallejeros));
    }
    return isOk;
}
