#ifndef NAVES_H_INCLUDED
#define NAVES_H_INCLUDED
typedef struct
{
    int codigo;
    char modelo[52];
    int capacidad;
    float peso;
    int isEmpty;
}eNave;

eNave new_Nave(int codigo, char modelo[], int capacidad, float peso);
int altaNave(eNave naves[], int tamNaves, int codigoNave);
int buscarLibreNave(eNave naves[], int tamNave);
int buscarIndiceNave(eNave naves[], int tamNaves, int idParametro);
void inicializarNaves(eNave naves[], int tamNaves);
void listarNave(eNave nave);
void listarNaves(eNave naves[], int tamNaves);
int bajaNave(eNave naves[], int tamNave);

int menuDeModificacionesNaves(eNave naves);

#endif // NAVES_H_INCLUDED
