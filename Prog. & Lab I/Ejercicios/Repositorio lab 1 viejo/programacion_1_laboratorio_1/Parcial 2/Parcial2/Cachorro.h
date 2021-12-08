#ifndef CACHORRO_H_INCLUDED
#define CACHORRO_H_INCLUDED
typedef struct
{
    int id;
    char nombre[20];
    int dias;
    char raza[20];
    char reservado[10];
    char genero[10];

}eCachorro;

eCachorro* new_Cachorro();
eCachorro* new_CachorroParametrizado(char* id, char* nombre, char* dias, char* raza, char* reservado, char* genero);

int cachorro_setID(eCachorro* pCa, int id);
int cachorro_setNombre(eCachorro* pCa, char* nombre);
int cachorro_setDias(eCachorro* pCa, int dias);
int cachorro_setRaza(eCachorro* pCa, char* raza);
int cachorro_setReservado(eCachorro* pCa, char* reservado);
int cachorro_setGenero(eCachorro* pCa, char* genero);

int cachorro_getID(eCachorro* pCa, int* id);
int cachorro_getNombre(eCachorro* pCa, char* nombre);
int cachorro_getDias(eCachorro* pCa, int* dias);
int cachorro_getRaza(eCachorro* pCa, char* raza);
int cachorro_getReservado(eCachorro* pCa, char* reservado);
int cachorro_getGenero(eCachorro* pCa, char* genero);

void cachorro_getInfo(eCachorro* pCa);
int cachorro_filtrarPorDias(void* pElement);
int cachorro_filtrarMachos(void* pElement);
int cachorro_filtrarCallejeros(void* pElement);

#endif // CACHORRO_H_INCLUDED
