#include <stdio.h>
#include <stdlib.h>

typedef struct{
    int id;
    char nombre[20];
}ePersona;

void saludar(void);
int sumar(int x, int y);
int restar(int x, int y);
int calcular(int x, int y, int(*pFun)(int, int));

int main()
{
    void (*pepe)(void); // defino a 'pepe' como una variable que guarda una funcion de tipo void
    int (*miguel)(int, int); // defino a 'miguel' como una variable que guarda una funcion de tipo int
    int resultado;
    //----------
    pepe = saludar; // igual a pepe a la funcion saludar para que pepe ejecute saludar(void)
    pepe();
    saludar();
    //---------

    //-------------//
    miguel = restar; // iguale a miguel con restar(int, int);
    printf("\nMiguel vale: %d\n", miguel(50,20));
    miguel = sumar; // ahora miguel apunta a sumar
    printf("\nMiguel vale: %d\n", miguel(50,20));

    resultado = calcular(50, 20, miguel); // asigno a resultado la funcion miguel que tiene, a su vez, asignado la funcion sumar en este scope.
    //-------------//

    printf("\nEl resultado de 'resultado' es: %d\n", resultado);
    return 0;
}

void saludar(void)
{
    printf("Hello world!\n");
}

int sumar(int x, int y)
{
    return x + y;
}
int restar(int x, int y)
{
    return x - y;
}

int calcular(int x, int y, int(*pFun)(int, int))
{
    return pFun(x,y);
}

