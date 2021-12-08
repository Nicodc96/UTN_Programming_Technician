#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int pedirNumeros(int arrayNumeros[], int* intentos);
int chequearNumeroEnArray(int arrayNumeros[], int checkNumero);
void ordenarArray(int arrayNumeros[]);
int mostrarPares(int arrayNumeros[], int indice);

int main()
{
    int numeros[10];
    int i, auxNum, j;
    int intentos = 3;
    int* pIntentos = &intentos;

    for(i = 0; i < 10; i++)
    {
        auxNum = pedirNumeros(numeros, pIntentos);
        if(auxNum == -1)
        {
            for(j = 0; j < 10; j++)
            {
                numeros[j] = 0;
            }
            break;
        }
        if(auxNum != 0)
        {
            numeros[i] = auxNum;
        } else if (!auxNum)
            {
                numeros[i] = 0;
            }
    }
    system("cls");
    printf("--- Numeros ingresados ---\n\n");
    for(i = 0; i < 10; i++)
    {
        printf("Numero %d: %d\n", i+1, numeros[i]);
    }
    printf("\n--- Numeros pares del Array ---\n\n");
    for(i = 0; i < 10; i++)
    {
        if (mostrarPares(numeros, i))
        {
            printf("  %2d\n", numeros[i]);
        }
    }
    printf("\n--- Array ordenado de manera ASCENDENTE---\n\n");
    ordenarArray(numeros);
    for(i = 0; i < 10; i++)
    {
        printf("Numero %d: %d\n", i+1, numeros[i]);
    }
    return 0;
}

int pedirNumeros(int arrayNumeros[], int* intentos)
{
    int auxNumero;
    int isOk = 0;
    int checkNumero;

    printf("Ingrese un numero: ");
    scanf("%d", &auxNumero);
    checkNumero = chequearNumeroEnArray(arrayNumeros, auxNumero);
    while(checkNumero == -1)
    {
        (*intentos)--;
        if(*intentos != 0)
        {
            printf("- Intentos restantes: %d -\n", *intentos);
            printf("Ingrese otro numero: ");
            scanf("%d", &auxNumero);
            checkNumero = chequearNumeroEnArray(arrayNumeros, auxNumero);
        } else
            {
                break;
            }
    }
    if (checkNumero != -1)
    {
        isOk = auxNumero;
    }
    if (*intentos == 0)
    {
        printf("- Se han acabado los intentos -\n\n");
        system("pause");
        isOk = -1;
    }
    return isOk;
}

int chequearNumeroEnArray(int arrayNumeros[], int checkNumero)
{
    int i, isOk = 0;
    for (i = 0; i < 10; i++)
    {
        if(arrayNumeros[i] == checkNumero)
        {
            printf("El numero ingresado ya se encuentra en el array!\n");
            isOk = -1;
            break;
        }
    }
    return isOk;
}

void ordenarArray(int arrayNumeros[])
{
    int i, j, auxInt;
    for(i = 0; i < 9; i++)
    {
        for(j = i + 1; j < 10; j++)
        {
            if(arrayNumeros[i] > arrayNumeros[j])
            {
                auxInt = arrayNumeros[i];
                arrayNumeros[i] = arrayNumeros[j];
                arrayNumeros[j] = auxInt;
            }
        }

    }
}

int mostrarPares(int arrayNumeros[], int indice)
{
    int i, isOk = 0;
    for (i = indice; i < 10; i++)
    {
        if (arrayNumeros[indice] % 2 == 0)
        {
            isOk = 1;
            break;
        }
    }

    return isOk;
}
