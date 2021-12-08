#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>
#include "funciones.h"
#include "linkedList.h"
#include "vehiculos.h"
#include "dominio.h"

void dominio_printfMenu()
{
    printf("--Vehiculos UTN--");
    printf("\n1) Cargar Archivo.\n2) Imprimir Datos.\n3) Guardar Datos .\n4) Salir.\n");
}

void dominio_leerNombreArch(char *nombreArchivo)
{
    int aux;

    do
    {
        aux = getString(nombreArchivo, "Nombre del archivo: ", "El largo debe ser entre 2 y 50", 2, 50);

        if(aux != 0)
        {
            printf("\n");
        }

    }while(aux != 0);
}

int dominio_loadFromText(char* path, LinkedList* pArrayList)
{
    FILE *pFile;
    int r;
    char var1[50], var2[50], var3[50];

    pFile = fopen(path,"r");

    if(pFile == NULL)
    {
        return -1;
    }

    r = fscanf(pFile,"%[^,],%[^,],%[^\n]\n", var1, var2, var3);
    do
    {
        r = fscanf(pFile,"%[^,],%[^,],%[^\n]\n", var1, var2, var3);
        if(r == 3)
        {
            Vehiculo* this = vehiculo_newParametros(var1, var2, var3);
            ll_add(pArrayList, this);
        }
        else
        {
            break;
        }
    }while(!feof(pFile));

    fclose(pFile);
    return 1;
}

int dominio_saveAsText(char* path, LinkedList* pArrayList)
{
    int i = 0;
    FILE *pFile;
    Vehiculo *pers;

    if((pFile = fopen(path,"w"))==NULL)
    {
		printf("No se pudo abrir el archivo");
	}

	fprintf(pFile,"id,dominio,anio,tipo");

	for(i = 0; i < ll_len(pArrayList); i++)
    {
        pers = ll_get(pArrayList, i);
        fprintf(pFile,"\n%d,%s,%d,%c",vehiculo_getId(pers),vehiculo_getDominio(pers),
                                        vehiculo_getAnio(pers),vehiculo_getTipo(pers));
	}

	fclose(pFile);
    return 1;
}

int dominio_ListVehiculo(LinkedList* pArrayListEmployee)
{
    Vehiculo *pers;
    int i;

    printf("-ID-   -DOMINIO-   -ANIO-   -TIPO-\n");

    for(i = 0; i < ll_len(pArrayListEmployee); i++)
    {
        pers = ll_get(pArrayListEmployee, i);

        printf("%4d      %s     %d     %c\n",vehiculo_getId(pers),vehiculo_getDominio(pers),
                                        vehiculo_getAnio(pers),vehiculo_getTipo(pers));
	}

    return 1;
}

void dominio_mapTipo(void* pElement)
{
    char aux[10];

    if (pElement != NULL)
    {
        strcpy(aux, vehiculo_getDominio(pElement));

        if (isdigit(aux[0]) == 0)
        {
            vehiculo_setTipo(pElement, 'A');
        }
        else
        {
            vehiculo_setTipo(pElement, 'M');
        }
    }
}

int dominio_filtrarMotos(void* pElement)
{
    int ok = 0;
    Vehiculo* motos;

    if(pElement != NULL)
    {
        motos = (Vehiculo*) pElement;

        if(motos->tipo == 'M')
        {
            ok = 1;
        }
    }

    return ok;
}

int dominio_filtrarAutos(void* pElement)
{
    int ok = 0;
    Vehiculo* autos;

    if(pElement != NULL)
    {
        autos = (Vehiculo*) pElement;
        if(autos->tipo == 'A')
        {
            ok = 1;
        }
    }

    return ok;
}

void dominio_menuInicio()
{
    LinkedList* auxiliar = ll_newLinkedList();
    LinkedList* listaMotos = ll_newLinkedList();
    LinkedList* listaAutos = ll_newLinkedList();
    int option = 0;
    int aux;
    int auxiliarM = 0;
    char nombreArchivo[51];

    do
    {
        dominio_printfMenu();

        do
        {
            aux = getInt(&option, "\nOpcion: ", "Rango valido [1 - 4]", 1, 4);

            if(aux != 0)
            {
                printf("\n");
            }
        }while(aux != 0);

        switch(option)
        {
            case 1:
                system("cls");
                dominio_leerNombreArch(nombreArchivo);
                strcat(nombreArchivo, ".csv");
                aux = dominio_loadFromText(nombreArchivo, auxiliar);
                ll_map(auxiliar, dominio_mapTipo);
                listaMotos = ll_filter(auxiliar, dominio_filtrarMotos);
                listaAutos = ll_filter(auxiliar, dominio_filtrarAutos);

                system("cls");
                if(aux == 1)
                {
                    printf("Cantidad de elementos en la lista: %d\n\n", ll_len(auxiliar));
                    auxiliarM = 1;
                }
                else
                {
                    printf("Error! Archivo no existe!\n");
                    system("pause");
                    system("cls");
                }
                break;

            case 2:
                if(auxiliarM == 1)
                {
                    system("cls");
                    dominio_ListVehiculo(auxiliar);
                    system("pause");
                    system("cls");
                }
                else
                {
                    printf("ERROR! No se cargaron los elementos!\n\n");
                    system("pause");
                    system("cls");
                }
                break;

            case 3:
                if(auxiliarM == 1)
                {
                    system("cls");
                    printf("Los elementos se guardaron exitosamente!\n\n");
                    dominio_saveAsText("auto.csv", listaAutos);
                    dominio_saveAsText("moto.csv", listaMotos);
                    system("pause");
                    system("cls");
                }
                else
                {
                    printf("ERROR! No se cargaron los elementos!\n\n");
                    system("pause");
                    system("cls");
                }
                break;

            case 4:
                break;
        }

    }while(option != 4);
}
