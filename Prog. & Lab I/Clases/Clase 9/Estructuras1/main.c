#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    char nombre[20];
    char sexo;
    int legajo;
    int notaP1;
    int notaP2;
    float promedio;

}eAlumno;

void mostrarAlumno(eAlumno alumnoX);
void mostrarAlumnos(eAlumno arrayAlum[], int len);
void ordenarPorSexoPromedio(eAlumno arrayAlum[], int len);

#define CANTA 5

int main()
{
    eAlumno arrayAlumnos[CANTA] = {{"Juan", 'm', 100, 5, 10, 7.5},
    {"Maria", 'f', 101, 1, 8, 4.5},
    {"Pedro", 'm', 102, 4, 8, 6},
    {"Alberto", 'm', 103, 10, 6, 8},
    {"Julieta", 'f', 104, 7, 4, 5.5}};
    /*int i;

    printf("----Alumnos a ingresar: %d----\n\n", CANTA);
    for (i = 0; i < CANTA; i++)
    {
        printf("Ingrese el Nombre del Alumno %d: ", i+1);
        fflush(stdin);
        scanf("%s", arrayAlumnos[i].nombre);
        while(strlen(arrayAlumnos[i].nombre)>20)
        {
            printf("ERROR! Nombre demasiado largo! Reingrese Nombre del Alumno %d: ", i+1);
            fflush(stdin);
            scanf("%s", arrayAlumnos[i].nombre);
        }
        printf("Ingrese el Sexo del Alumno %d ('f' o 'm'): ", i+1);
        fflush(stdin);
        scanf("%c", &arrayAlumnos[i].sexo);
        while(arrayAlumnos[i].sexo != 'f' && arrayAlumnos[i].sexo != 'm')
        {
            printf("ERROR! Sexo incorrecto! Reingrese Sexo del Alumno %d ('f' o 'm'): ", i+1);
            fflush(stdin);
            scanf("%c", &arrayAlumnos[i].sexo);
        }
        printf("Ingrese el Legajo del Alumno %d (Min 100-Max 999): ", i+1);
        fflush(stdin);
        scanf("%d", &arrayAlumnos[i].legajo);
        while(arrayAlumnos[i].legajo < 100 || arrayAlumnos[i].legajo > 999)
        {
            printf("ERROR! Legajo incorrecto! Reingrese Legajo del Alumno %d (Min 100-Max 999): ", i+1);
            fflush(stdin);
            scanf("%d", &arrayAlumnos[i].legajo);
        }
        printf("Ingrese la nota del primer parcial del Alumno %d (0-10): ", i+1);
        fflush(stdin);
        scanf("%d", &arrayAlumnos[i].notaP1);
        while(arrayAlumnos[i].notaP1 < 0 || arrayAlumnos[i].notaP1 > 10)
        {
            printf("ERROR! Nota incorrecta! Reingrese nota del primer parcial del Alumno %d (0-10): ", i+1);
            fflush(stdin);
            scanf("%d", &arrayAlumnos[i].notaP1);
        }
        printf("Ingrese la nota del segundo parcial del Alumno %d (0-10): ", i+1);
        fflush(stdin);
        scanf("%d", &arrayAlumnos[i].notaP2);
        while(arrayAlumnos[i].notaP2 < 0 || arrayAlumnos[i].notaP2 > 10)
        {
            printf("ERROR! Nota incorrecta! Reingrese nota del segundo parcial del Alumno %d (0-10): ", i+1);
            fflush(stdin);
            scanf("%d", &arrayAlumnos[i].notaP2);
        }
        arrayAlumnos[i].promedio = (float) (arrayAlumnos[i].notaP1 + arrayAlumnos[i].notaP2) / 2;
    }*/
    printf("\n------ Array de Alumnos ------\n");
    mostrarAlumnos(arrayAlumnos, CANTA);
    printf("\n------ Array de Alumnos Ordenados por Sexo y Promedio ------\n");
    ordenarPorSexoPromedio(arrayAlumnos, CANTA);
    mostrarAlumnos(arrayAlumnos, CANTA);

    return 0;
}

void mostrarAlumno(eAlumno alumnoX)
{
    printf("%10s     %c     %d       %2d         %2d       %.1f\n", alumnoX.nombre, alumnoX.sexo, alumnoX.legajo, alumnoX.notaP1, alumnoX.notaP2, alumnoX.promedio);
}

void mostrarAlumnos(eAlumno arrayAlum[], int len)
{
    int i;
    printf("    NOMBRE   SEXO   LEGAJO   NOTA 1P   NOTA 2P   PROMEDIO\n");
    for (i = 0; i < len; i++)
    {
        mostrarAlumno(arrayAlum[i]);
    }
}

void ordenarPorSexoPromedio(eAlumno arrayAlum[], int len)
{
    int i, j;
    eAlumno auxAlumno;
    for (i = 0; i < len-1; i++)
    {
        for (j = i+1; j < len; j++)
        {
            if (arrayAlum[i].sexo > arrayAlum[j].sexo || (arrayAlum[i].sexo == arrayAlum[j].sexo && arrayAlum[i].promedio < arrayAlum[j].promedio))
            {
                auxAlumno = arrayAlum[i];
                arrayAlum[i] = arrayAlum[j];
                arrayAlum[j] = auxAlumno;
            }
        }
    }
}
