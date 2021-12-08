#ifndef FUNCIONESABM1_H_INCLUDED
#define FUNCIONESABM1_H_INCLUDED
#include "fechas.h"
#include "deportes.h"
typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float altura;
    eFecha fechaDeNacimiento;      // Estructura anidada en otra
    int idDeporte;
    int isEmpty;
}ePersona;
#endif // FUNCIONESABM1_H_INCLUDED



char menu();
void inicializarPersonas(ePersona lista[], int tam);
int verificarEspacioLista(ePersona lista[], int tam);
ePersona cargarPersona(int preLegajo, char preNombre[], char preSexo, float preAltura, eFecha preFecha, int preIdDep);
int altaPersonas(ePersona lista[], int tam, int preLegajo, eDeporte sports[], int tamDep);
int buscarIndicePersona(ePersona lista[], int tamLista, int preLegajo);
int bajaPersona(ePersona lista[], int tamLista, eDeporte sports[], int tamDep);

void mostrarPersona(ePersona unaPersona, eDeporte sports[], int tamSport);
int mostrarPersonas(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamSport);

void mostrarPersona(ePersona unaPersona, eDeporte sports[], int tamSport);

int hardcodearPersonas(ePersona lista[], int tamLista, int cantidad);

void mostrarPorSexo(ePersona lista[], int tamLista, char preSexo, eDeporte sports[], int tamDep);

int informeMenu();
void informeMenuCases(ePersona lista[], int tamLista, eDeporte sports[], int tamDep);

int mostrarPersonaXFecha(ePersona lista[], int tamLista, int anio, eDeporte sports[], int tamDep);
int mostrarPersonaXDeporte(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamDep);
int contarDeportistas(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamDep);
int mostrarDeportistasSegunDeporte(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamDep);

int ordenarPersonasPorDeporte(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamDep, int criterio);
void deporteFavorito(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamDep);
