#include <stdio.h>
#include <stdlib.h>

typedef struct
{
    int id;
    char nombre[20];
    float sueldo;

}eEmpleado;

int mostrarEmpleado(eEmpleado* emp);

int main()
{
    eEmpleado uno = {1234, "Julia", 25000};

    mostrarEmpleado(&uno);
    /*
    FILE* f = fopen("data.bin", "wb");
    if(f == NULL){
        exit(1); // Salida rapida
    }
    fwrite(&uno, sizeof(eEmpleado), 1, f);

    fclose(f);*/
    int cant;
    eEmpleado dos = {1234, "Julia", 25000};

    FILE* f = fopen("data.bin", "rb");
    if(f == NULL){
        exit(1);
    }
    cant = fread(&dos, sizeof(eEmpleado), 1, f);
    if(cant == 1){
        printf("Archivo leido correctamente\n");
    } else
        {
            printf("Problemas para leer el archivo!\n");
        }
    mostrarEmpleado(&dos);



    return 0;
}

int mostrarEmpleado(eEmpleado* emp)
{
    int todoOk = 0;
    if(emp != NULL)
    {
        printf(" %d     %s      %.2f\n", emp->id, emp->nombre, emp->sueldo);
        todoOk = 1;
    }
    return todoOk;
}
