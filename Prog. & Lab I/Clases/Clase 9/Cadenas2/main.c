#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <ctype.h>

void toMayus(char vec[]);

int main()
{
    char cadena1[20] = "maria";
    char cadena2[20];

    toMayus(cadena1);

    printf("%s \n", cadena1);

    return 0;
}

void toMayus(char vec[])
{
    int i;
    for(i = 0; i < strlen(vec); i++)
    {
        vec[i] = toupper(vec[i]);
    }
}

/*
    // Comandos vistos en la clase de hoy //

     strcmp(char*, char*) Comparison with Case Sensitive
     stricmp(char*, char*) comparison without case sensitive
     strlwr(char*) Convert all the string to low-case
     strupr(char*) Convert all the string to high-case
     strncpy(char*, char*, int) Copy string to another string without exceed the limit of the string destiny.

*/
