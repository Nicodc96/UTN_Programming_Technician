#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define TAM 5
// Prototipos
void sumarVectores(int vector1[], int vector2[], int totales[], int tam);
void mostrarVectores(int vector1[], int vector2[], int totales[], int tam);
//
int main()
{
    int vec1[] = {2,1,5,4,6};
    int vec2[] = {5,7,3,7,9};
    int total[5];
    //int i;

    sumarVectores(vec1, vec2, total, TAM);
    printf("Se han sumado los vectores 1 y 2 correctamente!\n");
    system("pause");
    printf("\n");
    mostrarVectores(vec1, vec2, total, TAM);
    /*for (i = 0; i < TAM; i++)
    {
        total[i] = vec1[i] + vec2[i];
    }
    printf("Array TOTAL\n");
    for (i = 0; i < TAM; i++)
    {
        printf("%d ", total[i]);
    }
    printf("\n");*/
    return 0;
}

void sumarVectores(int vector1[], int vector2[], int totales[], int tam)
{
    int i;
    for (i = 0; i < tam; i++)
    {
        totales[i] = vector1[i] + vector2[i];
    }
}

void mostrarVectores(int vector1[], int vector2[], int totales[], int tam)
{
    int i;
    printf("Array Vector 1\n");
    for (i = 0; i < tam; i++)
    {
        printf("%d ", vector1[i]);
    }
    printf("\nArray Vector 2\n");
    for (i = 0; i < tam; i++)
    {
        printf("%d ", vector2[i]);
    }
    printf("\nArray Total\n");
    for (i = 0; i < tam; i++)
    {
        printf("%d ", totales[i]);
    }
}
