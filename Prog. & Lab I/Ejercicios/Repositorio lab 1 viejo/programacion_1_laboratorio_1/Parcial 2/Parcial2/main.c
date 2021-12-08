#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Controller.h"
#include "Linkedlist.h"
#include "Cachorro.h"

int menuDeOpciones();

int main()
{
    char seguir = 'n';
    int checkText = 0;
    char nombreArchivo[20];
    char extensionArchivo[20] = ".csv";
    FILE* fArchivo = NULL;
    LinkedList* listaCachorros = ll_newLinkedList();

    do
    {
        switch(menuDeOpciones())
        {
        case 1:
            printf("Ingrese el nombre del archivo: ");
            fflush(stdin);
            gets(nombreArchivo);
            strcat(nombreArchivo, extensionArchivo);
            fArchivo = fopen(nombreArchivo, "r");
            if(fArchivo != NULL)
            {
                controller_loadArchive(nombreArchivo, listaCachorros);
                checkText = 1;
            } else
                {
                    printf("------ Error! No se ha encontrado el Archivo! ------\n");
                }
            break;
        case 2:
            controller_listArchive(listaCachorros);
            break;
        case 3:
            if(checkText)
            {
                if (controller_filter45Days(listaCachorros))
                {
                    printf("-------- Se ha generado un nuevo archivo con los datos filtrados! --------\n");
                } else
                    {
                        printf("-------- Error! No se ha podido filtrar la lista! --------\n");
                    }
            } else
                {
                    printf("------ Se debe cargar un archivo antes de realizar esta accion! ------\n");
                }
            break;
        case 4:
            if(checkText)
            {
                if(controller_filterMachos(listaCachorros))
                {
                    printf("-------- Se ha generado un nuevo archivo con los datos filtrados! --------\n");
                } else
                    {
                        printf("-------- Error! No se ha podido filtrar la lista! --------\n");
                    }
            } else
            {
                printf("------ Se debe cargar un archivo antes de realizar esta accion! ------\n");
            }
            break;
        case 5:
            if(checkText)
            {
                controller_listCallejeros(listaCachorros);
            } else
                {
                    printf("------ Se debe cargar un archivo antes de realizar esta accion! ------\n");
                }
            break;
        case 6:
            printf("Confirmar salida (y/n): ");
            fflush(stdin);
            scanf("%c", &seguir);
            while(seguir != 'y' && seguir != 'n')
            {
                printf("Respuesta incorrecta, ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &seguir);
            }
            break;
        }
        system("pause");
    }while(seguir == 'n');

    return 0;
}

int menuDeOpciones()
{
    int opcion;
    system("cls");
    printf("------- MENU DE OPCIONES | REFUGIO DE CACHORROS ------\n\n");
    printf("1) CARGAR ARCHIVO\n");
    printf("2) IMPRIMIR LISTA\n");
    printf("3) FILTRAR MENORES DE 45 DIAS\n");
    printf("4) FILTRAR MACHOS\n");
    printf("5) GENERAR LISTADO DE CALLEJEROS\n");
    printf("6) SALIR\n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);

    return opcion;
}
