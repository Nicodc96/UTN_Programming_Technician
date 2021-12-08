#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "Musicos.h"
#include "Instrumentos.h"
#include "Orquestas.h"

eMusico new_Musico(int idMusico, char nombre[], int idInstrumento, int idOrquesta)
{
    eMusico nuevo;

    nuevo.id = idMusico;
    strcpy(nuevo.nombre, nombre);
    nuevo.idInstrumento = idInstrumento;
    nuevo.idOrquesta = idOrquesta;
    nuevo.isEmpty = 0;

    return nuevo;
}

int agregarMusico(eMusico musico[], int idMusico, int tamMusicos, eInstrumento instrumento[],int tamInstrumento, eOrquesta orquesta[], int tamOrquesta)
{
    int isOk = 0, intentos = 3, i;
    int indiceMusico;
    char auxNombre[50];
    int auxIdInstrumento;
    int auxIdOrquesta;

    system("cls");
    printf("--------- AGREGAR MUSICO | ORQUESTAS ---------\n\n");

    indiceMusico = buscarLibreMusico(musico, tamMusicos);

    if(indiceMusico == -1)
    {
        printf("No es posible agregar un musico, lista de musicos llena!\n");
    } else
        {
            printf("Ingrese el nombre del musico: ");
            fflush(stdin);
            gets(auxNombre);
            while(strlen(auxNombre) > 49 && strlen(auxNombre) < 3 && intentos != 0)
            {
                intentos--;
                printf("Error! Nombre ingresado incorrecto o demasiado largo!\n");
                printf("Intentos restantes: %d\n", intentos);
                printf("Reingrese nombre: ");
                fflush(stdin);
                gets(auxNombre);
            }
            if(!intentos)
            {
                printf("Demasiados intentos incorrectos! No se pudo agregar el Musico!\n");
                return isOk;
            }
            printf("\n - ID -  ||     - NOMBRE -     ||     - TIPO - INSTRUMENTO -     ||\n\n");
            for(i = 0; i < tamInstrumento; i++)
            {
                if(instrumento[i].isEmpty == 0)
                {
                    mostrarInstrumento(instrumento[i]);
                }
            }
            printf("Ingrese el ID del Instrumento que toca: ");
            scanf("%d", &auxIdInstrumento);
            while(!(buscarIDInstrumento(instrumento, tamInstrumento, auxIdInstrumento)) && intentos != 0)
            {
                intentos--;
                printf("Error! ID del instrumento no encontrado!\n");
                printf("Intentos restantes: %d\n", intentos);
                printf("Reingrese el ID del instrumento: ");
                scanf("%d", &auxIdInstrumento);
            }
            if(!intentos)
            {
                printf("Demasiados intentos incorrectos! No se pudo agregar el Musico!\n");
                return isOk;
            }
            printf(" - ID - || - TIPO DE ORQUESTA - || - DESCRIPCION -\n");
            for (i = 0; i < tamOrquesta; i++)
            {
                if(orquesta[i].isEmpty == 0)
                {
                    mostrarOrquesta(orquesta[i]);
                }
            }
            printf("Ingrese el ID de la Orquesta donde toca: ");
            scanf("%d", &auxIdOrquesta);
            while(!(buscarIDOrquesta(orquesta, tamOrquesta, auxIdOrquesta)) && intentos != 0)
            {
                intentos--;
                printf("Error! ID de la Orquesta no encontrado!");
                printf("Intentos restantes: %d\n", intentos);
                printf("Reingrese el ID de la Orquesta: ");
                scanf("%d", &auxIdOrquesta);
            }
            if(!intentos)
            {
                printf("Demasiados intentos incorrectos! No se pudo agregar el Musico!\n");
                return isOk;
            }
            strlwr(auxNombre);
            auxNombre[0] = toupper(auxNombre[0]);
            musico[indiceMusico] = new_Musico(idMusico, auxNombre, auxIdInstrumento, auxIdOrquesta);
            printf("Se ha agregado el Musico de manera exitosa!\n");
            isOk = 1;
        }
    return isOk;
}

void inicializarMusicos(eMusico musicos[], int tamMusicos)
{
    int i;
    for(i = 0; i < tamMusicos; i++)
    {
        musicos[i].isEmpty = 1;
    }
}

int buscarIndiceMusico(eMusico musicos[], int tamMusicos, int idParametro)
{
    int i, indice = -1;
    for(i = 0; i < tamMusicos; i++)
    {
        if(idParametro == musicos[i].id)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

int buscarLibreMusico(eMusico musicos[], int tamMusicos)
{
    int i, indice = -1;
    for (i = 0; i < tamMusicos; i++)
    {
        if(musicos[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

void mostrarMusico(eMusico musico, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas)
{
    char descIntrumentos[50];
    char descOrquestas[50];
    cargarDescIntrumento(instrumentos, tamInstrumentos, musico.idInstrumento, descIntrumentos);
    cargarDescOrquesta(orquestas, tamOrquestas, musico.idOrquesta, descOrquestas);
    printf("  %4d   %15s       %15s       %15s\n", musico.id, musico.nombre, descIntrumentos, descOrquestas);
}

void mostrarMusicos(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas)
{
    int i;
    printf("--------- LISTA DE MUSICOS ACTIVOS | ORQUESTAS ---------\n\n");
    printf("  - ID -  ||    - NOMBRE -    ||  - INSTRUMENTO -  || - ORQUESTA ACTUAL - \n\n");
    for (i = 0; i < tamMusicos; i++)
    {
        if(musicos[i].isEmpty == 0)
        {
            mostrarMusico(musicos[i], instrumentos, tamInstrumentos, orquestas, tamOrquestas);
        }
    }
}

int bajaMusico(eMusico musicos[], int tamMusicos, eOrquesta orquestas[], int tamOrquestas, eInstrumento instrumentos[], int tamInstrumentos)
{
    int isOk = 0, auxId, checkIndice, intentos = 3;
    char respuesta;
    system("cls");
    printf("--------- BAJA MUSICO | ORQUESTAS ---------\n\n");
    mostrarMusicos(musicos, tamMusicos, instrumentos, tamInstrumentos, orquestas, tamOrquestas);
    printf("Ingrese el ID del musico a dar de BAJA: ");
    scanf("%d", &auxId);
    checkIndice = buscarIndiceMusico(musicos, tamMusicos, auxId);
    if(checkIndice == -1)
    {
        printf("No se ha encontrado el musico con el ID ingresado!\n");
    } else
        {
            printf("Confimar baja (y/n): ");
            fflush(stdin);
            scanf("%c", &respuesta);
            while (respuesta != 'y' && respuesta != 'n' && intentos != 0)
            {
                intentos--;
                printf("Intentos restantes: %d\n", intentos);
                printf("Respuesta incorrecta! Ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &respuesta);
            }
            if(!intentos)
            {
                printf("Demasiados intentos fallidos, cancelando operacion!\n");
            } else
                {
                    if(respuesta == 'y')
                    {
                        musicos[checkIndice].isEmpty = 1;
                        isOk = 1;
                    } else
                        {
                            printf("Se ha cancelado exitosamente la operacion!\n");
                        }
                }
        }

    return isOk;
}

int modificarMusico(eMusico musicos[], int tamMusicos, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquestas)
{
    int isOk = 0, auxId, checkIndice, intentos = 3, auxInstrumento, auxOrquesta, checkInstrumento, checkOrquesta;
    char auxNombre[50];
    char seguir = 'n';
    system("cls");
    printf("--------- MODIFICACIONES MUSICOS | ORQUESTAS ---------\n\n");
    mostrarMusicos(musicos, tamMusicos, instrumentos, tamInstrumentos, orquestas, tamOrquestas);
    printf("Ingrese el ID del musico a Modificar: ");
    scanf("%d", &auxId);
    checkIndice = buscarIndiceMusico(musicos, tamMusicos, auxId);
    if(checkIndice == -1)
    {
        printf("No se ha encontrado el Musico con el ID ingresado!\n");
    } else
        {
            do{
            switch(menuDeModificacionesMusico(musicos[checkIndice], instrumentos, tamInstrumentos, orquestas, tamOrquestas))
            {
                case 1:
                    printf("Ingrese el nuevo nombre: ");
                    fflush(stdin);
                    gets(auxNombre);
                    while(strlen(auxNombre) > 20 && intentos != 0)
                    {
                        intentos--;
                        printf("Intentos restantes: %d\n", intentos);
                        printf("Nombre demasiado largo! Reingrese nombre: ");
                        fflush(stdin);
                        gets(auxNombre);
                    }
                    strlwr(auxNombre);
                    auxNombre[0] = toupper(auxNombre[0]);
                    strcpy(musicos[checkIndice].nombre, auxNombre);
                    printf("\nSe ha modificado existosamente el nombre del musico!\n");
                    isOk = 1;
                    break;
                case 2:
                    mostrarInstrumentos(instrumentos, tamInstrumentos);
                    printf("\nIngrese el ID del nuevo instrumento: ");
                    scanf("%d", &auxInstrumento);
                    checkInstrumento = buscarIndiceInstrumento(instrumentos, tamInstrumentos, auxInstrumento);
                    if(checkInstrumento == -1)
                    {
                        printf("\nNo se ha encontrado el instrumento con el ID ingresado!\n");
                    } else
                        {
                            musicos[checkIndice].idInstrumento = auxInstrumento;
                            printf("\nSe ha modificado exitosamente el nuevo instrumento del musico!\n");
                            isOk = 1;
                        }
                    break;
                case 3:
                    mostrarOrquestas(orquestas, tamOrquestas);
                    printf("Ingrese el ID de la nueva orquesta: ");
                    scanf("%d", &auxOrquesta);
                    checkOrquesta = buscarIndiceOrquesta(orquestas, tamOrquestas, auxOrquesta);
                    if(checkOrquesta == -1)
                    {
                        printf("\nNo se ha encontrado la orquesta con el ID ingresado!\n");
                    } else
                        {
                            musicos[checkIndice].idOrquesta = auxOrquesta;
                            printf("\nSe ha modificado exitosamente la orquesta del musico!\n");
                            isOk = 1;
                        }
                    break;
                case 4:
                    printf("Confirmar salida (y/n): ");
                    fflush(stdin);
                    scanf("%c", &seguir);
                    while(seguir != 'y' && seguir != 'n' && intentos != 0)
                    {
                        intentos--;
                        printf("Intentos restantes: %d\n", intentos);
                        printf("Error! Respuesta incorrecta, ingrese 'y' o 'n': ");
                        fflush(stdin);
                        scanf("%c", &seguir);
                    }
                    if(!intentos)
                    {
                        printf("\nDemasiados intentos fallidos, saliendo del menu...\n");
                        seguir = 'y';
                    }
                    break;
            }
            system("pause");
            }while(seguir == 'n');
        }

    return isOk;
}

int menuDeModificacionesMusico(eMusico musico, eInstrumento instrumentos[], int tamInstrumentos, eOrquesta orquestas[], int tamOrquesta)
{
    int opcion;
    char auxInstrumento[50];
    char auxOrquesta[50];
    cargarDescIntrumento(instrumentos, tamInstrumentos, musico.idInstrumento, auxInstrumento);
    cargarDescOrquesta(orquestas, tamOrquesta, musico.idOrquesta, auxOrquesta);
    system("cls");
    printf("--------- MODIFICACIONES MUSICOS | ORQUESTAS ---------\n\n");
    printf("ID del Musico: %d\n", musico.id);
    printf("Nombre del Musico: %s\n", musico.nombre);
    printf("Instrumento que toca: %s\n", auxInstrumento);
    printf("Orquesta donde participa: %s\n", auxOrquesta);
    printf("\n1) Modificar nombre\n");
    printf("2) Modificar instrumento que toca\n");
    printf("3) Modificar orquesta donde participa\n");
    printf("4) Salir\n\n");
    printf("Ingrese opcion: ");
    scanf("%d", &opcion);
    return opcion;
}
int hardcodearMusicos(eMusico musicos[], int tamMusicos, int cantidad)
{
    int i, contador = 0;
    eMusico listaAuxiliar[] = {
    {1000, "Juan", 3, 56},
    {1001, "Enrique", 4, 50},
    {1002, "Julieta", 0, 54},
    {1003, "Lucia", 3, 51},
    {1004, "Eugenia", 5, 53},
    {1005, "Lucas", 1, 55},
    {1006, "Felipe", 3, 53},
    {1007, "Claudio", 1, 52},
    {1008, "Julia", 0, 51},
    {1009, "Florencia", 5, 50},
    {1010, "Lourdes", 1, 50},
    {1011, "Ivan", 4, 51},
    {1012, "Carlos", 0, 50},
    {1013, "Ignacio", 3, 51},
    {1014, "Armando", 5, 50},
    {1015, "Maria", 0, 52},
    {1016, "Celeste", 5, 52}
    };
    if (cantidad <= 17 && cantidad < tamMusicos)
    {
        for (i = 0; i < cantidad; i++)
        {
            musicos[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}
