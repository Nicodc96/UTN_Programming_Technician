#include <stdio.h>
#include <stdlib.h>
#include "Linkedlist.h"
#include "Parser.h"
#include "Cachorro.h"

int parser_text(char* pFile, LinkedList* lista)
{
    int isOk = 0;
    int cant;
    char id[50];
    char nombre[50];
    char dias[50];
    char raza[50];
    char reservado[50];
    char genero[50];
    eCachorro* auxCachorro;
    FILE* fArchivo = fopen(pFile, "r");

    if (pFile != NULL && lista != NULL && fArchivo != NULL)
    {
        fscanf(fArchivo, "%[^,],%[^,],%[^,],%[^,],%[^,],%[^\n]\n", id, nombre, dias, raza, reservado, genero);
        while (!feof(fArchivo))
        {
            cant = fscanf(fArchivo, "%[^,],%[^,],%[^,],%[^,],%[^,],%[^\n]\n", id, nombre, dias, raza, reservado, genero);
            if (cant == 6)
            {
                auxCachorro = new_CachorroParametrizado(id, nombre, dias, raza, reservado, genero);
                ll_add(lista, auxCachorro);
            }
        }
    isOk = 1;
    }
    fclose(fArchivo);
    return isOk;
}
