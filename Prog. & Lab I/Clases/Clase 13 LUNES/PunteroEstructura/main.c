#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    int id;
    char nombre[20];
    float sueldo;
    char sexo;
}eEmpleado;

void mostrarEmpleado(eEmpleado* unEmpleado);
void cargarEmpleado(eEmpleado* pEmpleado);

int main()
{
    eEmpleado* newEmpleado = malloc(sizeof(eEmpleado));
    /*newEmpleado.id = 300;
    strcpy(newEmpleado.nombre, "Juan");
    newEmpleado.sueldo = 53146.43;
    newEmpleado.sexo = 'm';*/
    cargarEmpleado(newEmpleado);
    mostrarEmpleado(newEmpleado);

    free(newEmpleado);
    return 0;
}

void mostrarEmpleado(eEmpleado* unEmpleado)
{
    if (unEmpleado != NULL)
    {
        printf("ID del Empleado: %d\nNombre del Empleado: %s\nSueldo del Empleado: %.2f\nSexo del empleado: %c\n\n", unEmpleado->id, unEmpleado->nombre, unEmpleado->sueldo, unEmpleado->sexo);
    }
}

void cargarEmpleado(eEmpleado* pEmpleado)
{
    if (pEmpleado != NULL)
    {
        printf("Ingrese el nombre del Empleado: ");
        fflush(stdin);
        gets(pEmpleado->nombre);
        while(strlen(pEmpleado->nombre) > 19)
        {
            printf("Nombre ingresado demasiado largo!\n");
            printf("Reingrese: ");
            fflush(stdin);
            gets(pEmpleado->nombre);
        }
        printf("Ingrese el ID del empleado: ");
        fflush(stdin);
        scanf("%d", &pEmpleado->id);
        printf("Ingrese el sexo del emplaedo: ");
        fflush(stdin);
        scanf("%c", &pEmpleado->sexo);
        while(pEmpleado->sexo != 'm' && pEmpleado->sexo != 'f')
        {
            printf("Sexo incorrecto! Reingrese (m/f): ");
            fflush(stdin);
            scanf("%c", &pEmpleado->sexo);
        }
        printf("Ingrese el sueldo del empleado: ");
        fflush(stdin);
        scanf("%f", &pEmpleado->sueldo);
    }
}
