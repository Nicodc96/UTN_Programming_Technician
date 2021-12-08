#include <stdio.h>
#include <stdlib.h>
#include <ctype.h>
#include <string.h>

#define TAM 6

int contarVocal(char array[], int tamArray, char vocal);

int main()
{
    char vocales[TAM];
    char letra = 'i';
    int cantVocales;
    int i;

    for (i = 0; i < TAM; i++)
    {
        printf("Ingrese una vocal: ");
        fflush(stdin);
        scanf("%c", &vocales[i]);
    }
    printf("\n|Array Completo|\n");
    for (i = 0; i < TAM; i++)
    {
        printf("%c ", vocales[i]);
    }
    cantVocales = contarVocal(vocales, TAM, letra);
    printf("\n\nLa vocal %c aparece %d veces.", letra, cantVocales);
    return 0;
}

int contarVocal(char array[], int tamArray, char vocal)
{
    int cantidad = 0;
    int i;
    for (i = 0; i < tamArray; i++)
    {
        if (vocal == array[i])
        {
            cantidad++;
        }
    }
    return cantidad;
}
