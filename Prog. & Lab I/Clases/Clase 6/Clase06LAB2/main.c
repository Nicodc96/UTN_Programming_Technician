#include <stdio.h>
#include <stdlib.h>

#define TAM 5
int main()
{
    int numeros[TAM];
    int numeroMayor = 0;
    //int indiceMayor = 0;
    int i;

    for (i = 0; i < TAM; i++)
    {
        printf("Ingrese el numero %d: ", i+1);
        scanf("%d", &numeros[i]);
    }
    for (i = 0; i < TAM; i++)
    {
        if (numeros[i] > numeroMayor)
        {
            numeroMayor = numeros[i];
            //indiceMayor = i;
        }
    }
    printf("\nEl mayor numero del array es %d y se encontro en la/s posicion/es: ", numeroMayor);
    for (i = 0; i < TAM; i++)
    {
        if (numeros[i] == numeroMayor)
        {
            printf("%d ", i+1);
        }
    }
    return 0;
}
