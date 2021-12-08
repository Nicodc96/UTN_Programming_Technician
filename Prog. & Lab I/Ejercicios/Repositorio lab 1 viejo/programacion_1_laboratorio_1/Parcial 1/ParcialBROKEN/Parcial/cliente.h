#define AUTO_H_INCLUDED
#include "auto.h"
#define MARCA_H_INCLUDED
#include "marca.h"
#define SERVICIO_H_INCLUDED
#include "servicio.h"
#define COLOR_H_INCLUDED
#include "color.h"
#define TRABAJO_H_INCLUDED
#include "trabajo.h"
#define VALIDACIONES_H_INCLUDED
#include "validaciones.h"

#ifndef CLIENTE_H_INCLUDED
#define CLIENTE_H_INCLUDED


typedef struct{
    int id;
    char nombre[20];
    char localidad[20];

}eCliente;

#endif // CLIENTE_H_INCLUDED

void mostrarCliente(eCliente cliente);
void mostrarClientes(eCliente cliente[], int tamCli);
int harcodearClientes(eCliente cliente[], int tamCli, int cantidad);

int mostrarNombreCliente(int id, eCliente cliente[], int tamCli, char nombre[]);
int mostrarLocalidadCliente(int id, eCliente cliente[], int tamCli, char localidad[]);

void mostrarAutosLocalidad(eCliente cliente[], int tamCli, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC);
void mostrarImporteCliente(eCliente cliente[], int tamCli, Autos vehiculos[], int tamA, Trabajos trabajo[], int tamT, Servicios servicio[], int tamS);
