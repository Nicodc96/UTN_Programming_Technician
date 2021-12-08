#include <stdio.h>
#include <stdlib.h>

void duplicarValor(int* numeroEjemplo);

int main()
{
    int x = 20;
    int* puntero;

    puntero = &x;

    duplicarValor(puntero);

    printf("%d", *puntero);
    return 0;
}

void duplicarValor(int* numeroEjemplo)
{
    *numeroEjemplo = *numeroEjemplo * 2;
}
