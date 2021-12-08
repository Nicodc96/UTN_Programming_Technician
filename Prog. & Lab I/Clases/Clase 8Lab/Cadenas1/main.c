#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char nombre1[5];
    //char nombre2[20];

    printf("Ingrese su nombre: ");
    fflush(stdin);
    gets(nombre1);

    while(strlen(nombre1) > 5)
    {
        printf("Demasiados caracteres! Reingrese!\n");
        printf("Ingrese su nombre: ");
        fflush(stdin);
        gets(nombre1);
    }

    printf("Nombre1 vale %s\n", nombre1);
    //printf("Nombre2 vale %s\n", nombre2);
    return 0;
}
