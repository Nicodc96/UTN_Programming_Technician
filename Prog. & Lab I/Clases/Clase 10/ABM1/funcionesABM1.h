#ifndef FUNCIONESABM1_H_INCLUDED
#define FUNCIONESABM1_H_INCLUDED

typedef struct
{
    int dia;
    int mes;
    int anio;
} eFecha;

typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float altura;
    eFecha fechaDeNacimiento;      // Estructura anidada en otra
    int isEmpty;
}ePersona;
#endif // FUNCIONESABM1_H_INCLUDED

char menu();
void inicializarPersonas(ePersona lista[], int tam);
int verificarEspacioLista(ePersona lista[], int tam);
ePersona cargarPersona(int preLegajo, char preNombre[], char preSexo, float preAltura, eFecha preFecha);
int altaPersonas(ePersona lista[], int tam, int preLegajo);
int buscarIndicePersona(ePersona lista[], int tamLista, int preLegajo);
void mostrarPersona(ePersona unaPersona);
int mostrarPersonas(ePersona listaPersonas[], int tamLista);
int bajaPersona(ePersona lista[], int tamLista);

int hardcodearPersonas(ePersona lista[], int tamLista, int cantidad);

void mostrarPorSexo(ePersona lista[], int tamLista, char preSexo);
