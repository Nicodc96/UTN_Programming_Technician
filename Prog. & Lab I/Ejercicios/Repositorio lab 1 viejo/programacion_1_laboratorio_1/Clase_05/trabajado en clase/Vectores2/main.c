#include <stdio.h>
#include <stdlib.h>

int main()
{
    int numeros[5];
    int flag = 0;
    int mayorNumero = 0;

    for (int i = 0; i < 5; i++)
    {
        printf("Ingrese un numero entero positivo: ");
        scanf("%d", &numeros[i]);
        while (numeros[i] <= 0)
        {
            printf("\nError, debe ser un numero entero y positivo: ");
            scanf("%d", &numeros[i]);
        }
    }
    for (int i = 0; i < 5; i++)
    {
        printf("%d ", numeros[i]);
    }

    for (int i = 0; i < 5; i++)
    {
        while (numeros[i] > mayorNumero || flag == 0)
        {
            mayorNumero = numeros[i];
            flag = 1;
        }
    }

    printf("\nEl mayor numero fue %d", mayorNumero);

    for (int i = 0; i < 5; i++)
    {
        if (numeros[i] == mayorNumero)
        {
            printf("\nY esta ubicado en el indice: %d", i);
        }
    }

    return 0;
}
