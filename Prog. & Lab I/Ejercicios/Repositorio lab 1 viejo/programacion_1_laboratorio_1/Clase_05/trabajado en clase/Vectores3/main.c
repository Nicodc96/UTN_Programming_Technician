#include <stdio.h>
#include <stdlib.h>

int main()
{
    char sexos[5];
    int cantF = 0;
    int cantM = 0;

    for (int i = 0; i < 5; i++)
    {
        printf("Ingrese un sexo f o m: ");
        fflush(stdin);
        scanf("%c", &sexos[i]);
        while (sexos[i] != 'm' && sexos[i] != 'f')
        {
            printf("Sexo invalido. Ingrese f o m: ");
            fflush(stdin);
            scanf("%c", &sexos[i]);
        }
    }
    for (int i = 0; i < 5; i++)
    {
        if (sexos[i] == 'm')
        {
            cantM++;
        } else
            {
                cantF++;
            }
    }
    printf("Cantidad de Sexos F: %d\nCantidad de Sexos M: %d", cantF, cantM);
    return 0;
}
