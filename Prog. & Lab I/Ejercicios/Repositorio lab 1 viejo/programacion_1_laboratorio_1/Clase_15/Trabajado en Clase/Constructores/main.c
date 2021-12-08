#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    int dia;
    int mes;
    int anio;

} eDate;

typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float sueldo;
    eDate fIngreso;

} eEmployee;

eEmployee* new_employee();
int show_employee(eEmployee* emp);
eEmployee* newEmployeeParam(int leg, char* name, char sex, float salary, eDate date);
int addEmployeeToArray(eEmployee* list, int* len, eEmployee* emp);
int show_employees(eEmployee* vec, int len);

int main()
{
    eEmployee* pEmp1;
    eEmployee* pEmp2;
    eEmployee* pEmp3;
    eEmployee* pEmp4;
    eEmployee* listEmployee;
    int len = 0;

    listEmployee = (eEmployee*) malloc(sizeof(eEmployee));

    if(listEmployee == NULL)
    {
        printf("No se ha conseguido el espacio necesario.\n");
        exit(EXIT_FAILURE);
    }

    /* Nuevo empleado Hardcodeado */
    pEmp1 = newEmployeeParam(1234, "Jorge", 'm', 25000, (eDate) {12,5,2006});
    pEmp2 = newEmployeeParam(1111, "Pedro", 'm', 33000, (eDate) {15,12,2015});
    pEmp3 = newEmployeeParam(1563, "Lucia", 'f', 17000, (eDate) {22,2,2005});
    pEmp4 = newEmployeeParam(1711, "Enrique", 'm', 31000, (eDate) {6,6,2010});

    /* Agrego el empleado a la lista */
    *(listEmployee + len) = *pEmp1;
    *(listEmployee + len) = *pEmp2;
    *(listEmployee + len) = *pEmp3;
    *(listEmployee + len) = *pEmp4;

    /*if(addEmployeeToArray(listEmployee, &len, pEmp1)){
        printf("Empleados ingresado exitosamente.\n");
    } else {
        printf("No se pudo agregar el empleado.\n");
    }*/

    (eEmployee*) listEmployee = addEmployeeToArray(listEmployee, &len, pEmp1);
    (eEmployee*) listEmployee = addEmployeeToArray(listEmployee, &len, pEmp2);
    (eEmployee*) listEmployee = addEmployeeToArray(listEmployee, &len, pEmp3);
    (eEmployee*) listEmployee = addEmployeeToArray(listEmployee, &len, pEmp4);


    /* Mostramos el array de empleados en el indice 0 */
    show_employee(listEmployee);


    free(listEmployee);
    return EXIT_SUCCESS;
}

eEmployee* new_employee()
{
    eEmployee* p;
    p = (eEmployee*) malloc(sizeof(eEmployee));
    if (p != NULL)
    {
        p->legajo = 0;
        strcpy(p->nombre, "Undefined");
        p->sexo = '-';
        p->sueldo = 0;
        p->fIngreso= (eDate) {1,1,1990};
    }
    return p;
}
/* Funcion que muestra un empleado */
int show_employee(eEmployee* emp)
{
    int isOk = 0;
    if(emp != NULL)
    {
        printf(" %d  %s  %c  %.2f  %02d/%02d/%d\n",
               emp->legajo,
               emp->nombre,
               emp->sexo,
               emp->sueldo,
               emp->fIngreso.dia,
               emp->fIngreso.mes,
               emp->fIngreso.anio);
        isOk = 1;
    }
    else
    {
        printf("ERROR!");
        exit(EXIT_FAILURE);
    }

    return isOk;
}

eEmployee* newEmployeeParam(int leg, char* name, char sex, float salary, eDate date)
{
    eEmployee* newEmployee;
    newEmployee = new_employee();

    if(newEmployee != NULL)
    {
        newEmployee->legajo = leg;
        strcpy(newEmployee->nombre, name);
        newEmployee->sexo = sex;
        newEmployee->sueldo = salary;
        newEmployee->fIngreso = date;
    }

    return newEmployee;
}

/* Funcion que implementa un empleado nuevo al array de empleados
   y pide un nuevo espacio para el siguiente empleado, cuando no
   es posible conseguir mas espacio, la funcion devuelve NULL */
int addEmployeeToArray(eEmployee* list, int* len, eEmployee* emp)
{
    eEmployee* aux;

    if (list != NULL && emp != NULL && len != NULL)
    {
        *(list + *len) = *emp;

        aux = realloc(list, (*len + 2) * (sizeof(eEmployee)));
        if (aux != NULL)
        {
            list = aux;
            (*len)++;
        }
    }
    return (eEmployee*) list;
}

int show_employees(eEmployee* vec, int len)
{
    int isOk = 0;
    int i;
    if (vec != NULL)
    {
        for(i = 0; i < len; i++)
        {
            show_employee(vec + i);
        }
        isOk = 1;
    }
    return isOk;
}
