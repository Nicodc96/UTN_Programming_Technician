#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Bicicleta.h"

eBicicleta* new_bicicleta()
{
    eBicicleta* nuevo = (eBicicleta*) malloc(sizeof(eBicicleta));
    if(nuevo != NULL)
    {
        nuevo->id = 0;
        strcpy(nuevo->duenio, "");
        strcpy(nuevo->tipo, "");
        nuevo->tiempo = 0;
    }
    return nuevo;
}

eBicicleta* new_biciParametrizado(char* id, char* duenio, char* tipo, char* tiempo)
{
    eBicicleta* nuevaBici = new_bicicleta();
    if(nuevaBici != NULL)
    {
        bici_setID(nuevaBici, atoi(id));
        bici_setDuenio(nuevaBici, duenio);
        bici_setTipo(nuevaBici, tipo);
        bici_setTiempo(nuevaBici, atoi(tiempo));
    }
    return nuevaBici;
}

int bici_setID(eBicicleta* bici, int id)
{
    int isOk = 0;
    if(bici != NULL)
    {
        bici->id = id;
        isOk = 1;
    }

    return isOk;
}

int bici_setDuenio(eBicicleta* bici, char* duenio)
{
    int isOk = 0;
    if(bici != NULL)
    {
        strcpy(bici->duenio, duenio);
        isOk = 1;
    }

    return isOk;
}

int bici_setTipo(eBicicleta* bici, char* tipo)
{
    int isOk = 0;
    if(bici != NULL)
    {
        strcpy(bici->tipo, tipo);
        isOk = 1;
    }

    return isOk;
}

int bici_setTiempo(eBicicleta* bici, int tiempo)
{
    int isOk = 0;
    if(bici != NULL)
    {
        bici->tiempo = tiempo;
        isOk = 1;
    }
    return isOk;
}

int bici_getId(eBicicleta* bici, int* id)
{
    int isOk = 0;
    if(bici != NULL)
    {
        *id = bici->id;
        isOk = 1;
    }

    return isOk;
}

int bici_getDuenio(eBicicleta* bici, char* duenio)
{
    int isOk = 0;
    if(bici != NULL)
    {
        strcpy(duenio, bici->duenio);
        isOk = 1;
    }
    return isOk;
}

int bici_getTipo(eBicicleta* bici, char* tipo)
{
    int isOk = 0;
    if(bici != NULL)
    {
        strcpy(tipo, bici->tipo);
        isOk = 1;
    }
    return isOk;
}

int bici_getTiempo(eBicicleta* bici, int* tiempo)
{
    int isOk = 0;
    if(bici != NULL)
    {
        *tiempo = bici->tiempo;
        isOk = 1;
    }

    return isOk;
}

void bici_showInfo(eBicicleta* bici)
{
    int id;
    char duenio[20];
    char tipo[20];
    int tiempo;

    bici_getId(bici, &id);
    bici_getDuenio(bici, duenio);
    bici_getTipo(bici, tipo);
    bici_getTiempo(bici, &tiempo);

    printf(" %3d %10s  %10s      %d \n", id, duenio, tipo, tiempo);
}

int bici_filterPorBMX(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bici_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "BMX") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

int bici_filterPorPlayera(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bici_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "PLAYERA") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

int bici_filterPorMTB(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bici_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "MTB") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

int bici_filterPorPaseo(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bici_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "PASEO") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

void bici_mapTiempo(void* pElement)
{
    int auxTiempo;
    eBicicleta* auxBici;

    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        auxTiempo = rand()%(71)+50;
        bici_setTiempo(auxBici, auxTiempo);
    }
}
