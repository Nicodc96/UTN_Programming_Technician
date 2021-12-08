#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "LinkedList.h"
#include "vehiculos.h"

Vehiculo* vehiculo_new()
{
    Vehiculo *this = malloc(sizeof(Vehiculo));

    return this;
}

Vehiculo* vehiculo_newParametros(char* idStr, char* dominioStr, char* anioStr)
{
    int id, anio;
    id = atoi(idStr);
    anio = atoi(anioStr);

    Vehiculo *this = vehiculo_new();
    vehiculo_setId(this, id);
    vehiculo_setDominio(this, dominioStr);
    vehiculo_setAnio(this, anio);

    return this;
}

int vehiculo_setId(Vehiculo* this, int id)
{
    if(id > 0)
    {
        this->id = id;
    }

    return 0;
}

int vehiculo_getId(Vehiculo* this)
{
    return this->id;
}

int vehiculo_setDominio(Vehiculo* this, char* dominio)
{
    strcpy(this->dominio, dominio);

    return 0;
}

char* vehiculo_getDominio(Vehiculo* this)
{
    return this->dominio;
}

int vehiculo_setAnio(Vehiculo* this, int anio)
{
    if(anio > 0)
    {
        this->anio = anio;
    }

    return 0;
}

int vehiculo_getAnio(Vehiculo* this)
{
    return this->anio;
}

int vehiculo_setTipo(Vehiculo* this, char tipo)
{
    this->tipo = tipo;

    return 0;
}

char vehiculo_getTipo(Vehiculo* this)
{
    return this->tipo;
}
