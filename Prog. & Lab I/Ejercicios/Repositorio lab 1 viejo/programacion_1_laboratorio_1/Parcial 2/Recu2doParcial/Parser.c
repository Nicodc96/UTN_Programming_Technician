#include <stdio.h>
#include <stdlib.h>
#include "Parser.h"
#include "Linkedlist.h"
#include "Bicicleta.h"

int parser_text(char* pFile, LinkedList* lista)
{
    int isOk = 0;
    int cant;
    char id[50];
    char duenio[50];
    char tipo[50];
    char tiempo[50];
    eBicicleta* auxBici;
    FILE* fArchivo = fopen(pFile, "r");

    if (pFile != NULL && lista != NULL && fArchivo != NULL)
    {
        fscanf(fArchivo, "%[^,],%[^,],%[^,],%[^\n]\n", id, duenio, tipo, tiempo);
        while (!feof(fArchivo))
        {
            cant = fscanf(fArchivo, "%[^,],%[^,],%[^,],%[^\n]\n", id, duenio, tipo, tiempo);
            if (cant == 4)
            {
                auxBici = new_biciParametrizado(id, duenio, tipo, tiempo);
                ll_add(lista, auxBici);
            }
        }
    isOk = 1;
    }
    fclose(fArchivo);
    return isOk;
}
