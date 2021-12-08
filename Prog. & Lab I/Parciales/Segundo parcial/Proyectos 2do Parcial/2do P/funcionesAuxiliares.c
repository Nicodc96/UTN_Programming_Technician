#include <stdlib.h>
#include <stdio.h>
#include <string.h>
#include "LinkedList.h"
#include "funcionesAuxiliares.h"

/** \brief Parsea los datos de las entidades desde el archivo data.csv (modo texto).
 *
 * \param path char*                        | Nombre del archivo a leer y cargar
 * \param pArrayList LinkedList*            | LinkedList principal obtenido de main
 * \return isOk int - (0) Si el char* / LinkedList* / FILE* es igual a NULL
 *                    (1) Si se ha cargado correctamente los datos del archivo
 */
int parser_FromText(FILE* pFile, LinkedList* pArrayList)
{
    int isOk = 0;
    int cant;
    char id[50];
    char nombre[50];
    char tipo[50];
    char tiempo[50];
    eBicicleta* auxBici = NULL;
    if (pFile != NULL && pArrayList != NULL)
    {
        fscanf(pFile, "%[^,],%[^,],%[^,],%[^\n]\n", id, nombre, tipo, tiempo);
        while(!feof(pFile))
        {
            cant = fscanf(pFile, "%[^,],%[^,],%[^,],%[^\n]\n", id, nombre, tipo, tiempo);
            if (cant == 4)
            {
                auxBici = bicicleta_newParametros(id, nombre, tipo, tiempo);
                ll_add(pArrayList, auxBici);
            }
        }
        isOk = 1;
    }
    return isOk;
}

/** \brief Parsea los datos de las entidades desde el archivo data.bin (modo binario).
 *
 * \param path char*                        | Nombre del archivo a leer y cargar
 * \param pArrayList LinkedList*            | LinkedList principal obtenido de main
 * \return isOk int - (0) Si el char* / LinkedList* / FILE* es igual a NULL
 *                    (1) Si se ha cargado correctamente los datos del archivo
 */
int parser_FromBinary(FILE* pFile, LinkedList* pArrayList)
{
    int isOk = 0;
    int cant;
    eBicicleta* auxBici = NULL;
    if (pFile != NULL && pArrayList != NULL)
    {
        while(!feof(pFile))
        {
            auxBici = nuevaBicicleta();
            if(auxBici != NULL)
            {
                cant = fread(auxBici, sizeof(eBicicleta), 1, pFile);
                if(cant == 1)
                {
                    ll_add(pArrayList, auxBici);
                    isOk = 1;
                } else
                    {
                        break;
                    }
            }
        }
    }
    return isOk;
}

/** \brief Crea una nueva entidad bicicleta, asignando espacio en memoria y seteandolo en valores vacios
 *
 * \return new eBicicleta - (NULL) No se pudo asignar en memoria a la nueva entidad
 *                         (eBicicleta*) Si la funcion termino correctamente
 */

eBicicleta* nuevaBicicleta()
{
    eBicicleta* new = (eBicicleta*) malloc(sizeof(eBicicleta));

    if (new != NULL)
    {
        new->id = 0;
        strcpy(new->nombre, "");
        strcpy(new->tipo, "");
        new->tiempo = 0;
    }
    return new;
}

/** \brief Setea una bicicleta con datos obtenidos por parametros de tipo char*
 *
 * \param char* idStr               | ID parametrizado
 * \param char* nombreStr           | Nombre parametrizado
 * \param char* tipoStr             | Tipo parametrizado
 * \param char* tiempoStr           | Tiempo parametrizado
 * \return pBici     -   (NULL) Si no se pudo asignar en memoria espacio para el nuevo empleado
 *                      (eBicicleta*) Si se ha cargado correctamente el empleado con los parametros parseados
 */

eBicicleta* bicicleta_newParametros(char* idStr,char* nombreStr,char* tipoStr, char* tiempoStr)
{
    eBicicleta* pBici = nuevaBicicleta();
    int flag = 0;
    if(pBici != NULL)
    {
        bicicleta_setId(pBici, atoi(idStr));
        bicicleta_setNombre(pBici, nombreStr);
        bicicleta_setTipo(pBici, tipoStr);
        bicicleta_setTiempo(pBici, atoi(tiempoStr));
        flag = 1;
    }
    if (flag != 1)
    {
        pBici = NULL;
    }
    return pBici;
}

/** \brief Setea el ID de una Bicicleta
 *
 * \param eBicicleta* pBici       | Puntero al Bicicleta
 * \param int id                  | Variable que reemplazara el ID de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el ID llegado por parametro es igual a NULL
 *                    (1) Si seteo correctamente el ID
 */

int bicicleta_setId(eBicicleta* pBici, int id)
{
    int isOk = 0;
    if (pBici != NULL)
    {
        pBici->id = id;
        isOk = 1;
    }

    return isOk;
}

/** \brief Obtiene el ID de una Bicicleta
 *
 * \param eBicicleta* pBici        | Puntero al Bicicleta
 * \param int* id                  | Variable donde guardar el ID obtenido de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el ID llegado por parametro es igual a NULL
 *                    (1) Si devuelve el ID obtenido de la bicileta solicitada
 */


int bicicleta_getId(eBicicleta* pBici,int* id)
{
    int isOk = 0;
    if (pBici != NULL && id != NULL)
    {
        *id = pBici->id;
        isOk = 1;
    }

    return isOk;
}

/** \brief Setea el tiempo de una Bicicleta
 *
 * \param eBicicleta* pBici        | Puntero al Bicicleta
 * \param char* nombre             | Variable que reemplazara el nombre de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el nombre llegado por parametro es igual a NULL
 *                    (1) Si seteo correctamente el nombre
 */

int bicicleta_setNombre(eBicicleta* pBici,char* nombre)
{
    int isOk = 0;
    if (pBici != NULL && nombre != NULL)
    {
        strcpy(pBici->nombre, nombre);
        isOk = 1;
    }

    return isOk;
}

/** \brief Obtiene el nombre de una Bicicleta
 *
 * \param eBicicleta* pBici        | Puntero al Bicicleta
 * \param char* nombre             | Variable donde guardar el nombre obtenido de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el nombre llegado por parametro es igual a NULL
 *                    (1) Si devuelve el nombre obtenido de la bicileta solicitada
 */

int bicicleta_getNombre(eBicicleta* pBici,char* nombre)
{
    int isOk = 0;
    if (pBici != NULL)
    {
        strcpy(nombre, pBici->nombre);
        isOk = 1;
    }

    return isOk;
}

/** \brief Setea el tiempo de una Bicicleta
 *
 * \param eBicicleta* pBici       | Puntero al Bicicleta
 * \param int tiempo              | Variable que reemplazara el tiempo de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el tiempo llegado por parametro es igual a NULL
 *                    (1) Si seteo correctamente el tiempo
 */

int bicicleta_setTiempo(eBicicleta* pBici,int tiempo)
{
    int isOk = 0;
    if (pBici != NULL)
    {
        pBici->tiempo = tiempo;
        isOk = 1;
    }

    return isOk;
}

/** \brief Obtiene el tiempo de una Bicicleta
 *
 * \param eBicicleta* pBici       | Puntero al Bicicleta
 * \param int* tiempo             | Variable donde guardar el tiempo obtenido de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el tiempo llegado por parametro es igual a NULL
 *                    (1) Si devuelve el tiempo obtenido de la bicileta solicitada
 */

int bicicleta_getTiempo(eBicicleta* pBici,int* tiempo)
{
    int isOk = 0;
    if (pBici != NULL && tiempo != NULL)
    {
        *tiempo = pBici->tiempo;
        isOk = 1;
    }

    return isOk;
}

/** \brief Setea el Tipo de una Bicicleta
 *
 * \param eBicicleta* pBici       | Puntero al Bicicleta
 * \param char* tipo              | Variable que reemplazara el tipo de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el tipo llegado por parametro es igual a NULL
 *                    (1) Si seteo correctamente el tipo
 */

int bicicleta_setTipo(eBicicleta* pBici,char* tipo)
{
    int isOk = 0;
    if (pBici != NULL && tipo != NULL)
    {
        strcpy(pBici->tipo, tipo);
        isOk = 1;
    }

    return isOk;
}

/** \brief Obtiene el Tipo de una Bicicleta
 *
 * \param eBicicleta* pBici       | Puntero al Bicicleta
 * \param char* tipo              | Variable donde guardar el tipo obtenido de la bicicleta
 * \return isOk int - (0) Si el puntero a bicicleta o el tipo llegado por parametro es igual a NULL
 *                    (1) Si devuelve el tipo obtenido de la bicileta solicitada
 */

int bicicleta_getTipo(eBicicleta* pBici, char* tipo)
{
    int isOk = 0;
    if (pBici != NULL && tipo != NULL)
    {
        strcpy(tipo, pBici->tipo);
        isOk = 1;
    }

    return isOk;
}

/** \brief Muestra los datos de un Empleado llegado por parametro, y los muestro obteniendo sus datos con employee_get
 *
 * \param pEmp Employee*        | Puntero a Empleado
 */

void bicicleta_showInfo(eBicicleta* pBici)
{
    if(pBici != NULL)
    {
        int id;
        char nombre[128];
        char tipo[128];
        int tiempo;

        bicicleta_getId(pBici, &id);
        bicicleta_getNombre(pBici, nombre);
        bicicleta_getTipo(pBici, tipo);
        bicicleta_getTiempo(pBici, &tiempo);

        printf("   %4d    %14s               %14s            %5d Hs\n", id, nombre, tipo, tiempo);
    }
}

/** \brief Carga los datos de las bicicletas desde el archivo data.csv (modo texto).
 *
 * \param path char*                        | Nombre del archivo a leer y cargar
 * \param LinkedList* pLista                | Lista obtenida desde Main
 * \return isOk int (0) - No se pudo cargar los datos del archivo "data.csv"
 *                  (1) - Se cargo correctamente los datos del archivo "data.csv"
 */
int lecturaDesdeTexto(char* path, LinkedList* pLista)
{
    int isOk = 0;
    int checkParser = 0;
    FILE* fArchivo = fopen(path, "r");
    if(fArchivo != NULL && pLista != NULL)
    {
        checkParser = parser_FromText(fArchivo, pLista);
    }
    if (checkParser)
    {
        printf("\n------ Se ha cargado correctamente los datos del Archivo! ------\n");
        printf("------ Datos cargados: %d\n",ll_len(pLista));
        isOk = 1;
    }
    else
    {
        printf("------ Error! No se ha podido cargar los datos del Archivo! ------\n");
    }
    fclose(fArchivo);
    return isOk;
}

/** \brief Carga los datos de las bicicletas desde el archivo data.bin (modo binario).
 *
 * \param path char*                        | Nombre del archivo a leer y cargar
 * \param LinkedList* pLista                | Lista obtenida desde Main
 * \return isOk int (0) - No se pudo cargar los datos del archivo "data.bin"
 *                  (1) - Se cargo correctamente los datos del archivo "data.bin"
 */
int lecturaDesdeBinario(char* path, LinkedList* pLista)
{
    int isOk = 0;
    int checkParser = 0;
    FILE* fArchivo = fopen(path, "rb");
    if (pLista != NULL && path != NULL)
    {
        checkParser = parser_FromBinary(fArchivo, pLista);
    }
    if (checkParser)
    {
        printf("\n------ Se ha cargado correctamente los datos del Archivo! ------\n");
        printf("------ Datos cargados: %d\n",ll_len(pLista));
        isOk = 1;
    }
    else
    {
        printf("\n------Error! No se ha podido cargar los datos del Archivo! ------\n");
    }
    fclose(fArchivo);
    return isOk;
}

/** \brief Muestra la lista de Bicicletas completa
 *
 * \param LinkedList* listaBicicletas       | Puntero a Lista
 */

void bicicleta_showList(LinkedList* listaBicicletas)
{
    int i;
    eBicicleta* auxBici = NULL;
    system("cls");
    if(listaBicicletas != NULL)
    {
        printf("---------- LISTA DE BICICLETAS CARGADAS ---------\n\n");
        printf(" -ID-            -DUENIO-                  -TIPO-                 -TIEMPO- \n");
        for (i = 0; i < ll_len(listaBicicletas); i++)
        {
            auxBici = (eBicicleta*) ll_get(listaBicicletas, i);
            bicicleta_showInfo(auxBici);
        }
    }
    printf("------ Dato(s) cargado(s): %d\n",ll_len(listaBicicletas));
}

/** \brief Funcion mapeadora para Asignar tiempos
 *
 * \param void* pElement    | Puntero a elemento
 *
 */

void bici_mapTiempo(void* pElement)
{
    int auxTiempo;
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        auxTiempo = rand()%(71)+50;
        bicicleta_setTiempo(auxBici, auxTiempo);
    }
}

/** \brief Funcion filtradora para usar con ll_filter() | Filtra por BMX
 *
 * \param void* pElement    | Puntero a elemento
 *
 */
int bici_filterPorBMX(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bicicleta_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "BMX") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

/** \brief Funcion filtradora para usar con ll_filter() | Filtra por PLAYERA
 *
 * \param void* pElement    | Puntero a elemento
 *
 */
int bici_filterPorPlayera(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bicicleta_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "PLAYERA") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

/** \brief Funcion filtradora para usar con ll_filter() | Filtra por MTB
 *
 * \param void* pElement    | Puntero a elemento
 *
 */
int bici_filterPorMTB(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bicicleta_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "MTB") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

/** \brief Funcion filtradora para usar con ll_filter() | Filtra por PASEO
 *
 * \param void* pElement    | Puntero a elemento
 *
 */
int bici_filterPorPaseo(void* pElement)
{
    int isOk = 0;
    char auxTipo[20];
    eBicicleta* auxBici = NULL;
    if(pElement != NULL)
    {
        auxBici = (eBicicleta*) pElement;
        bicicleta_getTipo(auxBici, auxTipo);
        if(strcmp(auxTipo, "PASEO") == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

/** \brief Genera una nueva lista con elementos filtrados a eleccion
 *
 * \param LinkedList* lista | Puntero a la lista obtenida de main
 * \return int isOk         | (1) Si pudo filtrar por algun tipo de manera correcta
 *                            (0) Si se ha cancelado la operacion
 */
int filtrarPorTipo(LinkedList* lista)
{
    LinkedList* nuevaLista = NULL;
    int isOk = 0;
    int i, id, tiempo, opcion;
    char duenio[20], tipo[20];
    char seguir = 'n';
    FILE* fArchivo = NULL;
    eBicicleta* auxBici = NULL;
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
            bicicleta_getId(auxBici, &id);
            bicicleta_getNombre(auxBici, duenio);
            bicicleta_getTipo(auxBici, tipo);
            bicicleta_getTiempo(auxBici, &tiempo);
            fprintf(fArchivo, "%d,%s,%s,%d\n", id, duenio, tipo, tiempo);
            isOk = 1;
        }
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
            bicicleta_getId(auxBici, &id);
            bicicleta_getNombre(auxBici, duenio);
            bicicleta_getTipo(auxBici, tipo);
            bicicleta_getTiempo(auxBici, &tiempo);
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
            bicicleta_getId(auxBici, &id);
            bicicleta_getNombre(auxBici, duenio);
            bicicleta_getTipo(auxBici, tipo);
            bicicleta_getTiempo(auxBici, &tiempo);
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
            bicicleta_getId(auxBici, &id);
            bicicleta_getNombre(auxBici, duenio);
            bicicleta_getTipo(auxBici, tipo);
            bicicleta_getTiempo(auxBici, &tiempo);
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
            while (seguir != 's' && seguir != 'n')
            {
                printf("Opcion seleccionada incorrecta, reintente (s/n): ");
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

/** \brief Muestra la lista aplicando dos ordenamientos: por tipo y por tiempo
 *
 * \param LinkedList* lista     | Lista obtenida de main
 *
 */
void bicicleta_mostrarPosiciones(LinkedList* lista)
{
    printf("---------- LISTA DE BICICLETAS ORDENADAS POR TIPO Y TIEMPO ASCENDENTE ---------\n\n");
    printf(" -ID-            -DUENIO-                  -TIPO-                 -TIEMPO- \n");
    if (!ll_sort(lista, ordenarPorTipo, 1) && !ll_sort(lista, ordenarPorTiempo, 1))
    {
        bicicleta_showList(lista);
    }
}

/** \brief Funcion ordenadora por tipo para ll_filter
 *
 * \param void* pElement1   | Primer elemento a comparar
 * \param void* pElement2   | Segundo elemento a comparar
 * \return int valor        | (1) - Ascendente | (-1) Descendente | (0) Iguales
 *
 */
int ordenarPorTipo(void* pElement1, void* pElement2)
{
    int valor;
    eBicicleta* auxBici1 = NULL;
    eBicicleta* auxBici2 = NULL;
    if (pElement1 != NULL && pElement2 != NULL)
    {
        auxBici1 = (eBicicleta*) pElement1;
        auxBici2 = (eBicicleta*) pElement2;
        valor = strcmp(auxBici1->tipo, auxBici2->tipo);
    }
    return valor;
}

/** \brief Funcion ordenadora por tiempo para ll_filter
 *
 * \param void* pElement1   | Primer elemento a comparar
 * \param void* pElement2   | Segundo elemento a comparar
 * \return int valor        | (1) - Ascendente | (-1) Descendente | (0) Iguales
 *
 */
int ordenarPorTiempo(void* pElement1, void* pElement2)
{
    int valor = 0;
    eBicicleta* auxBici1 = NULL;
    eBicicleta* auxBici2 = NULL;
    if (pElement1 != NULL && pElement2 != NULL)
    {
        auxBici1 = (eBicicleta*) pElement1;
        auxBici2 = (eBicicleta*) pElement2;
        if (strcmp(auxBici1->tipo, auxBici2->tipo) == 0 && auxBici1->tiempo > auxBici2->tiempo)
        {
            valor = 1;
        } else if (strcmp(auxBici1->tipo, auxBici2->tipo) == 0 && auxBici1->tiempo < auxBici2->tiempo)
        {
            valor = -1;
        }
    }
    return valor;
}

/** \brief Guarda los datos de las entidades en el archivo .csv (modo texto)
 *
 * \param path char*                        | Nombre del archivo a leer y cargar
 * \param pArrayList LinkedList*            | LinkedList principal obtenido de main
 * \return isOk int  (0) - Si hubo un error en guardar los datos en el archivo "[...].csv"
 *                   (1) - Si se guardo exitosamente los datos en el archivo   "[...].csv"
 */
int guardarComoTexto(char* path, LinkedList* pArrayList)
{
    int isOk = 0;
    int i, id, tiempo;
    char tipo[50];
    char nombre[50];
    FILE* fArchivo = fopen(path, "w");
    eBicicleta* pBici = NULL;
    if(path != NULL && pArrayList != NULL && fArchivo != NULL)
    {
        fprintf(fArchivo, "id_bike,nombre,tipo,tiempo\n");
        for(i = 0; i < (ll_len(pArrayList)); i++)
        {
            pBici = (eBicicleta*) ll_get(pArrayList, i);
            if (bicicleta_getId(pBici, &id) &&
                bicicleta_getTiempo(pBici, &tiempo) &&
                bicicleta_getTipo(pBici, tipo) &&
                bicicleta_getNombre(pBici, nombre))
            {
                fprintf(fArchivo, "%d,%s,%s,%d\n", id, nombre, tipo, tiempo);
                isOk = 1;
            }
        }
        printf("\n------ Datos guardados correctamente en modo TEXTO! ------\n");
    }
    fclose(fArchivo);
    return isOk;
}
