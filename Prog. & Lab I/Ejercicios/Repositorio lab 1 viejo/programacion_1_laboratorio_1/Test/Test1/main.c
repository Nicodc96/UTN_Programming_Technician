#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#define TAM 5

typedef struct
{
    int id;
    char patente[10];
}eVehiculo;

typedef struct
{
    int cantidad;
    eVehiculo* vehiculo;
}eVehiculos;

int menuDeOpciones();
void mostrarVehiculo(eVehiculo arrayVehiculos);
void mostrarVehiculos(eVehiculo arrayVehiculos[], int tamanioArray);
int guardarEnBinario(eVehiculo** listaVehiculos, eVehiculo* arrayInicial, int tamanioArray, char* path);
int cargarEnBinario(eVehiculo** listaVehiculos, char* path);
void mostrarDatosCargados(eVehiculo** listaVehiculos, int tamArray);
void mostrarVehiculoPuntero(eVehiculo* vehiculo);
eVehiculo* new_Vehiculo();
eVehiculo** agrandarLista(eVehiculo** listaVehiculos, int tam);

int main()
{
    eVehiculo arrayVehiculos[TAM] = {
    {44, "FPD034"},
    {55, "XSD452"},
    {99, "ALB890"},
    {124, "LLK534"},
    {21, "KBB331"}
    };
    eVehiculo** listaVehiculos = (eVehiculo**) malloc(sizeof(eVehiculo*));
    char nombreArchivo[20];
    char seguir = 'n';
    int checkBin = 0;
    FILE* fArchivo = NULL;

    do{
        switch(menuDeOpciones())
        {
        case 1:
            printf("Ingrese el nombre del archivo a cargar: ");
            fflush(stdin);
            gets(nombreArchivo);
            strcat(nombreArchivo, ".bin");
            fArchivo = fopen(nombreArchivo, "rb");
            if(fArchivo != NULL && listaVehiculos != NULL)
            {
                if (cargarEnBinario(listaVehiculos, nombreArchivo))
                {
                    printf("Se ha cargado correctamente el archivo!\n");
                    checkBin = 1;
                } else
                    {
                        printf("Se produjo un error al leer el archivo!\n");
                    }
            } else
                {
                    printf("Nombre del archivo ingresado, no existe!\n");
                }
            break;
        case 2:
            mostrarVehiculos(arrayVehiculos, TAM);
            break;
        case 3:
            if(checkBin)
            {
                mostrarDatosCargados(listaVehiculos, TAM);
            } else
                {
                    printf("Se debe cargar un archivo antes de listar!\n");
                }
            break;
        case 4:
                printf("Ingrese el nombre del archivo a guardar: ");
                fflush(stdin);
                gets(nombreArchivo);
                strcat(nombreArchivo, ".bin");
                if (guardarEnBinario(listaVehiculos, arrayVehiculos, TAM, nombreArchivo))
                {
                    printf("Archivo guardado correctamente en modo binario!\n");
                } else
                    {
                        printf("Error! No se ha podido guardar el archivo!\n");
                    }
            break;
        case 5:
            printf("Confimar salida (y/n): ");
            fflush(stdin);
            scanf("%c", &seguir);
            while (seguir != 'y' && seguir != 'n')
            {
                printf("Opcion seleccionada incorrecta, ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &seguir);
            }
            break;
        default:
            printf("Opcion seleccionada incorrecta, reingrese!\n");
        }
        system("pause");
    }while(seguir == 'n');

    return 0;
}

int menuDeOpciones()
{
    int opcion;
    system("cls");
    printf("------ MENU DE OPCIONES ------\n\n");
    printf("1) CARGAR ARCHIVO BINARIO\n");
    printf("2) LISTAR VEHICULOS HARDCODEADOS\n");
    printf("3) LISTAR DATOS CARGADOS\n");
    printf("4) GUARDAR ARCHIVO EN BINARIO\n");
    printf("5) SALIR\n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);

    return opcion;
}

void mostrarVehiculo(eVehiculo arrayVehiculos)
{
    printf("  %3d      %10s\n", arrayVehiculos.id, arrayVehiculos.patente);
}

void mostrarVehiculos(eVehiculo arrayVehiculos[], int tamanioArray)
{
    int i;
    system("cls");
    printf("------ LISTA DE VEHICULOS ------\n\n");
    printf(" - ID -  ||  - PATENTE -\n");
    for (i = 0; i < tamanioArray; i++)
    {
        mostrarVehiculo(arrayVehiculos[i]);
    }
}

int guardarEnBinario(eVehiculo** listaVehiculos, eVehiculo* arrayInicial, int tamanioArray, char* path)
{
    FILE* fArchivo = fopen(path, "wb");
    int i, cant, isOk = 0;
    if (fArchivo != NULL && tamanioArray > 0)
    {
        for (i = 0; i < 5; i++)
        {
            *(listaVehiculos + i) = &arrayInicial[i];
        }
        for(i = 0; i < 5; i++)
        {
            cant = fwrite(*(listaVehiculos + i), sizeof(eVehiculo), 1, fArchivo);
            if (cant == 1)
            {
                isOk = 1;
            }
        }
    }

    fclose(fArchivo);
    return isOk;
}

int cargarEnBinario(eVehiculo** listaVehiculos, char* path)
{
    int isOk = 0, cant;
    FILE* fArchivo = fopen(path, "rb");
    int tamArchivoCargado = 0;

    if(path != NULL && fArchivo != NULL)
    {
            while(!(feof(fArchivo)))
            {
                eVehiculo* auxVeh = new_Vehiculo();
                cant = fread(auxVeh, sizeof(eVehiculo), 1, fArchivo);
                if (cant == 1)
                {
                    *(listaVehiculos + tamArchivoCargado) = auxVeh;
                    tamArchivoCargado++;
                    isOk = 1;
                }
                if((listaVehiculos = agrandarLista(listaVehiculos, tamArchivoCargado)) == NULL)
                {
                    printf("No se ha podido agrandar la lista!\n");
                    system("pause");
                }
            }
    }
    return isOk;
}

void mostrarDatosCargados(eVehiculo** listaVehiculos, int tamArray)
{
    int i;
    system("cls");
    printf("------ LISTA DE VEHICULOS ------\n\n");
    printf(" - ID -  ||  - PATENTE -\n");
    for(i = 0; i < tamArray; i++)
    {
        mostrarVehiculoPuntero(*(listaVehiculos + i));
    }
}

void mostrarVehiculoPuntero(eVehiculo* vehiculo)
{
    printf("  %3d      %10s\n", vehiculo->id, vehiculo->patente);
}

eVehiculo* new_Vehiculo()
{
    eVehiculo* auxVehiculo = (eVehiculo*) malloc(sizeof(eVehiculo));
    if (auxVehiculo != NULL)
    {
        auxVehiculo->id = 0;
        strcpy(auxVehiculo->patente, "");
    }
    return auxVehiculo;
}

eVehiculo** agrandarLista(eVehiculo** listaVehiculos, int tam)
{
    eVehiculo** auxLista = (eVehiculo**) realloc(listaVehiculos, sizeof(eVehiculo*) * (tam + 1));
    if (auxLista != NULL)
    {
        listaVehiculos = auxLista;
    }
    return listaVehiculos;
}
