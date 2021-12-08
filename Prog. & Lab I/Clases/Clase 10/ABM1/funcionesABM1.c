#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "funcionesABM1.h"

char menu()
{
    char opcion;
    system("cls");

    printf("*** ABM Personas ***\n\n");
    printf("a) Alta\n");
    printf("b) Baja\n");
    printf("c) Modificion\n");
    printf("d) Listar\n");
    printf("e) Ordenar\n");
    printf("f) Informes\n");
    printf("g) Mostrar Lista por Sexo\n");
    printf("z) Salir\n\n");
    printf("Ingrese opcion: ");
    fflush(stdin);
    opcion = tolower(getchar());

    return opcion;
}

void inicializarPersonas(ePersona lista[], int tam)
{
    int i;
    for (i = 0; i < tam; i++)
    {
        lista[i].isEmpty = 1;
    }
}

int verificarEspacioLista(ePersona lista[], int tam)
{
    int indice = -1;
    int i;
    for (i = 0; i < tam; i++)
    {
        if (lista[i].isEmpty == 1)
        {
            indice = i;
        }
    }
    return indice;
}

ePersona cargarPersona(int preLegajo, char preNombre[], char preSexo, float preAltura, eFecha preFecha)
{
    ePersona personaTemp;
    personaTemp.legajo = preLegajo;
    strcpy(personaTemp.nombre, preNombre);
    personaTemp.sexo = preSexo;
    personaTemp.altura = preAltura;
    personaTemp.fechaDeNacimiento = preFecha;
    personaTemp.isEmpty = 0;

    return personaTemp;
}

int altaPersonas(ePersona lista[], int tam, int preLegajo)
{
    system("cls");
    int isOk = 0;
    int indice;
    char auxNombre[20];
    char auxSexo;
    float auxAltura;
    eFecha auxFecha;

    indice = verificarEspacioLista(lista, tam);
    if (indice != -1)
    {
        printf("Ingrese nombre de la persona: ");
        fflush(stdin);
        scanf("%s", auxNombre);

        printf("Ingrese sexo de la persona: ");
        fflush(stdin);
        scanf("%c", &auxSexo);

        printf("Ingrese altura de la persona: ");
        fflush(stdin);
        scanf("%f", &auxAltura);

        printf("Ingrese fecha de nacimiento dd/mm/aaaa: ");
        fflush(stdin);
        scanf("%d/%d/%d", &auxFecha.dia, &auxFecha.mes, &auxFecha.anio);

        lista[indice] = cargarPersona(preLegajo, auxNombre, auxSexo, auxAltura, auxFecha);
        isOk = 1;
    }
    return isOk;
}

int buscarIndicePersona(ePersona lista[], int tamLista, int preLegajo)
{
    int indice = 0;
    int i;
    for (i = 0; i < tamLista; i++)
    {
        if (lista[i].legajo == preLegajo)
        {
            indice = i;
        }
    }
    return indice;
}

void mostrarPersona(ePersona unaPersona)
{
    printf("  %d   %20s  %c       %.2f         %02d/%02d/%d\n", unaPersona.legajo,
           unaPersona.nombre,
           unaPersona.sexo,
           unaPersona.altura,
           unaPersona.fechaDeNacimiento.dia,
           unaPersona.fechaDeNacimiento.mes,
           unaPersona.fechaDeNacimiento.anio);
}

int mostrarPersonas(ePersona listaPersonas[], int tamLista)
{
    int isOk = 0;
    int i;
    printf(" LEGAJO               NOMBRE SEXO    ALTURA    FECHA DE NACIMIENTO\n");
    for (i = 0; i < tamLista; i++)
    {
        if (listaPersonas[i].isEmpty == 0)
        {
            mostrarPersona(listaPersonas[i]);
            isOk = 1;
        }
    }
    return isOk;
}

int bajaPersona(ePersona lista[], int tamLista)
{
    system("cls");
    int isOk = 0;
    int auxLegajo;
    int checkIndice;
    char resp;

    printf("Ingrese el legajo de la persona: ");
    scanf("%d", &auxLegajo);
    checkIndice = buscarIndicePersona(lista, tamLista, auxLegajo);

    if (checkIndice == 0)
    {
        printf("No existe una persona con ese legajo!\n");
    } else
        {
            mostrarPersona(lista[checkIndice]);
            printf("\n Confirmar baja (y/n): ");
            fflush(stdin);
            scanf("%c", &resp);
            while (resp != 'y' && resp != 'n')
            {
                printf("Error! Ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &resp);
            }
            if (resp == 'y')
            {
                lista[checkIndice].isEmpty = 1;
                isOk = 1;
            } else
                {
                    printf("Se ha cancelado la operacion.\n");
                }
        }
    return isOk;
}

int hardcodearPersonas(ePersona lista[], int tamLista, int cantidad)
{
    int contador = 0;
    int i;
    ePersona listaHarcodeada[] = {
        {100, "Juan", 'm', 1.75, {10,3,1996}, 0},
        {101, "Maria", 'f', 1.66, {15,1,1999}, 0},
        {102, "Eugenia", 'f', 1.71, {22,6,2000}, 0},
        {103, "Federico", 'm', 1.83, {19,2,1993}, 0},
        {104, "Maximiliano", 'm', 1.88, {19,10,1997}, 0}
    };
    if (cantidad <= tamLista && cantidad < 10)
    {
        for (i = 0; i < cantidad; i++)
        {
            lista[i] = listaHarcodeada[i];
            contador++;
        }
    }
    return contador;
}

int subMenuOrdenamiento(ePersona lista[], int tamLista)
{
    system("cls");
    int isOk = 0;
    char opcion;

    printf("*** Ordenamiento de Lista ***\n");
    printf("a) Ordenar A-Z\n");
    printf("b) Ordenar Z-A\n");
    printf("c) Ordenar por Sexo y Edad\n");
    printf("d) Salir\n\n");
    printf("Elija opcion: ");
    scanf("%c", &opcion);

    switch(opcion)
    {
    case 'a':
        break;
    case 'b':
        break;
    case 'c':
        break;
    case 'd':
        break;
    default:
        printf("Opcion invalida!\n");
        system("pause");
    }
    return isOk;
}

void mostrarPorSexo(ePersona lista[], int tamLista, char preSexo)
{
    system("cls");
    int i;
    printf("----- MOSTRANDO ARRAY ORDENADO POR SEXO -----\n\n");
    printf(" LEGAJO               NOMBRE SEXO    ALTURA    FECHA DE NACIMIENTO\n");
    for (i = 0; i < tamLista; i++)
    {
        if (lista[i].sexo == preSexo)
        {
            mostrarPersona(lista[i]);
        }
    }
}
