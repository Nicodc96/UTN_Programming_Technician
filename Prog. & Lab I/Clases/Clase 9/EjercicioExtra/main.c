#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

int checkMaxString(char* str1, int len);
void sortName(char* str1, char* str2, char* strMaster);

#define TAMSTR 20

int main()
{
    char nombre[TAMSTR];
    char apellido[TAMSTR];
    char nombreCompleto[50];

    /* Pedir nombre y apellido, y mostrar
        primero el apellido con mayuscula en el primer caracter
        seguido de una coma, y un espacio y el nombre con la misma condicion que
        el apellido.
    */
    printf("Ingrese un nombre (Max 20 caracteres): ");
    fflush(stdin);
    scanf("%s", nombre);
    while(!checkMaxString(nombre, TAMSTR))
    {
        printf("Error! Nombre demasiado largo, reingrese: ");
        fflush(stdin);
        scanf("%s", nombre);
    }
    printf("Ingrese un apellido (Max 20 caracteres): ");
    fflush(stdin);
    scanf("%s", apellido);
    while(!checkMaxString(apellido, TAMSTR))
    {
        printf("Error! Apellido demasiado largo, reingrese: ");
        fflush(stdin);
        scanf("%s", apellido);
    }
    sortName(nombre, apellido, nombreCompleto);
    printf("\nNombre completo: %s\n", nombreCompleto);
    return 0;
}

int checkMaxString(char* str1, int len)
{
    int reply = 1;
    if (strlen(str1) > len)
    {
        reply = 0;
    }
    return reply;
}

void sortName(char* str1, char* str2, char* strMaster)
{
    strlwr(str1);
    strlwr(str2);
    str1[0] = toupper(str1[0]);
    str2[0] = toupper(str2[0]);
    strcat(strMaster, str2);
    strcat(strMaster, ", ");
    strcat(strMaster, str1);
}
