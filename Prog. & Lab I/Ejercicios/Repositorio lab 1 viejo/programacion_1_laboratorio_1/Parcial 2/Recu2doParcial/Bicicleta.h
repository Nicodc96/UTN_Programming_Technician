#ifndef BICICLETA_H_INCLUDED
#define BICICLETA_H_INCLUDED
typedef struct{
    int id;
    char duenio[20];
    char tipo[10];
    int tiempo;
}eBicicleta;

eBicicleta* new_bicicleta();
eBicicleta* new_biciParametrizado(char* id, char* duenio, char* tipo, char* tiempo);

int bici_setID(eBicicleta* bici, int id);
int bici_setDuenio(eBicicleta* bici, char* duenio);
int bici_setTipo(eBicicleta* bici, char* tipo);
int bici_setTiempo(eBicicleta* bici, int tiempo);

int bici_getId(eBicicleta* bici, int* id);
int bici_getDuenio(eBicicleta* bici, char* duenio);
int bici_getTipo(eBicicleta* bici, char* tipo);
int bici_getTiempo(eBicicleta* bici, int* tiempo);

void bici_showInfo(eBicicleta* bici);

int bici_filterPorBMX(void* pElement);
int bici_filterPorPlayera(void* pElement);
int bici_filterPorMTB(void* pElement);
int bici_filterPorPaseo(void* pElement);

void bici_mapTiempo(void* pElement);

#endif // BICICLETA_H_INCLUDED
