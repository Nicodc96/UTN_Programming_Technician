#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
    int dia;
    int mes;
    int anio;
} eFecha;

typedef struct
{
    int legajo;
    char nombre[20];
    char sexo;
    float altura;
    eFecha fechaDeIngreso;      // Estructura anidada en otra
    int isEmpty;
}ePersona;

int main()
{
    //ePersona unaPersona = {100, "Juan", 'm', 1.75, {10,3,2015}, 0};
    ePersona unaPersona;
    /*
    eFecha fechaUno = {10,3,2015};

    unaPersona.legajo = 100;
    strcpy(unaPersona.nombre, "Juan");
    unaPersona.sexo = 'm';
    unaPersona.altura = 1.75;
    unaPersona.fechaDeIngreso = fechaUno;
    unaPersona.isEmpty = 0;
    */

    printf("Nombre: %s\n", unaPersona.nombre);
    printf("Legajo: %d\n", unaPersona.legajo);
    printf("Sexo: %c\n", unaPersona.sexo);
    printf("Altura: %.2f\n", unaPersona.altura);
    printf("Fecha de Ingreso: %02d/%02d/%d\n\n", unaPersona.fechaDeIngreso.dia, unaPersona.fechaDeIngreso.mes, unaPersona.fechaDeIngreso.anio);
    return 0;
}
