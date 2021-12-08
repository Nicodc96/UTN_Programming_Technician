#include <stdio.h>
#include <stdlib.h>

#define TAM 10
void mostrarNumeros(int* vectorNumeros, int tam);

int main()
{
    int numeros[TAM];

    mostrarNumeros(numeros, TAM);

    return 0;
}

void mostrarNumeros(int* vectorNumeros, int tam)
{
    int i;
    for (i = 0; i < tam; i++)
    {
        if (vectorNumeros != NULL)
        {
            printf("%d ", *(vectorNumeros+i));
        }
    }
    printf("\n");
}
