#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    int id;
    char nombre[20];
    float sueldo;

} eEmpleado;

eEmpleado* newEmpleado();
eEmpleado* newEmpleadoParam(int id, char* nombre, float sueldo);
int setIdEmpleado(eEmpleado* emp, int id);
int setSueldoEmpleado(eEmpleado* emp, float sueldo);
int setNombreEmpleado(eEmpleado* emp, char* nombre);
int getIdEmpleado(eEmpleado* emp, int* id);
int getSueldoEmpleado(eEmpleado* emp, float* sueldo);
int getNombreEmpleado(eEmpleado* emp, char* nombre);
int mostrarEmpleado(eEmpleado* emp);
int mostrarEmpleados(eEmpleado** emp, int tam);
eEmpleado** agrandarLista(eEmpleado** vec, int tam);
int guardarEmpleadosBinario(eEmpleado** lista, int tam, char* path);
int guardarEmpleadosCSV(eEmpleado** lista, int tam, char* path);


int main()
{
    /* En buffer estara cargado los datos del archivo .csv (ID - NOMBRE - SALARIO) */
    char buffer[3][30];
    int cant;
    int tam = 0;
    int tam2 = 0;
    eEmpleado* auxEmpleado = NULL;
    eEmpleado** lista = (eEmpleado**) malloc(sizeof(eEmpleado*));

    if(lista == NULL)
    {
        printf("NO SE PUDO ASIGNAR MEMORIA!\n");
        system("pause");
        exit(EXIT_FAILURE);
    }
    FILE* f = fopen("empleados.csv", "r");
    if(f == NULL){
        printf("No se pudo abrir el archivo!\n");
        system("pause");
        exit(EXIT_FAILURE);
    }
    /* La expresion %[^,], significa que leera todo lo que encuentre hasta la "," y luego evita leer la ","*/
    fscanf(f, "%[^,],%[^,],%[^\n]\n", buffer[0], buffer[1], buffer[2]);

    while(!feof(f))
    {
        /* Contamos las variables cargadas por fscanf */
        cant = fscanf(f, "%[^,],%[^,],%[^\n]\n", buffer[0], buffer[1], buffer[2]);
        if(cant == 3)
        {
            /* atoi = asker to integer // similar al parseInt en JS
               atof = asker to floating // similar al parseFloat en JS */
            auxEmpleado = newEmpleadoParam(atoi(buffer[0]), buffer[1], atof(buffer[2]));
            if(auxEmpleado != NULL)
            {
                *(lista + tam) = auxEmpleado;
                tam++;

                if((lista = agrandarLista(lista, tam + 1)) == NULL)
                {
                    printf("No se pudo agrandar la lista\n");
                }
            }
        } else
            {
                break;
            }
    }
    fclose(f);
    mostrarEmpleados(lista, tam);

   if(guardarEmpleadosBinario(lista, tam, "empleados.bin"))
    {
        printf("Empleados serializados con exito.\n");
    } else
        {
            printf("No se pudo serializar los empleados\n");
        }

    /*-----------LEO DESDE BINARIO---------*/
    eEmpleado** lista2 = (eEmpleado**) malloc(sizeof(eEmpleado*));
    if(lista2 == NULL)
    {
        printf("NO SE PUDO ASIGNAR MEMORIA!\n");
        system("pause");
        exit(EXIT_FAILURE);
    }
    f = fopen("empleados.bin", "rb");
    if(f == NULL){
        printf("No se pudo abrir el archivo!\n");
        system("pause");
        exit(EXIT_FAILURE);
    }

    while(!feof(f))
    {
        auxEmpleado = newEmpleado();
        if(auxEmpleado != NULL)
        {
            cant = fread(auxEmpleado, sizeof(eEmpleado), 1, f);
            if(cant == 1)
            {
                *(lista2 + tam2) = auxEmpleado;
                tam2++;
            if((lista2 = agrandarLista(lista, tam2 + 1)) == NULL)
                {
                    printf("No se pudo agrandar la lista\n");
                }
            }
        } else
            {
                break;
            }
    }
    printf("- EMPLEADOS DE LA LISTA BINARIA -\n\n");
    mostrarEmpleados(lista2, tam2);
    fclose(f);

    //------- CREAR UN ARCHIVO CSV DE EMPLEADOS

    if(guardarEmpleadosCSV(lista2,tam2, "listaempleados.csv"))
    {
        printf("Se guardaron los empleados en un archivo.csv\n");
    } else
        {
            printf("No se pudo guarda la lista CSV!\n");
        }

    free(lista);
    free(lista2);
    return 0;
}

/* CONSTRUCTOR */
eEmpleado* newEmpleado()
{
    eEmpleado* nuevo = (eEmpleado*) malloc(sizeof(eEmpleado));
    if(nuevo != NULL)
    {
        nuevo->id = 0;
        strcpy(nuevo->nombre, " ");
        nuevo->sueldo = 0;
    }
    return nuevo;
}

/* CONSTRUCTUR PARAMETRIZADO */
eEmpleado* newEmpleadoParam( int id, char* nombre, float sueldo)
{
    eEmpleado* nuevo = newEmpleado();
    if( nuevo != NULL)
    {
        if(setIdEmpleado(nuevo, id) &&
                setNombreEmpleado(nuevo, nombre)&&
                setSueldoEmpleado(nuevo, sueldo))
        {
            // printf("Empleado creado correctamente\n");
        }
        else
        {
            nuevo = NULL;
        }
    }

    return nuevo;
}

/* GETTER & SETTER FUNCTIONS */
int setIdEmpleado(eEmpleado* emp, int id)
{
    int todoOk = 0;
    if (emp != NULL && id >= 10000 && id <= 20000)
    {
        emp->id = id;
        todoOk = 1;
    }
    return todoOk;
}

int setSueldoEmpleado(eEmpleado* emp, float sueldo)
{
    int todoOk = 0;
    if (emp != NULL && sueldo > 0)
    {
        emp->sueldo = sueldo;
        todoOk = 1;
    }
    return todoOk;
}

int setNombreEmpleado(eEmpleado* emp, char* nombre)
{
    int todoOk = 0;
    if (emp != NULL && nombre != NULL && strlen(nombre) < 20)
    {
        strcpy(emp->nombre, nombre);
        todoOk = 1;
    }
    return todoOk;
}

int getIdEmpleado(eEmpleado* emp, int* id)
{
    int todoOk = 0;
    if (emp != NULL && id != NULL)
    {
        *id = emp->id;
        todoOk = 1;
    }
    return todoOk;
}

int getSueldoEmpleado(eEmpleado* emp, float* sueldo)
{
    int todoOk = 0;
    if (emp != NULL && sueldo != NULL)
    {
        *sueldo = emp->sueldo;
        todoOk = 1;
    }
    return todoOk;
}

int getNombreEmpleado(eEmpleado* emp, char* nombre)
{
    int todoOk = 0;
    if (emp != NULL && nombre != NULL)
    {
        strcpy(nombre, emp->nombre);
        todoOk = 1;
    }
    return todoOk;
}

/* MOSTRAR FUNCTIONS */
int mostrarEmpleado(eEmpleado* emp)
{
    int todoOk = 0;
    if(emp != NULL)
    {
        printf(" %d     %10s      %.2f\n", emp->id, emp->nombre, emp->sueldo);
        todoOk = 1;
    }
    return todoOk;
}

int mostrarEmpleados(eEmpleado** emp, int tam)
{
    int todoOk = 0;
    int i;
    if(emp != NULL && tam > 0)
    {
        printf("   ID         NOMBRE        SUELDO\n\n");
        for(i = 0; i < tam; i++)
        {
            mostrarEmpleado(*(emp + i));
        }
        todoOk = 1;
    }
    return todoOk;
}

eEmpleado** agrandarLista(eEmpleado** vec, int tam)
{
    eEmpleado** aux = (eEmpleado**) realloc(vec, sizeof(eEmpleado*) * tam);
    if(aux != NULL)
    {
        vec = aux;
    }
    return vec;
}

int guardarEmpleadosBinario(eEmpleado** lista, int tam, char* path)
{
    int isOk = 0;
    int cant;
    int i;
    FILE* f;
    if (lista != NULL && path != NULL && tam > 0)
    {
        f = fopen(path, "wb");
        if(f == NULL)
        {
            return isOk;
        }
        for(i = 0; i < tam; i++)
        {
            cant = fwrite(*(lista + i), sizeof(eEmpleado), 1 , f);
            if(cant < 1)
            {
                return isOk;
            }
        }
        fclose(f);
        isOk = 1;
    }
    return isOk;
}

int guardarEmpleadosCSV(eEmpleado** lista, int tam, char* path)
{
    int isOk = 0;
    int cant;
    int i;
    FILE* f;
    if (lista != NULL && path != NULL && tam > 0)
    {
        f = fopen(path, "w");
        if(f == NULL)
        {
            return isOk;
        }
        fprintf(f, "id,nombre,sueldo\n");
        for(i = 0; i < tam; i++)
        {
            cant = fprintf(f, "%d,%s,%.2f\n",(*(lista + i))->id, (*(lista + i))->nombre, (*(lista + i))->sueldo);
            if(cant < 1)
            {
                return isOk;
            }
        }
        fclose(f);
        isOk = 1;
    }
    return isOk;
}
