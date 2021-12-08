#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>
#include "LinkedList.h"
#include "funcionesAuxiliares.h"

/*
    2do Parcial de Laboratorio 1 - 2C 2020
    Alumno: Diaz, Lautaro Nicolas
    Fecha: 25/11/2020
*/

int menuDeOpciones();

int main()
{
    srand(time(NULL));
    LinkedList* listaDeBicicletas = ll_newLinkedList();
    int checkLectura = 0, checkPosicion = 0;;
    char nombreArchivo[32];
    char extensionArchivo[32] = ".csv";
    char nombreArchivoPosiciones[32] = "bicicletasPosiciones";
    char seguir = 'n';

    if (listaDeBicicletas == NULL)
    {
        printf("Se ha producido un error!\n");
        exit(EXIT_FAILURE);
    } else
        {
            do
            {
                switch(menuDeOpciones())
                {
                case 1:
                    printf("Ingrese el nombre del archivo .csv a cargar: ");
                    fflush(stdin);
                    scanf("%s", nombreArchivo);
                    while(strlen(nombreArchivo) > 20)
                    {
                        printf("Nombre del archivo demasiado largo! Reingrese: ");
                        fflush(stdin);
                        scanf("%s", nombreArchivo);
                    }
                    strcat(nombreArchivo, extensionArchivo);
                    if (lecturaDesdeTexto(nombreArchivo, listaDeBicicletas))
                    {
                        checkLectura = 1;
                    }
                    break;
                case 2:
                    if (checkLectura)
                    {
                        bicicleta_showList(listaDeBicicletas);
                    }
                    break;
                case 3:
                    if(checkLectura)
                    {
                        int i;
                        eBicicleta* auxBici;
                        if(listaDeBicicletas != NULL)
                        {
                            system("cls");
                            printf("--------- ASIGNAR TIEMPOS A BICICLETAS ---------\n\n");
                            printf(" -ID-            -DUENIO-                  -TIPO-                 -TIEMPO- \n");
                            listaDeBicicletas = ll_map(listaDeBicicletas, bici_mapTiempo);
                            for (i = 0; i < ll_len(listaDeBicicletas); i++)
                            {
                                auxBici = (eBicicleta*) ll_get(listaDeBicicletas, i);
                                bicicleta_showInfo(auxBici);
                            }
                        printf("Se ha asignado correctamente los tiempos a las entidades\n");
                        }
                    } else
                        {
                            printf("Se debe cargar un archivo antes de realizar esta accion!\n");
                        }
                    break;
                case 4:
                    if (checkLectura)
                    {
                        filtrarPorTipo(listaDeBicicletas);
                    }
                    break;
                case 5:
                    if (checkLectura)
                    {
                        bicicleta_mostrarPosiciones(listaDeBicicletas);
                        checkPosicion = 1;
                    }
                    break;
                case 6:
                    if (checkLectura && checkPosicion)
                    {
                        strcat(nombreArchivoPosiciones, extensionArchivo);
                        guardarComoTexto(nombreArchivoPosiciones, listaDeBicicletas);
                    } else
                        {
                            printf("Se debe ordenar mostrar posiciones antes de guardarlas!\n");
                        }
                    break;
                case 7:
                    printf("Confirmar salida (s/n): ");
                    fflush(stdin);
                    scanf("%c", &seguir);
                    while (seguir != 's' && seguir != 'n')
                    {
                        printf("Opcion incorrecta, ingrese 's' o 'n': ");
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
    return EXIT_SUCCESS;
}


int menuDeOpciones()
{
    int opcion;
    system("cls");
    printf("-------------- MENU DE OPCIONES --------------\n\n");
    printf("1) Cargar datos desde un archivo\n");
    printf("2) Mostrar lista de bicicletas\n");
    printf("3) Asignar tiempos\n");
    printf("4) Filtrar por Tipo\n");
    printf("5) Mostrar posiciones\n");
    printf("6) Guardar posiciones\n");
    printf("7) SALIR\n\n");
    printf("Elija una opcion: ");
    fflush(stdin);
    scanf("%d", &opcion);

    return opcion;
}
