#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>

#define TAM 10

int main()
{
    int numeros[TAM] = {0};
    int pos = 0;
    //int numAux = 0;
    int i;
    char resp = 'n';

    do
    {
        printf("Ingrese la posicion donde ingresar el numero (Max: 10): ");
        scanf("%d", &pos);
        while (pos < 1 || pos > TAM)
        {
            printf("Posicion invalida! Reingrese (Max: 10): ");
            scanf("%d", &pos);
        }
        printf("\nIngrese el numero a ingresar: ");
        scanf("%d", &numeros[pos-1]);

        /*for(i = 0; i < TAM; i++)
        {
            numeros[pos-1] = numAux;
        }*/
        printf("Realizado. Continuar? (y/n): ");
        fflush(stdin);
        resp = tolower(getchar());
    }while(resp != 'n');

    printf("\n\n|Array Completo|\n");
    for(i = 0; i < TAM; i++)
    {
        printf("%d ", numeros[i]);
    }

    return 0;
}
