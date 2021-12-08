#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define CANTNAME 5
#define MAXCHARS 20

void showMatrix(char matrix[][MAXCHARS], int len);
void sortAlphabetic(char matrix[][MAXCHARS], int len);

int main()
{
    char nombres[CANTNAME][MAXCHARS] = {"Juan", "Maria", "Pedro", "Nicolas", "Luciana"};

    /*for (i = 0; i < CANTNAME; i++)
    {
        printf("Ingrese el nombre %d: ", i+1);
        fflush(stdin);
        gets(nombres[i]);
    }*/
    printf("-----Matriz Nombres\n");
    showMatrix(nombres, CANTNAME);
    printf("\n-----Matriz ordenada A-Z\n");
    sortAlphabetic(nombres, CANTNAME);
    showMatrix(nombres, CANTNAME);

    return EXIT_SUCCESS;
}

void showMatrix(char matrix[][MAXCHARS], int len)
{
    int i;
    for (i = 0; i < len; i++)
    {
        printf("%s\n", matrix[i]);
    }
}

void sortAlphabetic(char matrix[][MAXCHARS], int len)
{
    int i, j;
    char auxStr[20];

    for(i = 0; i < len-1; i++)
    {
        for(j = i + 1; j < len; j++)
        {
            if (strcmp(matrix[i],matrix[j])==1)
            {
                strcpy(auxStr, matrix[i]);
                strcpy(matrix[i], matrix[j]);
                strcpy(matrix[j], auxStr);
            }
        }
    }
}
