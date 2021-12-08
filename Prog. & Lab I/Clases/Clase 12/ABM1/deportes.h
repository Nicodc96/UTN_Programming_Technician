#ifndef DEPORTES_H_INCLUDED
#define DEPORTES_H_INCLUDED

typedef struct
{
    int id;
    char descripcion[20];

}eDeporte;

#endif // DEPORTES_H_INCLUDED

void mostrarDeportes(eDeporte sports[], int tamDep);
void mostrarDeporte(eDeporte sport);
void cargarDescDeporte(int idSport, eDeporte sports[], int tamSports, char desc[]);


