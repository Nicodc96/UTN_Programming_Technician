#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float sueldo;
    int isEmpty;
}eEmpleado;

#define TAMEMP 100

eEmpleado* generateEmployees(int tamEmp);
void showEmployee(eEmpleado* pEmp);
void showEmployees(eEmpleado* pEmp, int tamEmp);
void initEmployees(eEmpleado* pEmp, int tamEmp);

int main()
{
    eEmpleado* ArrayEmployee = generateEmployees(TAMEMP);
    if(ArrayEmployee == NULL)
    {
        printf("Error! Sin memoria disponible!\n");
        exit(EXIT_FAILURE);
    }
    initEmployees(ArrayEmployee, TAMEMP);

    /*
        Ahora voy a definir un empleado dentro del array y lo haré de la siguiente manera
        Esta manera funciona porque definiendo el empleado en el indice 0
    */
    ArrayEmployee->legajo = 1234;
    strcpy(ArrayEmployee->nombre, "Juan");
    ArrayEmployee->sexo = 'm';
    ArrayEmployee->sueldo = 50000;
    ArrayEmployee->isEmpty = 0;

    showEmployees(ArrayEmployee, TAMEMP);

    free(ArrayEmployee);
    return EXIT_SUCCESS;
}

eEmpleado* generateEmployees(int tamEmp)
{
    eEmpleado* auxEmp = (eEmpleado*) malloc(sizeof(eEmpleado)*tamEmp);
    if(auxEmp == NULL)
    {
        printf("No se ha podido generar espacio en memoria para los empleados!\n");
    }
    return auxEmp;
}

void initEmployees(eEmpleado* pEmp, int tamEmp)
{
    int i;
    if (pEmp != NULL)
    {
        for (i = 0; i < tamEmp; i++)
        {
            (pEmp + i)->isEmpty = 1;
        }
    }
}

void showEmployee(eEmpleado* pEmp)
{
    if (pEmp != NULL)
    {
        printf("  %4d   %20s         %c       %.2f\n", pEmp->legajo, pEmp->nombre, pEmp->sexo, pEmp->sueldo);
    }
}

void showEmployees(eEmpleado* pEmp, int tamEmp)
{
    int i;
    if (pEmp != NULL)
    {
        printf("------------- NOMINA DE EMPLEADOS -------------\n\n");
        printf(" LEGAJO                 NOMBRE      SEXO      SUELDO\n");
        for (i = 0; i < tamEmp; i++)
        {
            if ((pEmp+i)->isEmpty == 0)
            {
                showEmployee((pEmp+i));
            }
        }
    }
}
