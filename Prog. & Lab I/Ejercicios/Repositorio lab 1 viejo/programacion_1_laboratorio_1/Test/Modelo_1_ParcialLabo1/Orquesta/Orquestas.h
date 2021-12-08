#ifndef ORQUESTAS_H_INCLUDED
#define ORQUESTAS_H_INCLUDED
typedef struct
{
    int id;
    int tipo;
    char descTipo[50];
    int isEmpty;

}eOrquesta;

eOrquesta new_Orquesta(int id, int tipoOrquesta, char descTipo[]);
int agregarOrquesta(eOrquesta orquesta[], int tamOrquesta, int idOrquesta);
void inicializarOrquestas(eOrquesta orquesta[], int tamOrquesta);
int buscarLibreOrquesta(eOrquesta orquesta[], int tamOrquesta);
int buscarIndiceOrquesta(eOrquesta orquesta[], int tamOrquesta, int idParametro);
int bajaOrquesta(eOrquesta orquesta[], int tamOrquesta);
void mostrarTiposOrquesta();
int checkOrquesta(char* nombreOrquesta);
int valorOrquesta(char* nombreOrquesta);
void mostrarOrquesta(eOrquesta orquesta);
void mostrarOrquestas(eOrquesta orquesta[], int tamOrquesta);

int buscarIDOrquesta(eOrquesta orquesta[], int tamOrquesta, int id);
int cargarDescOrquesta(eOrquesta orquesta[], int tamOrquesta, int idOrquesta, char descripcion[]);

int hardcodearOrquestas(eOrquesta orquesta[], int tamOrquesta, int cantidad);

#endif // ORQUESTAS_H_INCLUDED
