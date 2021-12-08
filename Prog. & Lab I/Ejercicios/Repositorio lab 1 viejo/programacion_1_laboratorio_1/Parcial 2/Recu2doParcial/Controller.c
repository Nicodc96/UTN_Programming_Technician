#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Linkedlist.h"
#include "Bicicleta.h"
#include "Parser.h"
#include "Linkedlist.h"
#include "Controller.h"

int controller_loadText(char* path,LinkedList* lista)
{
    int isOk = 0;
    int checkParser;

    checkParser = parser_text(path, lista);

    if (checkParser)
    {
        printf("\n------ Se ha cargado correctamente los datos del Archivo! ------\n");
        printf("------ Datos cargados: %d\n",ll_len(lista));
        isOk = 1;
    } else
        {
            printf("------ Error! No se ha podido cargar los datos del Archivo! ------\n");
        }

    return isOk;
}

int controller_showList(LinkedList* lista)
{
    int isOk = 0;
    int i;
    eBicicleta* auxBici;
    system("cls");
    printf("---------- LISTA DE BICICLETAS CARGADAS ---------\n\n");
    printf(" -ID-  -DUENIO-      -TIPO-  -TIEMPO- \n");

    for(i = 0; i < ll_len(lista); i++)
    {
        auxBici = ll_get(lista, i);
        bici_showInfo(auxBici);
        isOk = 1;
    }
    printf("------ Dato(s) cargado(s): %d\n",ll_len(lista));
    return isOk;
}

int controller_filterType(LinkedList* lista)
{
    LinkedList* nuevaLista = NULL;
    int isOk = 0;
    int i, id, tiempo, opcion;
    char duenio[20], tipo[20];
    char seguir = 'n';
    FILE* fArchivo;
    eBicicleta* auxBici;
    system("cls");
    printf("--------- FILTRAR LISTA POR TIPO ---------\n\n");
    printf("TIPOS: \n1) BMX\n2) PLAYERA\n3) MTB\n4) PASEO\n\n5) SALIR\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);
    do{
    switch(opcion)
    {
    case 1:
        nuevaLista = ll_filter(lista, bici_filterPorBMX);
        fArchivo = fopen("bicicletasBMX.csv", "w");
        fprintf(fArchivo, "id_bike,nombre,tipo,tiempo\n");
        for(i = 0; i < ll_len(nuevaLista); i++)
        {
            auxBici = (eBicicleta*) ll_get(nuevaLista, i);
            bici_getId(auxBici, &id);
            bici_getDuenio(auxBici, duenio);
            bici_getTipo(auxBici, tipo);
            bici_getTiempo(auxBici, &tiempo);
            fprintf(fArchivo, "%d,%s,%s,%d\n", id, duenio, tipo, tiempo);
            isOk = 1;
        }
        printf("--------- Se ha generado una lista con el tipo filtrado ---------\n");
        seguir = 'y';
        fclose(fArchivo);
        break;
    case 2:
        nuevaLista = ll_filter(lista, bici_filterPorPlayera);
        fArchivo = fopen("bicicletasPLAYERAS.csv", "w");
        fprintf(fArchivo, "id_bike,nombre,tipo,tiempo\n");
        for(i = 0; i < ll_len(nuevaLista); i++)
        {
            auxBici = (eBicicleta*) ll_get(nuevaLista, i);
            bici_getId(auxBici, &id);
            bici_getDuenio(auxBici, duenio);
            bici_getTipo(auxBici, tipo);
            bici_getTiempo(auxBici, &tiempo);
            fprintf(fArchivo, "%d,%s,%s,%d\n", id, duenio, tipo, tiempo);
            isOk = 1;
        }
        printf("--------- Se ha generado una lista con el tipo filtrado ---------\n");
        seguir = 'y';
        fclose(fArchivo);
        break;
    case 3:
        nuevaLista = ll_filter(lista, bici_filterPorMTB);
        fArchivo = fopen("bicicletasMTB.csv", "w");
        fprintf(fArchivo, "id_bike,nombre,tipo,tiempo\n");
        for(i = 0; i < ll_len(nuevaLista); i++)
        {
            auxBici = (eBicicleta*) ll_get(nuevaLista, i);
            bici_getId(auxBici, &id);
            bici_getDuenio(auxBici, duenio);
            bici_getTipo(auxBici, tipo);
            bici_getTiempo(auxBici, &tiempo);
            fprintf(fArchivo, "%d,%s,%s,%d\n", id, duenio, tipo, tiempo);
            isOk = 1;
        }
        printf("--------- Se ha generado una lista con el tipo filtrado ---------\n");
        seguir = 'y';
        fclose(fArchivo);
        break;
    case 4:
        nuevaLista = ll_filter(lista, bici_filterPorPaseo);
        fArchivo = fopen("bicicletasPASEO.csv", "w");
        fprintf(fArchivo, "id_bike,nombre,tipo,tiempo\n");
        for(i = 0; i < ll_len(nuevaLista); i++)
        {
            auxBici = (eBicicleta*) ll_get(nuevaLista, i);
            bici_getId(auxBici, &id);
            bici_getDuenio(auxBici, duenio);
            bici_getTipo(auxBici, tipo);
            bici_getTiempo(auxBici, &tiempo);
            fprintf(fArchivo, "%d,%s,%s,%d\n", id, duenio, tipo, tiempo);
            isOk = 1;
        }
        printf("--------- Se ha generado una lista con el tipo filtrado ---------\n");
        seguir = 'y';
        fclose(fArchivo);
        break;
    case 5:
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
        printf("Opcion seleccionada incorrecta!\n");
    }
    system("pause");
    }while(seguir == 'n');

    return isOk;
}

int controller_showPosiciones(LinkedList* lista)
{
    int isOk = 0;
    int i,j;
    char tipo1[20], tipo2[20], auxTipo[20];
    int tiempo1, tiempo2, auxTiempo;
    int id1, id2, auxId;
    char duenio1[20], duenio2[20], auxDuenio[20];
    eBicicleta* auxBici;
    eBicicleta* auxBiciUno;
    eBicicleta* auxBiciDos;
    if (lista != NULL)
    {
        for(i = 0; i < (ll_len(lista) - 1); i++)
        {
            auxBiciUno = (eBicicleta*) ll_get(lista, i);
            bici_getTipo(auxBiciUno, tipo1);
            bici_getTiempo(auxBiciUno, &tiempo1);
            bici_getId(auxBiciUno, &id1);
            bici_getDuenio(auxBiciUno, duenio1);

            for(j = 1; j < ll_len(lista); j++)
            {
                auxBiciDos = (eBicicleta*) ll_get(lista, j);
                bici_getTipo(auxBiciDos, tipo2);
                bici_getTiempo(auxBiciDos, &tiempo2);
                bici_getId(auxBiciUno, &id2);
                bici_getDuenio(auxBiciUno, duenio2);

                if(strcmp(tipo1, tipo2)<0)
                {
                    bici_setID(auxBiciUno, id2);
                    bici_setDuenio(auxBiciUno, duenio2);
                    bici_setTipo(auxBiciUno, tipo2);
                    bici_setTiempo(auxBiciUno, tiempo2);

                    bici_setID(auxBiciDos, id1);
                    bici_setDuenio(auxBiciDos, duenio1);
                    bici_setTipo(auxBiciDos, tipo1);
                    bici_setTiempo(auxBiciDos, tiempo1);
                }
                if(strcmp(tipo1,tipo2)==0 && tiempo1 > tiempo2)
                {
                    bici_setID(auxBiciUno, id2);
                    bici_setDuenio(auxBiciUno, duenio2);
                    bici_setTipo(auxBiciUno, tipo2);
                    bici_setTiempo(auxBiciUno, tiempo2);

                    bici_setID(auxBiciDos, id1);
                    bici_setDuenio(auxBiciDos, duenio1);
                    bici_setTipo(auxBiciDos, tipo1);
                    bici_setTiempo(auxBiciDos, tiempo1);
                }
            }
        }
        isOk = 1;
        system("cls");
        printf("---------- LISTA ORDENADA ---------\n\n");
        printf(" -ID-  -DUENIO-      -TIPO-  -TIEMPO- \n");

        for(i = 0; i < ll_len(lista); i++)
        {
            auxBici = (eBicicleta*) ll_get(lista, i);
            bici_showInfo(auxBici);
        }
    }

    return isOk;
}
