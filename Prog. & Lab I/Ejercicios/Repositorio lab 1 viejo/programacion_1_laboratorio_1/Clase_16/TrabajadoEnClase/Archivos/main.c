#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char auxChar;
    FILE* archivo = fopen("archivo.txt", "r");
    char mensaje[30] = "Esto es un mensaje";
    char cadena[30];

    if(archivo == NULL)
    {
        printf("Archivo no encontrado/inexistente.\n");
        system("pause");
        exit(EXIT_FAILURE);
    }
    //fprintf(archivo, "%s", mensaje);
    //fwrite(mensaje, sizeof(char), strlen(mensaje), archivo);
    //fscanf(archivo, "%s", cadena);
    while(!feof(archivo)){
        auxChar = fgetc(archivo);
        //printf("%c", auxChar);
        fread(cadena, sizeof(char), 29, archivo);
        printf("%s", cadena);
    }

    fclose(archivo);

    return 0;
}
