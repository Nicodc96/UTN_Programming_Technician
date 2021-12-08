#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int ejemploINT(int* pNum);
int ejemploArrayChar(char* pArray, int tamArray);

#define TAMARRAY 20
#define TAMINT 10

int main()
{
    //Asignación de espacio en memoria de tamaño INT (4 bytes)
    int* pNumero = (int*) malloc(sizeof(int)*TAMINT);
    char* pArray = (char*) malloc(sizeof(char)*TAMARRAY);
    /*if(ejemploINT(pNumero))
    {
        printf("Error! Sin memoria disponible.\n");
        exit(EXIT_FAILURE);
    }*/
    if(ejemploArrayChar(pArray, TAMARRAY))
    {
        printf("Error! Sin memoria disponible.\n");
        exit(EXIT_FAILURE);
    }
    free(pNumero);
    free(pArray);
    return EXIT_SUCCESS;
}

int ejemploINT(int* pNum)
{
    int haveError = 0;
    if (pNum == NULL)
    {
        haveError = 1;
    } else
        {
            printf("Ingrese el valor del numero a testear: ");
            scanf("%d", pNum);
            printf("La variable puntero a INT vale: %d\n\n", *(pNum +2));
        }
    return haveError;
}

int ejemploArrayChar(char* pArray, int tamArray)
{
    int haveError = 0;
    /*
        Defino un puntero del mismo tipo de dato pero de tamaño más grande
        Esto lo hago para que, al querer guardar un dato demasiado grande que desborde
        el tamaño pre-definido, no se rompa el código, sino que agranda el array principal
        al tamaño exacto de caracteres que se ingreso usando el auxArray como buffer.
    */
    char* auxArray = (char*) malloc(sizeof(char)*(strlen(pArray)*5));
    if (pArray == NULL && auxArray != NULL)
    {
        haveError = 1;
    } else
        {
            printf("Ingrese un nombre: ");
            fflush(stdin);
            scanf("%s", auxArray);
            if (strlen(auxArray) > 19)
            {
                pArray = (char*) realloc(pArray, sizeof(char)*strlen(auxArray));
                printf("Reajustando tamanio..\n");
                if (pArray == NULL)
                {
                    haveError = 1;
                }
            }
            if (!haveError)
            {
                pArray = auxArray;
                printf("El puntero a CHAR contiene el/los valor(es): %s\n\n", pArray);
            }
        }
    free(auxArray);
    return haveError;
}
