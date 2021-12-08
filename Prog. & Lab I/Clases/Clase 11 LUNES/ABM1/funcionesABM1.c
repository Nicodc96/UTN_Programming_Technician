#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include "fechas.h"
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
    printf("e) Listar Deportes\n");
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

ePersona cargarPersona(int preLegajo, char preNombre[], char preSexo, float preAltura, eFecha preFecha, int preIdDep)
{
    ePersona personaTemp;
    personaTemp.legajo = preLegajo;
    strcpy(personaTemp.nombre, preNombre);
    personaTemp.sexo = preSexo;
    personaTemp.altura = preAltura;
    personaTemp.fechaDeNacimiento = preFecha;
    personaTemp.idDeporte = preIdDep;
    personaTemp.isEmpty = 0;

    return personaTemp;
}

int altaPersonas(ePersona lista[], int tam, int preLegajo, eDeporte sports[], int tamDep)
{
    system("cls");
    int isOk = 0;
    int indice;
    int auxIdDep;
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
        while(strlen(auxNombre) > 20)
        {
            printf("Nombre demasiado largo! Reingrese: ");
            fflush(stdin);
            scanf("%s", auxNombre);
        }

        printf("Ingrese sexo de la persona (f/m): ");
        fflush(stdin);
        scanf("%c", &auxSexo);
        while (auxSexo != 'm' || auxSexo != 'f')
        {
            printf("ERROR! Reingrese sexo de la persona (f/m): ");
            fflush(stdin);
            scanf("%c", &auxSexo);
        }

        printf("Ingrese altura de la persona: ");
        fflush(stdin);
        scanf("%f", &auxAltura);
        while (auxAltura > 2.30 || auxAltura < 1.50)
        {
            printf("Altura incorrecta! Reinngrese altura de la persona: ");
            fflush(stdin);
            scanf("%f", &auxAltura);
        }

        printf("Ingrese fecha de nacimiento dd/mm/aaaa: ");
        fflush(stdin);
        scanf("%d/%d/%d", &auxFecha.dia, &auxFecha.mes, &auxFecha.anio);
        while((auxFecha.dia > 31 || auxFecha.dia < 1) || (auxFecha.mes > 12 || auxFecha.mes < 1) || (auxFecha.anio > 2002 || auxFecha.anio < 1940))
        {
            printf("ERROR! Edad incorrecta! Reingrese fecha de nacimiento dd/mm/aaaa: ");
            fflush(stdin);
            scanf("%d/%d/%d", &auxFecha.dia, &auxFecha.mes, &auxFecha.anio);
        }

        mostrarDeportes(sports, tamDep);
        printf("Ingrese ID del deporte correspondiente: ");
        fflush(stdin);
        scanf("%d", &auxIdDep);
        while(auxIdDep > 1000 || auxIdDep < 1005)
        {
            printf("ERROR! Reingrese ID del deporte correspondiente: ");
            fflush(stdin);
            scanf("%d", &auxIdDep);
        }

        lista[indice] = cargarPersona(preLegajo, auxNombre, auxSexo, auxAltura, auxFecha, auxIdDep);
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

void mostrarPersona(ePersona unaPersona, eDeporte sports[], int tamSport)
{
    char buffDescSport[20];

    cargarDescDeporte(unaPersona.idDeporte, sports, tamSport, buffDescSport);
    printf("  %d   %20s    %c       %.2f         %02d/%02d/%d               %s\n",
           unaPersona.legajo,
           unaPersona.nombre,
           unaPersona.sexo,
           unaPersona.altura,
           unaPersona.fechaDeNacimiento.dia,
           unaPersona.fechaDeNacimiento.mes,
           unaPersona.fechaDeNacimiento.anio,
           buffDescSport);
}

int mostrarPersonas(ePersona listaPersonas[], int tamLista, eDeporte sports[], int tamSport)
{
    int isOk = 0;
    int i;
    printf(" LEGAJO               NOMBRE   SEXO    ALTURA    FECHA DE NACIMIENTO         TIPO DE DEPORTE\n");
    for (i = 0; i < tamLista; i++)
    {
        if (listaPersonas[i].isEmpty == 0)
        {
            mostrarPersona(listaPersonas[i], sports, tamSport);
            isOk = 1;
        }
    }
    return isOk;
}

int bajaPersona(ePersona lista[], int tamLista, eDeporte sports[], int tamDep)
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
            mostrarPersona(lista[checkIndice], sports, tamDep);
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
        {100, "Juan", 'm', 1.75, {10,3,1996}, 1000, 0},
        {101, "Maria", 'f', 1.66, {15,1,1999}, 1002, 0},
        {102, "Eugenia", 'f', 1.71, {22,6,2000}, 1003, 0},
        {103, "Federico", 'm', 1.83, {19,2,1993}, 1000, 0},
        {104, "Maximiliano", 'm', 1.88, {19,10,1996}, 1004, 0},
        {105, "Nicolas", 'm', 1.73, {22,1,1996}, 1002, 0},
        {106, "Enrique", 'm', 1.75, {14,7,1997}, 1001, 0},
        {107, "Florencia", 'f', 1.68, {19,10,1993}, 1005, 0},
        {108, "Julieta", 'f', 1.72, {19,10,1997}, 1000, 0},
        {109, "Alberto", 'm', 1.84, {19,10,1991}, 1005, 0}
    };
    if (cantidad <= tamLista && cantidad < 11)
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

void mostrarPorSexo(ePersona lista[], int tamLista, char preSexo, eDeporte sports[], int tamDep)
{
    system("cls");
    int i;
    printf("----- MOSTRANDO ARRAY ORDENADO POR SEXO -----\n\n");
    printf(" LEGAJO               NOMBRE SEXO    ALTURA    FECHA DE NACIMIENTO         TIPO DE DEPORTE\n");
    for (i = 0; i < tamLista; i++)
    {
        if (lista[i].sexo == preSexo)
        {
            mostrarPersona(lista[i], sports, tamDep);
        }
    }
}

int informeMenu()
{
    system("cls");
    int opcion;

    printf("---------- MENU INFORMES ----------\n\n");
    printf("1) Mostrar personas por anio en especifico \n");
    printf("2) \n");
    printf("3) \n");
    printf("4) \n");
    printf("5) \n");
    printf("6) \n");
    printf("7) \n");
    printf("8) \n");
    printf("9) \n");

    printf("0) SALIR \n\n");
    printf("Elija una opcion: ");
    fflush(stdin);
    scanf("%d", &opcion);
    return opcion;
}

void informeMenuCases(ePersona lista[], int tamLista, eDeporte sports[], int tamDep)
{
    int auxFecha;
    char seguir = 'n';
    do
    {
        switch(informeMenu())
        {
            case 1:
                system("cls");
                printf("------ MOSTRAR PERSONA POR ANIO ------\n\n");
                printf("Ingrese el anio de nacimiento: ");
                fflush(stdin);
                scanf("%d", &auxFecha);
                printf("\n\n");
                printf("------ PERSONAS NACIDAS EN %d ------\n", auxFecha);
                if (!mostrarPersonaXFecha(lista, tamLista, auxFecha, sports, tamDep))
                {
                    printf("No hay personas en la lista con el anio especificado!\n");
                }
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 0:
            printf("Confirmar salida (y/n): ");
            fflush(stdin);
            scanf("%c", &seguir);
            break;
            default:
                printf("Opcion invalida! Volviendo al menu de informes!\n");
        }
        system("pause");
    }while (seguir == 'n');
}

int mostrarPersonaXFecha(ePersona lista[], int tamLista, int anio, eDeporte sports[], int tamDep)
{
    int check = 0;
    int i;
    for (i = 0; i < tamLista; i++)
    {
        if (lista != NULL && lista[i].fechaDeNacimiento.anio == anio)
        {
            mostrarPersona(lista[i], sports, tamDep);
            check = 1;
        }
    }
    return check;
}
