#include <stdio.h>
#include <stdlib.h>
#include "auto.h"
#include "servicio.h"
#include "marca.h"
#include "color.h"
#include "cliente.h"

int harcodearClientes(eCliente cliente[], int tamCli, int cantidad){
    int contador;
    eCliente listaAuxiliar[] = {
        {600, "Juan", "Avellaneda"},
        {601, "Pedro", "Lanus"},
        {602, "Ignacio", "Turdera"},
        {603, "Julieta", "Adrogue"},
        {604, "Lucia", "Caballito"}
    };
    if (cantidad <= 5 && cantidad <= tamCli){
        for (int i = 0; i < cantidad; i++){
            cliente[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}

void mostrarCliente(eCliente cliente){
    printf("  %d %10s %10s\n", cliente.id, cliente.nombre, cliente.localidad);
}

void mostrarClientes(eCliente cliente[], int tamCli){
    for (int i = 0; i < tamCli; i++){
        mostrarCliente(cliente[i]);
    }
}

int mostrarNombreCliente(int id, eCliente cliente[], int tamCli, char nombre[]){
    int isOk = 0;

    for (int i = 0; i < tamCli; i++){
        if (id == cliente[i].id){
            strcpy(nombre, cliente[i].nombre);
            isOk = 1;
            break;
        }
    }
    return isOk;
}

int mostrarLocalidadCliente(int id, eCliente cliente[], int tamCli, char localidad[]){
    int isOk = 0;

    for (int i = 0; i < tamCli; i++){
        if (id == cliente[i].id){
            strcpy(localidad, cliente[i].localidad);
            isOk = 1;
            break;
        }
    }
    return isOk;
}

void mostrarAutosLocalidad(eCliente cliente[], int tamCli, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC){
    char loc[20];
    char auxCad[100];
    system("cls");
    printf("------ VEHICULOS SEGUN LOCALIDAD ------\n\n");
    printf("Ingrese la localidad: ");
    fflush(stdin);
    scanf("%s", auxCad);
    validarLocalidad(auxCad, cliente, tamCli);
    strcpy(loc, auxCad);

    for (int i = 0; i < tamCli; i++){
        if(strcmp(loc, cliente[i].localidad) == 0){
             for (int j = 0; j < tamA; j++){
                if (cliente[i].id == vehiculos[j].idCliente){
                    mostrarAuto(vehiculos[j], marca, tamM, color, tamC, cliente, tamCli);
                }
             }
            }
        }
}

void mostrarImporteCliente(eCliente cliente[], int tamCli, Autos vehiculos[], int tamA, Trabajos trabajo[], int tamT, Servicios servicio[], int tamS){
    char auxCad[100];
    char nombre[20];
    int sumar;

    printf("Ingrese el Nombre del titular: ");
    scanf("%s", auxCad);
    validarNombre(auxCad, cliente, tamCli);
    strcpy(nombre, auxCad);

    for (int i = 0; i < tamCli; i++){
        if (strcmp(nombre, cliente[i].nombre) == 0){
            for (int j = 0; j < tamA; j++){
                if (cliente[i].id == vehiculos[j].idCliente){
                    for(int k = 0; k < tamT; k++){
                        if(vehiculos[j].patente == trabajo[k].patente){
                            for(int l = 0; l < tamS; l++){
                                if(trabajo[k].idServicio == servicio[l].id){
                                    sumar+=servicio[l].precio;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    printf("\nEl importe a pagar del cliente %s es: $%d\n", nombre, sumar);
}
