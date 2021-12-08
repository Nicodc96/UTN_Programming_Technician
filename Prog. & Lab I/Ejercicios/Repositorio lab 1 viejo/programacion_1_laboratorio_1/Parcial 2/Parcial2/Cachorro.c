#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Cachorro.h"

eCachorro* new_Cachorro()
{
    eCachorro* nuevo = (eCachorro*) malloc(sizeof(eCachorro));

    if(nuevo != NULL)
    {
        nuevo->id = 0;
        strcpy(nuevo->nombre, "");
        nuevo->dias = 0;
        strcpy(nuevo->raza, "");
        strcpy(nuevo->reservado, "");
        strcpy(nuevo->genero, "");
    }
    return nuevo;
}

eCachorro* new_CachorroParametrizado(char* id, char* nombre, char* dias, char* raza, char* reservado, char* genero)
{
    eCachorro* nuevo = new_Cachorro();
    int flag = 0;
    if(nuevo != NULL)
    {
        cachorro_setID(nuevo, atoi(id));
        cachorro_setNombre(nuevo, nombre);
        cachorro_setDias(nuevo, atoi(dias));
        cachorro_setRaza(nuevo, raza);
        cachorro_setReservado(nuevo, reservado);
        cachorro_setGenero(nuevo, genero);
        flag = 1;
    }
    if (flag != 1)
    {
        nuevo = NULL;
    }
    return nuevo;
}

int cachorro_setID(eCachorro* pCa, int id)
{
    int isOk = 0;
    if (pCa != NULL)
    {
        pCa->id = id;
        isOk = 1;
    }
    return isOk;
}

int cachorro_setNombre(eCachorro* pCa, char* nombre)
{
    int isOk = 0;
    if(pCa != NULL)
    {
        strcpy(pCa->nombre, nombre);
        isOk = 1;
    }
    return isOk;
}

int cachorro_setDias(eCachorro* pCa, int dias)
{
    int isOk = 0;
    if (pCa != NULL)
    {
        pCa->dias = dias;
        isOk = 1;
    }
    return isOk;
}

int cachorro_setRaza(eCachorro* pCa, char* raza)
{
    int isOk = 0;
    if(pCa != NULL)
    {
        strcpy(pCa->raza, raza);
        isOk = 1;
    }
    return isOk;
}

int cachorro_setReservado(eCachorro* pCa, char* reservado)
{
    int isOk = 0;
    if(pCa != NULL)
    {
        strcpy(pCa->reservado, reservado);
        isOk = 1;
    }
    return isOk;
}

int cachorro_setGenero(eCachorro* pCa, char* genero)
{
    int isOk = 0;
    if(pCa != NULL)
    {
        strcpy(pCa->genero, genero);
        isOk = 1;
    }
    return isOk;
}

int cachorro_getID(eCachorro* pCa, int* id)
{
    int isOk = 0;
    if(pCa != NULL && id != NULL)
    {
        *id = pCa->id;
        isOk = 1;
    }
    return isOk;
}

int cachorro_getNombre(eCachorro* pCa, char* nombre)
{
    int isOk = 0;
    if (pCa != NULL && nombre != NULL)
    {
        strcpy(nombre, pCa->nombre);
        isOk = 1;
    }
    return isOk;
}

int cachorro_getDias(eCachorro* pCa, int* dias)
{
    int isOk = 0;
    if(pCa != NULL && dias != NULL)
    {
        *dias = pCa->dias;
        isOk = 1;
    }
    return isOk;
}

int cachorro_getRaza(eCachorro* pCa, char* raza)
{
    int isOk = 0;
    if (pCa != NULL && raza != NULL)
    {
        strcpy(raza, pCa->raza);
        isOk = 1;
    }
    return isOk;
}

int cachorro_getReservado(eCachorro* pCa, char* reservado)
{
    int isOk = 0;
    if (pCa != NULL && reservado != NULL)
    {
        strcpy(reservado, pCa->reservado);
        isOk = 1;
    }
    return isOk;
}

int cachorro_getGenero(eCachorro* pCa, char* genero)
{
    int isOk = 0;
    if (pCa != NULL && genero != NULL)
    {
        strcpy(genero, pCa->genero);
        isOk = 1;
    }
    return isOk;
}

void cachorro_getInfo(eCachorro* pCa)
{
    int id;
    char nombre[50];
    int dias;
    char raza[50];
    char reservado[50];
    char genero[50];

    cachorro_getID(pCa, &id);
    cachorro_getNombre(pCa, nombre);
    cachorro_getDias(pCa, &dias);
    cachorro_getRaza(pCa, raza);
    cachorro_getReservado(pCa, reservado);
    cachorro_getGenero(pCa, genero);

    printf("  %3d %10s   %2d %10s      %2s         %s\n", id, nombre, dias, raza, reservado, genero);
}

int cachorro_filtrarPorDias(void* pElement)
{
    int isOk = 0;
    int auxDias;
    eCachorro* auxCachorro = NULL;
    if(pElement != NULL)
    {
        auxCachorro = (eCachorro*) pElement;
        cachorro_getDias(auxCachorro, &auxDias);
        if(auxDias > 45)
        {
            isOk = 1;
        }
    }
    return isOk;
}

int cachorro_filtrarMachos(void* pElement)
{
    int isOk = 0;
    char genero[10];
    eCachorro* auxCachorro = NULL;
    if(pElement != NULL)
    {
        auxCachorro = (eCachorro*) pElement;
        cachorro_getGenero(auxCachorro, genero);
        if(strcmp(genero, "H") == 0)
           {
               isOk = 1;
           }
    }
    return isOk;
}

int cachorro_filtrarCallejeros(void* pElement)
{
    int isOk = 0;
    char raza[50];
    eCachorro* auxCachorro = NULL;
    if (pElement != NULL)
    {
        auxCachorro = (eCachorro*) pElement;
        cachorro_getRaza(auxCachorro, raza);
        if(strcmp(raza, "Callejero") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}
