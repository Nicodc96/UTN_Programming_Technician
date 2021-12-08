#ifndef PILOTOS_H_INCLUDED
#define PILOTOS_H_INCLUDED
typedef struct
{
    int codigo;
    char nombre[20];
    char apellido[20];
    char sexo;
    int isEmpty;
}ePiloto;
int hardcodearPilotos(ePiloto pilotos[], int tamPilotos, int cantidad);
void mostrarPiloto(ePiloto piloto);
void mostrarPilotos(ePiloto pilotos[], int tamPilotos);
void inicializarPilotos(ePiloto pilotos[], int tamPilotos);

#endif // PILOTOS_H_INCLUDED
