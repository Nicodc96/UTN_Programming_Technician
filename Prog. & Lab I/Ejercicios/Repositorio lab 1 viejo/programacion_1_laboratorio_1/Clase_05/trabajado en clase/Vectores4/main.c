#include <stdio.h>
#include <stdlib.h>

int buscarNumero (int num, int vec[], int tam);

int main()
{
    int numeros[] = {2,4,3,8,6,5,9,1,8,23};
    int esta;

    esta = buscarNumero(3, numeros, 10);

    if (esta == 1)
    {
        printf("Esta.\n");
    } else
        {
            printf("No esta.\n");
        }

    return 0;
}

int buscarNumero (int num, int vec[], int tam)
{
    int respuesta = 0;

    for (int i = 0; i < tam; i++)
    {
        if (num == vec[i])
        {
            respuesta = 1;
        }
    }

    return respuesta;
}
