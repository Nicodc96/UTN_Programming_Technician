#ifndef INSTRUMENTOS_H_INCLUDED
#define INSTRUMENTOS_H_INCLUDED
typedef struct
{
    int id;
    char nombre[50];
    int tipo;
    char descTipo[50];
    int isEmpty;

}eInstrumento;

eInstrumento new_Instrumento(int idInstrumento, char nombre[], int tipo, char descTipo[]);
int agregarInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int idInstrumento);

void inicializarInstrumentos(eInstrumento instrumentos[], int tamInstrumentos);
int buscarLibreInstrumento(eInstrumento instrumentos[], int tamInstrumentos);
int buscarIndiceInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int idParametro);
void mostrarTiposInstrumentos();
int checkInstrumento(int tipo, char* descTipo);
void mostrarInstrumento(eInstrumento instrumento);
void mostrarInstrumentos(eInstrumento instrumentos[], int tamInstrumento);
int buscarIDInstrumento(eInstrumento instrumentos[], int tamInstrumentos, int id);
int cargarDescIntrumento(eInstrumento instrumentos[], int tamInstrumentos, int id, char descripcion[]);

int hardcodearInstrumentos(eInstrumento instrumentos[], int tamInstrumentos, int cantidad);
#endif // INSTRUMENTOS_H_INCLUDED
