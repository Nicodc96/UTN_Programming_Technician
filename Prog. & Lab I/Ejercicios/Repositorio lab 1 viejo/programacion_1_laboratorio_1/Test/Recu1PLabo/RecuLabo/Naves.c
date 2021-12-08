#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Naves.h"

eNave new_Nave(int codigo, char modelo[], int capacidad, float peso)
{
    eNave nuevoAuxiliar;

    nuevoAuxiliar.codigo = codigo;
    strcpy(nuevoAuxiliar.modelo, modelo);
    nuevoAuxiliar.capacidad = capacidad;
    nuevoAuxiliar.peso = peso;
    nuevoAuxiliar.isEmpty = 0;

    return nuevoAuxiliar;
}

int altaNave(eNave naves[], int tamNaves, int codigoNave)
{
    int isOk = 0, buscarLibre, intentos = 3, auxCapacidad;
    char auxModelo[52];
    float auxPeso;
    system("cls");
    printf("--------- ALTAS NAVES | AGENCIA ---------\n\n");
    buscarLibre = buscarLibreNave(naves, tamNaves);

    if(buscarLibre == -1)
    {
        printf("\nNo es posible agregar mas naves! Lista llena!\n");
    } else
        {
            printf("Ingrese el modelo de la nave: ");
            fflush(stdin);
            gets(auxModelo);
            while(strlen(auxModelo) > 51 && intentos != 0)
            {
                intentos--;
                printf("Intentos restantes: %d\n", intentos);
                printf("Error! Modelo ingresado demasiado largo! Reingrese: ");
                fflush(stdin);
                gets(auxModelo);
            }
            if(intentos == 0)
            {
                printf("\nDemasiados intentos fallidos! Cancelando operacion...\n");
                return isOk;
            }
            intentos = 3;
            printf("Ingrese la capacidad de la nave (Maximo 15 pasajeros): ");
            fflush(stdin);
            scanf("%d", &auxCapacidad);
            while((auxCapacidad < 1 || auxCapacidad > 15) && intentos != 0)
            {
                intentos--;
                printf("Intentos restantes: %d\n", intentos);
                printf("Error! Capacidad ingresada incorrecta! Reingrese (Max. 15): ");
                fflush(stdin);
                scanf("%d", &auxCapacidad);
            }
            if(intentos == 0)
            {
                printf("\nDemasiados intentos fallidos! Cancelando operacion...\n");
                return isOk;
            }
            intentos = 3;
            printf("Ingrese el peso de la nave: ");
            fflush(stdin);
            scanf("%f", &auxPeso);
            while((auxPeso < 1000 || auxPeso > 2000000) && intentos != 0)
            {
                intentos--;
                printf("Intentos restantes: %d\n", intentos);
                printf("Error! Peso ingresado incorrecto! Reingrese: ");
                fflush(stdin);
                scanf("%f", &auxPeso);
            }
            if(intentos == 0)
            {
                printf("\nDemasiados intentos fallidos! Cancelando operacion...\n");
                return isOk;
            }
            naves[buscarLibre] = new_Nave(codigoNave, auxModelo, auxCapacidad, auxPeso);
            printf("\nSe ha agregado una nave de manera exitosa!\n");
            isOk = 1;
        }


    return isOk;
}

void listarNave(eNave nave)
{
    printf("  %2d  %30s      %d        %.2f\n", nave.codigo, nave.modelo, nave.capacidad, nave.peso);
}

void listarNaves(eNave naves[], int tamNaves)
{
    int i;
    printf("--------- LISTA DE NAVES ACTIVAS | AGENCIA ---------\n\n");
    printf("  - CODIGO -  ||         - MODELO -         ||  - CAPACIDAD -  ||  - PESO -  ||\n\n");
    for (i = 0; i < tamNaves; i++)
    {
        if(naves[i].isEmpty == 0)
        {
            listarNave(naves[i]);
        }
    }
}

int bajaNave(eNave naves[], int tamNave)
{
    int auxIdNave, checkNave, isOk = 0;
    char resp;
    system("cls");
    printf("--------- BAJAS NAVES | AGENCIA ---------\n\n");
    listarNaves(naves, tamNave);
    printf("Ingrese el CODIGO de la nave: ");
    scanf("%d", &auxIdNave);
    checkNave = buscarIndiceNave(naves, tamNave, auxIdNave);

    if(checkNave == -1)
    {
        printf("\nNo se ha encontrado ninguna nave con esa ID!\n");
    } else
        {
            printf("Confimar baja (y/n): ");
            fflush(stdin);
            scanf("%c", &resp);
            while(resp != 'y' && resp != 'n')
            {
                printf("Error! Respuesta incorrecta, reingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &resp);
            }
            if(resp == 'n')
            {
                printf("Se ha CANCELADO la baja de manera exitosa!\n");
            } else
            {
                naves[checkNave].isEmpty = 1;
                printf("Se ha dado de BAJA correctamente la nave!\n");
                isOk = 1;
            }
        }
    return isOk;
}

int modificarNave(eNave naves[], int tamNave)
{
    int isOk = 0, auxCodigo, checkNave, intentos = 3, auxCapacidad;
    char seguir = 'n';
    float auxPeso;
    char auxModelo[52];
    system("cls");
    printf("--------- MODIFICAR NAVES | AGENCIA ---------\n\n");
    listarNaves(naves, tamNave);
    printf("Ingrese el CODIGO de la nave: ");
    scanf("%d", &auxCodigo);
    checkNave = buscarIndiceNave(naves, tamNave, auxCodigo);
    if(checkNave == -1)
    {
        printf("\nNo se ha encontrado ninguna nave con esa ID!\n");
    } else
        {
            do{
            switch(menuDeModificacionesNaves(naves[checkNave]))
            {
            case 1:
                printf("Ingrese el nuevo modelo de la nave: ");
                fflush(stdin);
                gets(auxModelo);
                while(strlen(auxModelo) > 51 && intentos != 0)
                {
                    intentos--;
                    printf("Intentos restantes: %d\n", intentos);
                    printf("Error! Modelo ingresado demasiado largo! Reingrese: ");
                    fflush(stdin);
                    gets(auxModelo);
                }
                if(intentos == 0)
                {
                    printf("Demasiados intentos incorrectos!\n");
                } else
                    {
                        strcpy(naves[checkNave].modelo, auxModelo);
                        printf("Se ha modificado exitosamente el Modelo de la nave!\n");
                        isOk = 1;
                    }
                break;
            case 2:
                printf("Ingrese la nueva capacidad de la nave: ");
                scanf("%d", &auxCapacidad);
                while((auxCapacidad < 1 || auxCapacidad > 15) && intentos != 0)
                {
                    intentos--;
                    printf("Intentos restantes: %d\n", intentos);
                    printf("Error! Capacidad ingresada incorrecta! Reingrese (Max. 15): ");
                    fflush(stdin);
                    scanf("%d", &auxCapacidad);
                }
                if(intentos == 0)
                {
                    printf("Demasiados intentos incorrectos!\n");
                } else
                    {
                        naves[checkNave].capacidad = auxCapacidad;
                        printf("Se ha modificado exitosamente la CAPACIDAD de la nave!\n");
                        isOk = 1;
                    }
                break;
            case 3:
                printf("Ingrese el nuevo Peso de la nave: ");
                scanf("%f", &auxPeso);
                while((auxPeso < 1000 || auxPeso > 2000000) && intentos != 0)
                {
                    intentos--;
                    printf("Intentos restantes: %d\n", intentos);
                    printf("Error! Peso ingresado incorrecto! Reingrese: ");
                    fflush(stdin);
                    scanf("%f", &auxPeso);
                }
                if(intentos == 0)
                {
                    printf("Demasiados intentos incorrectos!\n");
                } else
                    {
                        naves[checkNave].peso = auxPeso;
                        printf("Se ha modificado exitosamente el PESO de la nave!\n");
                        isOk = 1;
                    }
                break;
            case 4:
                printf("Confimar salida (y/n): ");
                fflush(stdin);
                scanf("%c", &seguir);
                while(seguir != 'n' && seguir != 'y')
                {
                    printf("Respuesta incorrecta. Ingrese 'y' o 'n': ");
                    fflush(stdin);
                    scanf("%c", &seguir);
                }
                break;
            default:
                printf("Opcion seleccionada incorrecta!\n");
            }
            system("pause");
            }while(seguir == 'n');
        }
    return isOk;
}

int buscarLibreNave(eNave naves[], int tamNave)
{
    int i, indice = -1;
    for(i = 0; i < tamNave; i++)
    {
        if(naves[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

int buscarIndiceNave(eNave naves[], int tamNaves, int idParametro)
{
    int i, indice = -1;
    for (i = 0; i < tamNaves; i++)
    {
        if(idParametro == naves[i].codigo)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

void inicializarNaves(eNave naves[], int tamNaves)
{
    int i;
    for (i = 0; i < tamNaves; i++)
    {
        naves[i].isEmpty = 1;
    }
}

int menuDeModificacionesNaves(eNave naves)
{
    int opcion;
    system("cls");
    printf("--------- MODIFICAR NAVES | AGENCIA ---------\n\n");
    printf("Nave Codigo: %d\n", naves.codigo);
    printf("Nave Modelo: %s\n", naves.modelo);
    printf("Nave Capacidad: %d\n", naves.capacidad);
    printf("Nave Peso: %.2f\n\n", naves.peso);

    printf("1) Modificar Modelo\n");
    printf("2) Modificar Capacidad\n");
    printf("3) Modificar Peso\n");
    printf("4) SALIR\n\n");
    printf("Ingrese opcion: ");
    scanf("%d", &opcion);

    return opcion;
}
