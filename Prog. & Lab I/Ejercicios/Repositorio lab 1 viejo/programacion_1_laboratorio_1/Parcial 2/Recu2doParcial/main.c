#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Bicicleta.h"
#include "time.h"
#include "Linkedlist.h"
#include "Controller.h"

int menuDeOpciones();

int main()
{
    srand (time(NULL));
    LinkedList* listaBicicletas = ll_newLinkedList();
    char seguir = 'n';
    int checkText = 0, checkPosicion = 0;
    char nombreArchivo[20];
    FILE* fArchivo;

    do{
            switch(menuDeOpciones())
            {
                case 1:
                    printf("Ingrese el nombre del archivo: ");
                    fflush(stdin);
                    gets(nombreArchivo);
                    strcat(nombreArchivo, ".csv");
                    fArchivo = fopen(nombreArchivo, "r");
                    if(fArchivo != NULL)
                    {
                        controller_loadText(nombreArchivo, listaBicicletas);
                        checkText = 1;
                    } else
                        {
                            printf("No se ha encontrado el archivo con el nombre ingresado!\n");
                        }
                break;
                case 2:
                    controller_showList(listaBicicletas);
                break;
                case 3:
                    if(checkText)
                    {
                        int i;
                        eBicicleta* auxBici;
                        if(listaBicicletas != NULL)
                        {
                            system("cls");
                            printf("--------- ASIGNAR TIEMPOS A BICICLETAS ---------\n\n");
                            printf(" -ID-         -DUENIO-               -TIPO-                -TIEMPO- \n");
                            listaBicicletas = ll_map(listaBicicletas, bici_mapTiempo);
                            for (i = 0; i < ll_len(listaBicicletas); i++)
                            {
                                auxBici = (eBicicleta*) ll_get(listaBicicletas, i);
                                bici_showInfo(auxBici);
                            }
                        printf("Se ha asignado correctamente los tiempos a las entidades\n");
                        }
                    } else
                        {
                            printf("Se debe cargar un archivo antes de realizar esta accion!\n");
                        }
                break;
                case 4:
                    if(checkText)
                    {
                        controller_filterType(listaBicicletas);
                    } else
                        {
                            printf("Se debe cargar un archivo antes de realizar esta accion!\n");
                        }
                break;
                case 5:
                    if(checkText)
                    {
                        controller_showPosiciones(listaBicicletas);
                    } else
                        {
                            printf("Se debe cargar un archivo antes de realizar esta accion!\n");
                        }
                break;
                case 6:
                    printf("Confirmar salida (y/n): ");
                    fflush(stdin);
                    scanf("%c", &seguir);
                    while (seguir != 'y' && seguir != 'n')
                    {
                        printf("Opcion seleccionada incorrecta, reintente (y/n): ");
                        fflush(stdin);
                        scanf("%c", &seguir);
                    }
                break;
                default:
                    printf("Opcion seleccionada incorrecta, reingrese.\n");
            }
        system("pause");
    }while(seguir == 'n');

    return 0;
}

int menuDeOpciones()
{
    int opcion;
    system("cls");
    printf("--------- MENU DE OPCIONES ----------\n\n");
    printf("1) CARGAR ARCHIVO\n");
    printf("2) IMPRIMIR LISTA\n");
    printf("3) ASIGNAR TIEMPOS\n");
    printf("4) FILTRAR POR TIPO\n");
    printf("5) MOSTRAR POSICIONES\n");
    printf("6) SALIR \n\n");
    printf("Ingrese Opcion: ");
    fflush(stdin);
    scanf("%d", &opcion);

    return opcion;
}
