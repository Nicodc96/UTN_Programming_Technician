#include <stdio.h>
#include <stdlib.h>
#include <conio.h>
#include "ABM.h"

#define TAM 2

int main()
{
    eAlumno lista[TAM];
    char salir = 'n';

    startAlumnos(lista, TAM);

    do{
        switch(menu()){
    case 1:
        highAlumno(lista, TAM);
        break;
    case 2:
        lowAlumno(lista, TAM);
        break;
    case 3:
        modifyAlumno(lista, TAM);
        break;
    case 4:
        mostrarAlumnos(lista, TAM);
        break;
    case 5:
        printf("-----ORDENAR ALUMNO-----\n");
        break;
    case 6:
        printf("-----INFORMES-----\n");
        break;
    case 7:
        printf("Confirma salida?");
        printf("\n\n");
        fflush(stdin);
        salir = getch();
        break;
    default:
        printf("Opcion Invalida.\n");
        }
    system("pause");
    }while(salir == 'n');

      return 0;
}
