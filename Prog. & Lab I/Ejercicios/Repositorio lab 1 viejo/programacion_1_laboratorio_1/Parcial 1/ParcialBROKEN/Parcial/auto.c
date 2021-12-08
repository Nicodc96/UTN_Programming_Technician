#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "auto.h"
#include "color.h"
#include "validaciones.h"
#include "marca.h"
#include "trabajo.h"
#include "cliente.h"

int autoAltaAutos(Autos vehiculos[], int tamA, int idAuto, eCliente cliente[], int tamCli){
    int isOk = 0;
    int indice;
    int patente;
    int idMarca;
    int idColor;
    int modelo;
    int idCliente;
    int auxInt;
    int auxPatente;

    system("cls");
    printf("------ ALTA AUTOS | LAVADOS ------\n\n");

    indice = buscarLibreAuto(vehiculos, tamA);
    if (indice == -1){
        printf("Sistema completo. Imposible dar de alta a un nuevo Auto!\n");
    } else {
            printf("\nIngrese patente: ");
            scanf("%d", &auxInt);
            auxPatente = validarPatente(auxInt);
            while(verificarPatenteExistente(auxPatente, vehiculos, tamA)){
                printf("Patente ingresada ya existe en el sistema. Reingrese: ");
                scanf("%d", &auxInt);
                auxPatente = validarPatente(auxInt);
            }
            patente = auxPatente;

            printf("Ingrese ID de la Marca del vehiculo: ");
            scanf("%d", &auxInt);
            idMarca = validarMarca(auxInt);

            printf("Ingrese ID del color del vehiculo: ");
            scanf("%d", &auxInt);
            idColor = validarColor(auxInt);

            printf("Ingrese el modelo del vehiculo: ");
            scanf("%d", &auxInt);
            modelo = validarModelo(auxInt);

            mostrarClientes(cliente, tamCli);
            printf("Ingrese el ID del cliente (600-604): ");
            scanf("%d", &auxInt);
            idCliente = validarCliente(auxInt);

            vehiculos[indice] = nuevoAuto(idAuto, patente, idMarca, idColor, modelo, idCliente);
            printf("Se ha dado de ALTA a un nuevo auto correctamente.\n");
            isOk = 1;
    }
    return isOk;
}

int buscarLibreAuto(Autos vehiculos[], int tamA)
{
    int indice = -1;
    for(int i = 0; i < tamA; i++)
    {
        if(vehiculos[i].isEmpty == 1)
        {
            indice = i;
            break;
        }
    }
    return indice;
}

int checkAuto(Autos vehiculos[], int tamA)
{
    int isOk = 0;
    for(int i = 0; i < tamA; i++)
    {
        if (vehiculos[i].isEmpty == 0)
        {
            isOk = 1;
        }
    }
    return isOk;
}

Autos nuevoAuto(int id, int patente, int idMarca, int idColor, int modelo, int cliente){

    Autos x;
    x.id = id;
    x.patente = patente;
    x.idColor = idColor;
    x.idMarca = idMarca;
    x.modelo = modelo;
    x.idCliente = cliente;
    x.isEmpty = 0;
    return x;
}

void inicializarAutos(Autos vehiculos[], int tamA)
{
    for(int i = 0; i < tamA; i++)
    {
        vehiculos[i].isEmpty = 1;
    }
}

int bajaAuto(Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color colores[], int tamC, eCliente cliente[], int tamCli){
    int isOk = 0;
    int indice;
    int autos;
    char resp;

    system("cls");
    printf("------ BAJA ALUMNOS | UTN FRA ------\n\n");
    printf("Ingrese el ID del Auto: ");
    scanf("%d", &autos);

    indice = buscarAutoEnArray(vehiculos, tamA, autos);

    if (indice == -1)
    {
        printf("No se ha encontrado el Auto con el ID ingresado.\n");
    } else{
        printf("\nID AUTO  PATENTE  ID MARCA  ID COLOR  MODELO\n\n");
        mostrarAuto(vehiculos[indice], marca, tamM, colores, tamC, cliente, tamCli);
        printf("\n\nConfimar BAJA (y/n): ");
        fflush(stdin);
        scanf("%c", &resp);

        if(resp == 'y'){
            vehiculos[indice].isEmpty = 1;
            isOk = 1;
            printf("Se ha dado de baja correctamente el vehiculo.\n");
        } else{
            printf("Se ha cancelado exitosamente la operacion.\n");
        }
    }
    return isOk;
}

void mostrarAuto(Autos vehiculos, Marcas marca[], int tamM, Color colores[], int tamC, eCliente cliente[], int tamCli){
    char descColores[20];
    char descMarca[20];
    char nombreCliente[20];
    char localidadCliente[20];

    mostrarDescColor(vehiculos.idColor, colores, tamC, descColores);
    mostrarDescMarca(vehiculos.idMarca, marca, tamM, descMarca);
    mostrarNombreCliente(vehiculos.idCliente, cliente, tamCli, nombreCliente);
    mostrarLocalidadCliente(vehiculos.idCliente, cliente, tamCli, localidadCliente);

    printf("  %d    %d %10s   %8s   %d     %d  %10s   %10s\n",
            vehiculos.id,
            vehiculos.patente,
            descMarca,
            descColores,
            vehiculos.modelo,
            vehiculos.idCliente,
            nombreCliente,
            localidadCliente);
}

void mostrarAutos(Autos vehiculos[], int tamA, Marcas marcas[], int tamM, Color color[], int tamC, eCliente cliente[], int tamCli){
    system("cls");
    printf("------ LISTADO DE VEHICULOS ACTIVOS ------\n\n");
    printf("ID AUTO   PATENTE     MARCA      COLOR   MODELO  ID-CLI    NOMBRE    LOCALIDAD\n\n");
    for(int i = 0; i < tamA; i++)
        {
            if (vehiculos[i].isEmpty == 0){
            mostrarAuto(vehiculos[i], marcas, tamM, color, tamC, cliente, tamCli);
            }
        }
}

int menuModificarAutos(Autos vehiculos[], int tamA, Color colores[], int tamC, Marcas marca[], int tamM, eCliente cliente[], int tamCli){
    int isOk = 0;
    int opcion;
    int patente;
    int indice;
    int idColor;
    int modelo;
    int auxInt;
        system("cls");
        printf("------ MODIFICACIONES AUTOS | LAVADOS ------\n\n");
        printf("Ingrese patente del vehiculo: ");
        scanf("%d", &patente);
        indice = buscarPatenteEnArray(vehiculos, tamA, patente);

        if(indice == -1){
            printf("No existe un auto con la patente ingresada. Volviendo al menu..\n");
        } else{
        printf("\nID AUTO   PATENTE  ID MARCA  ID COLOR  MODELO\n\n");
        mostrarAuto(vehiculos[indice], marca, tamM, colores, tamC, cliente, tamCli);
        printf("\n1) MODIFICAR COLOR\n");
        printf("2) MODIFICAR MODELO\n");
        printf("3) SALIR\n\n");
        printf("Elija opcion: ");
        scanf("%d", &opcion);
        switch(opcion){
    case 1:
        printf("Ingrese la nueva ID de color: ");
        scanf("%d", &auxInt);
        idColor = validarColor(auxInt);
        vehiculos[indice].idColor = idColor;
            printf("Se ha modificado exitosamente el color.\n\n");
            isOk = 1;
        break;
    case 2:
        printf("Ingrese la fecha del modelo: ");
        scanf("%d", &auxInt);
        modelo = validarModelo(auxInt);
        vehiculos[indice].modelo = modelo;
            printf("Se ha modificado exitosamente el modelo.\n\n");
            isOk = 1;
        break;
    case 3:
        printf("Saliendo del menu...\n");
        break;
    default:
        printf("Opcion incorrecta!\n");
        break;
        }
    }
    return isOk;
}

int buscarAutoEnArray(Autos vehiculos[], int tamA, int id){

    int indice = -1;
    for (int i = 0; i < tamA; i++){
        if (vehiculos[i].id == id && vehiculos[i].isEmpty == 0){
            indice = i;
            break;
        }
    }
    return indice;
}


int buscarPatenteEnArray(Autos vehiculos[], int tamA, int patente){

    int indice = -1;
    for (int i = 0; i < tamA; i++){
        if (vehiculos[i].patente == patente && vehiculos[i].isEmpty == 0){
            indice = i;
            break;
        }
    }
    return indice;
}

void listarVehiculosOrdenados(Autos vehiculos[], int tamA){
    int auxInt;
    for (int i = 0; i < tamA - 1; i++){
        for(int j = i + 1; j < tamA; j++){
            if(vehiculos[i].idMarca > vehiculos[j].idMarca && vehiculos[i].isEmpty == 0 && vehiculos[j].isEmpty == 0){
                auxInt = vehiculos[i].id;
                vehiculos[i].id = vehiculos[j].id;
                vehiculos[j].id = auxInt;

                auxInt = vehiculos[i].patente;
                vehiculos[i].patente = vehiculos[j].patente;
                vehiculos[j].patente = auxInt;

                auxInt = vehiculos[i].idMarca;
                vehiculos[i].idMarca = vehiculos[j].idMarca;
                vehiculos[j].idMarca = auxInt;

                auxInt = vehiculos[i].idColor;
                vehiculos[i].idColor = vehiculos[j].idColor;
                vehiculos[j].idColor = auxInt;

                auxInt = vehiculos[i].modelo;
                vehiculos[i].modelo = vehiculos[j].modelo;
                vehiculos[j].modelo = auxInt;
            }
            if (vehiculos[i].idMarca == vehiculos[j].idMarca && vehiculos[i].patente > vehiculos[j].patente && vehiculos[i].isEmpty == 0 && vehiculos[j].isEmpty == 0){
                auxInt = vehiculos[i].id;
                vehiculos[i].id = vehiculos[j].id;
                vehiculos[j].id = auxInt;

                auxInt = vehiculos[i].patente;
                vehiculos[i].patente = vehiculos[j].patente;
                vehiculos[j].patente = auxInt;

                auxInt = vehiculos[i].idMarca;
                vehiculos[i].idMarca = vehiculos[j].idMarca;
                vehiculos[j].idMarca = auxInt;

                auxInt = vehiculos[i].idColor;
                vehiculos[i].idColor = vehiculos[j].idColor;
                vehiculos[j].idColor = auxInt;

                auxInt = vehiculos[i].modelo;
                vehiculos[i].modelo = vehiculos[j].modelo;
                vehiculos[j].modelo = auxInt;
            }
        }
    }
}

int harcodearAutos(Autos vehiculos[], int tamA, int cantidad){
    int contador;
    Autos listaAuxiliar[] = {
        {7000, 511511, 1000, 5000, 2004, 600, 0},
        {7001, 852451, 1002, 5004, 2015, 601, 0},
        {7002, 996463, 1001, 5003, 2001, 602, 0},
        {7003, 178435, 1000, 5001, 1970, 605, 0},
        {7004, 567314, 1004, 5004, 2019, 601, 0},
        {7005, 330005, 1001, 5002, 2012, 602, 0},
        {7007, 661777, 1002, 5000, 1990, 604, 0},
        {7008, 661777, 1002, 5000, 1990, 600, 0},
        {7009, 661777, 1002, 5000, 1990, 604, 0}
    };
    if (cantidad <= 9 && cantidad <= tamA){
        for (int i = 0; i < cantidad; i++){
            vehiculos[i] = listaAuxiliar[i];
            contador++;
        }
    }
    return contador;
}
