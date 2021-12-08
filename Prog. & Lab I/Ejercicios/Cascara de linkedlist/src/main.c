/*
    utest example : Unit test examples.
    Copyright (C) <2018>  <Mauricio Davila>

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../testing/inc/main_test.h"
#include "../inc/LinkedList.h"

typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float sueldo;
}eEmpleado;

void employee_showInfo(eEmpleado* pEmp);
int filtradoPorSexo(void* pEmp);

int main(void)
{
        startTesting(1);  // ll_newLinkedList
        startTesting(2);  // ll_len
        startTesting(3);  // getNode - test_getNode
        startTesting(4);  // addNode - test_addNode
        startTesting(5);  // ll_add
        startTesting(6);  // ll_get
        startTesting(7);  // ll_set
        startTesting(8);  // ll_remove
        startTesting(9);  // ll_clear
        startTesting(10); // ll_deleteLinkedList
        startTesting(11); // ll_indexOf
        startTesting(12); // ll_isEmpty
        startTesting(13); // ll_push
        startTesting(14); // ll_pop
        startTesting(15); // ll_contains
        startTesting(16); // ll_containsAll
        startTesting(17); // ll_subList
        startTesting(18); // ll_clone
        startTesting(19); // ll_sort

        /*// ------------------------------------------------------ //
        LinkedList* nuevaLista = ll_newLinkedList();
        eEmpleado* auxEmp = NULL;
        int i;

        eEmpleado emp1 = {7000, "Juan", 'm', 15540};
        eEmpleado emp2 = {7001, "Lucia", 'f', 25000};
        eEmpleado emp3 = {7002, "Liliana", 'f', 19130};
        eEmpleado emp4 = {7003, "Pedro", 'm', 14575};
        eEmpleado emp5 = {7004, "Christian", 'm', 21520};
        eEmpleado emp6 = {7005, "Nicolas", 'm', 15775};
        eEmpleado emp7 = {7006, "Alejandra", 'f', 23580};
        eEmpleado emp8 = {7007, "Julia", 'f', 20000};
        eEmpleado emp9 = {7008, "Roberto", 'm', 15620};
        eEmpleado emp10 = {7009, "Francisco", 'm', 17900};

        ll_add(nuevaLista, &emp1);
        ll_add(nuevaLista, &emp2);
        ll_add(nuevaLista, &emp3);
        ll_add(nuevaLista, &emp4);
        ll_add(nuevaLista, &emp5);
        ll_add(nuevaLista, &emp6);
        ll_add(nuevaLista, &emp7);
        ll_add(nuevaLista, &emp8);
        ll_add(nuevaLista, &emp9);
        ll_add(nuevaLista, &emp10);

        printf("---------- LISTA PRINCIPAL ----------\n");
        printf(" LEGAJO             NOMBRE   SEXO    SUELDO\n\n");
        for (i = 0; i < ll_len(nuevaLista); i++)
        {
            auxEmp = ll_get(nuevaLista, i);
            employee_showInfo(auxEmp);
        }
        // ----------- Asigno nueva lista para filtrar por SEXO
        LinkedList* lista2 = ll_filter(nuevaLista, filtradoPorSexo);

        printf("\n\n---------- LISTA FILTRADA POR SEXO ----------\n");
        printf(" LEGAJO             NOMBRE   SEXO    SUELDO\n\n");
        for (i = 0; i < ll_len(lista2); i++)
        {
            auxEmp = ll_get(lista2, i);
            employee_showInfo(auxEmp);
        }*/
    return 0;
}

void employee_showInfo(eEmpleado* pEmp)
{
    if(pEmp != NULL)
    {
        printf("  %4d  %20s   %c    %.2f\n", pEmp->legajo, pEmp->nombre, pEmp->sexo, pEmp->sueldo);
    }
}

int filtradoPorSexo(void* pEmp)
{
    int isOk = 0;
    eEmpleado* auxEmpleado = NULL;
    if (pEmp != NULL)
    {
        auxEmpleado = (eEmpleado*) pEmp;
        if (auxEmpleado->sexo == 'm')
        {
            isOk = 1;
        }
    }
    return isOk;
}
