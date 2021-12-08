#include "LinkedList.h"
#ifndef FUNCIONESAUXILIARES_H_INCLUDED
#define FUNCIONESAUXILIARES_H_INCLUDED

typedef struct{
    int id;
    char nombre[20];
    char tipo[20];
    int tiempo;
}eBicicleta;

#endif // FUNCIONESAUXILIARES_H_INCLUDED

// ------------ FUNCIONES DE LECTURA ------------ //
int parser_FromText(FILE* pFile, LinkedList* pArrayList);
int parser_FromBinary(FILE* pFile, LinkedList* pArrayList);
int lecturaDesdeBinario(char* path, LinkedList* pLista);
int lecturaDesdeTexto(char* path, LinkedList* pLista);

// ------------ FUNCIONES DE ENTIDAD ------------ //
eBicicleta* nuevaBicicleta();
eBicicleta* bicicleta_newParametros(char* idStr,char* nombreStr,char* tipoStr, char* tiempoStr);
int bicicleta_setId(eBicicleta* pBici, int id);
int bicicleta_getId(eBicicleta* pBici,int* id);
int bicicleta_setNombre(eBicicleta* pBici,char* nombre);
int bicicleta_getNombre(eBicicleta* pBici,char* nombre);
int bicicleta_setTiempo(eBicicleta* pBici,int tiempo);
int bicicleta_getTiempo(eBicicleta* pBici,int* tiempo);
int bicicleta_setTipo(eBicicleta* pBici,char* tipo);
int bicicleta_getTipo(eBicicleta* pBici,char* tipo);
void bicicleta_showInfo(eBicicleta* pBici);
void bicicleta_showList(LinkedList* listaBicicletas);
void bici_mapTiempo(void* pElement);
int bici_filterPorBMX(void* pElement);
int bici_filterPorPlayera(void* pElement);
int bici_filterPorMTB(void* pElement);
int bici_filterPorPaseo(void* pElement);
void bicicleta_mostrarPosiciones(LinkedList* lista);

// ------------ FUNCIONES DE ORDENAMIENTO ------------ //
int ordenarPorTipo(void* pElement1, void* pElement2);
int ordenarPorTiempo(void* pElement1, void* pElement2);

// ------------ FUNCIONES DE FILTRADO ------------ //
int filtrarPorTipo(LinkedList* lista);

// ------------ FUNCIONES DE ESCRITURA ------------ //
int guardarComoTexto(char* path, LinkedList* pArrayList);

