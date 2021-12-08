#ifndef DOMINIO_H_INCLUDED
#define DOMINIO_H_INCLUDED

#include "LinkedList.h"

struct Auxiliar
{
    int id;
    char dominio[6];
    int anio;
    char tipo;
};

#endif // DOMINIO_H_INCLUDED

void dominio_printfMenu();
void dominio_leerNombreArch(char *nombreArchivo);
int dominio_loadFromText(char* path, LinkedList* pArrayList);
int dominio_saveAsText(char* path, LinkedList* pArrayList);
int dominio_ListVehiculo(LinkedList* pArrayListEmployee);
void dominio_mapTipo(void* pObjeto);
int dominio_filtrarMotos(void* p);
int dominio_filtrarAutos(void* p);
void dominio_menuInicio();
