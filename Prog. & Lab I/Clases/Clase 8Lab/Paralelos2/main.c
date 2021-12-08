#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define TAM 5
// Prototipos
void calcularPromedio(int nota1[], int nota2[], float promedio[], int tam);
void mostrarAlumnos(int leg[], int nota1[], int nota2[], float promedio[], char sex[], char names[][20], int tam);
void ordenarArraysPorPromedio(int leg[], int nota1[], int nota2[], float promedio[], char sex[], char names[][20], int tam);

void burbujeo(int leg[], int nota1[], int nota2[], float promedio[], char sex[], int tam, char namess[][20], int i, int j);
//

int main()
{
    int legajo[TAM] = {100, 101, 102, 103, 104};
    int nota1p[TAM] = {5, 8, 10, 9, 4};
    int nota2p[TAM] = {8, 7, 7, 9, 6};
    float promedioP[TAM];
    char sexos[TAM] = {'m', 'f', 'f', 'm', 'f'};
    char nombres[TAM][20] = {"Juan", "Maria", "Alejandra", "Pedro", "Eugenia"};
    //int i;

    /*for(i = 0; i < TAM; i++)
    {
        printf("--- Alumno %d ---\n", i+1);
        printf("Ingrese un legajo (100 - 999): ");
        fflush(stdin);
        scanf("%d", &legajo[i]);
        while(legajo[i] < 100 || legajo[i] > 999)
        {
            printf("ERROR! Reingrese un legajo (100 - 999): ");
            fflush(stdin);
            scanf("%d", &legajo[i]);
        }

        printf("Ingrese el sexo del alumno ('f' o 'm'): ");
        fflush(stdin);
        scanf("%c", &sexos[i]);
        while(sexos[i] != 'f' && sexos[i] != 'm')
        {
            printf("ERROR. Reingrese el sexo del alumno ('f' o 'm'): ");
            fflush(stdin);
            scanf("%c", &sexos[i]);
        }

        printf("Ingrese nota del primer parcial (1-10): ");
        fflush(stdin);
        scanf("%d", &nota1p[i]);
        while(nota1p[i] < 1 || nota1p[i] > 10)
        {
            printf("ERROR. Reingrese nota del primer parcial (1-10): ");
            fflush(stdin);
            scanf("%d", &nota1p[i]);
        }

        printf("Ingrese nota del segundo parcial (1-10): ");
        fflush(stdin);
        scanf("%d", &nota2p[i]);
        while(nota2p[i] < 1 || nota2p[i] > 10)
        {
            printf("ERROR. Reingrese nota del segundo parcial (1-10): ");
            fflush(stdin);
            scanf("%d", &nota2p[i]);
        }
    }*/
    calcularPromedio(nota1p, nota2p, promedioP, TAM);
    printf("Array Normal\n");
    mostrarAlumnos(legajo, nota1p, nota2p, promedioP, sexos, nombres, TAM);
    printf("\n\nArray Ordenado por Promedios Ascendente\n");
    ordenarArraysPorPromedio(legajo, nota1p, nota2p, promedioP, sexos, nombres, TAM);
    mostrarAlumnos(legajo, nota1p, nota2p, promedioP, sexos, nombres, TAM);
    return 0;
}

void calcularPromedio(int nota1[], int nota2[], float promedio[], int tam)
{
    int i;
    for (i = 0; i < tam; i++)
    {
        promedio[i] = (float) (nota1[i] + nota2[i]) / 2;
    }
}

void mostrarAlumnos(int leg[], int nota1[], int nota2[], float promedio[], char sex[], char names[][20], int tam)
{
    int i;
    printf("------------- Alumnos -------------\n");
    printf("    Nombre  Legajo      Nota 1P      Nota 2P      Promedio      Sexo\n");
    for(i = 0; i < tam; i++)
    {
        printf("%10s   %d          %2d           %2d            %.1f          %c\n",names[i], leg[i], nota1[i], nota2[i], promedio[i], sex[i]);
    }
}

void ordenarArraysPorPromedio(int leg[], int nota1[], int nota2[], float promedio[], char sex[], char names[][20], int tam)
{
    int i, j;
    for (i = 0; i < tam - 1; i++)
    {
        for (j = i + 1; j < tam; j++)
        {
            if (sex[i] > sex[j])
            {
                burbujeo(leg, nota1, nota2, promedio, sex, tam, names, i, j);
            } else if(sex[i] == sex[j] && promedio[i] < promedio[j])
            {
                burbujeo(leg, nota1, nota2, promedio, sex, tam, names, i, j);
            }
        }
    }
}

void burbujeo(int leg[], int nota1[], int nota2[], float promedio[], char sex[], int tam, char namess[][20], int i, int j)
{
    int auxInt;
    float auxFloat;
    char auxChar;
    char auxStr[20];

    strcpy(auxStr, namess[i]);
    strcpy(namess[i], namess[j]);
    strcpy(namess[j], auxStr);

    auxInt = leg[i];
    leg[i] = leg[j];
    leg[j] = auxInt;

    auxInt = nota1[i];
    nota1[i] = nota1[j];
    nota1[j] = auxInt;

    auxInt = nota2[i];
    nota2[i] = nota2[j];
    nota2[j] = auxInt;

    auxFloat = promedio[i];
    promedio[i] = promedio[j];
    promedio[j] = auxFloat;

    auxChar = sex[i];
    sex[i] = sex[j];
    sex[j] = auxChar;
}
