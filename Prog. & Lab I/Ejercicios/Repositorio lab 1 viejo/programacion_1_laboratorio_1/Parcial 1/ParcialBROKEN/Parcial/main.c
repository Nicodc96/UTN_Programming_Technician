#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "validaciones.h"
#include "marca.h"
#include "fecha.h"
#include "color.h"
#include "auto.h"
#include "servicio.h"
#include "trabajo.h"
#include "cliente.h"

#define TAMF 100
#define TAMM 5
#define TAMC 5
#define TAMA 15
#define TAMS 4
#define TAMT 25
#define TAMCLI 5

int menuPrincipal();

void menuInformesCases(Trabajos trabajos[], int tamT, Servicios servicio[], int tamS, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC);
int menuInformes();

int main()
{
    eCliente listaClientes[TAMCLI];
    Marcas listaMarcas[TAMM];
    Color listaColores[TAMC];
    Servicios listaServicios[TAMS];
    Autos listaAutos[TAMA];
    Trabajos listaTrabajos[TAMT];

    int marca = 1000;
    int color = 5000;
    int servicio = 20000;
    int clientes = 600;
    int trabajo = 200;
    int autos = 7000;
    char seguir = 'n';
    int checkTrue;

    inicializarAutos(listaAutos, TAMA);
    inicializarTrabajos(listaTrabajos, TAMT);

    //
    marca = marca + harcodearMarcas(listaMarcas, TAMM, 5);
    color = color + harcodearColores(listaColores, TAMC, 5);
    servicio = servicio + harcodearServicios(listaServicios, TAMS, 4);
    autos = autos + harcodearAutos(listaAutos, TAMA, 7);
    trabajo = trabajo + harcodearTrabajos(listaTrabajos, TAMT, 7);
    clientes = clientes + harcodearClientes(listaClientes, TAMCLI, 5);

    do{
        switch(menuPrincipal()){
    case 'a':
        if(autoAltaAutos(listaAutos, TAMA, autos, listaClientes, TAMCLI)){
            autos++;
        }
        break;
    case 'b':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        menuModificarAutos(listaAutos, TAMA, listaColores, TAMC, listaMarcas, TAMM, listaClientes, TAMCLI);
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'c':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        bajaAuto(listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC, listaClientes, TAMCLI);
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'd':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        listarVehiculosOrdenados(listaAutos, TAMA);
        mostrarAutos(listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC, listaClientes, TAMCLI;
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'e':
        system("cls");
        printf("------ LISTA DE MARCAS ACTIVAS ------\n\n");
        mostrarMarcas(listaMarcas, TAMM);
        break;
    case 'f':
        system("cls");
        printf("------ LISTA DE COLORES ACTIVOS ------\n\n");
        mostrarColores(listaColores, TAMC);
        break;
    case 'g':
        system("cls");
        printf("------ LISTA DE SERVICIOS ACTIVOS ------\n\n");
        mostrarServicios(listaServicios, TAMS);
        break;
    case 'h':
        checkTrue = checkAuto(listaAutos, TAMA);
        if(checkTrue == 1){
            altaTrabajo(trabajo, listaTrabajos, TAMT, listaAutos, TAMA, listaServicios, TAMS);
            trabajo++;
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'i':
        checkTrue = checkAuto(listaAutos, TAMA);
        if(checkTrue == 1){
            checkTrue = checkTrabajo(listaTrabajos, TAMT);
            if(checkTrue == 1){
            mostrarTrabajos(listaTrabajos, TAMT, listaServicios, TAMS);
            } else {
                printf("\nSe debe dar de ALTA a un trabajo antes de realizar esta accion.\n");
            }
        } else
            {
                printf("\nSe debe dar de ALTA a un Auto antes de realizar esta accion.\n");
            }
        break;
    case 'j':
        mostrarAutosLocalidad(listaClientes, TAMCLI, listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC);
        break;
    case 'k':
        mostrarImporteCliente(listaClientes, TAMCLI, listaAutos, TAMA, listaTrabajos, TAMT, listaServicios, TAMS);
        break;
    case 'l':
        mostrarClientes(listaClientes, TAMCLI);
        break;
    case 'm':
        printf("Confirmar salida (y/n): ");
        fflush(stdin);
        scanf("%c", &seguir);
        break;
        }
    system("pause");
    }while(seguir == 'n');

    return 0;
}

int menuPrincipal()
{
    char seguir;
    system("cls");
    printf("------ LAVADORES DE AUTOS ------\n\n");
    printf("a) ALTA AUTO\n");
    printf("b) MODIFICAR AUTO(S)\n");
    printf("c) BAJA AUTO\n");
    printf("d) LISTAR AUTOS\n");
    printf("e) LISTAR MARCAS\n");
    printf("f) LISTAR COLORES\n");
    printf("g) LISTAR SERVICIOS\n");
    printf("h) ALTA TRABAJO\n");
    printf("i) LISTAR TRABAJOS\n");
    printf("j) MOSTRAR VEHICULOS SEGUN LOCALIDAD\n");
    printf("k) MOSTRAR IMPORTE A PAGAR SEGUN CLIENTE\n");
    printf("l) LISTAR CLIENTES\n");
    printf("m) SALIR\n\n");
    printf("Elija opcion: ");
    fflush(stdin);
    scanf("%c", &seguir);
    while (seguir != 'a' && seguir != 'b' && seguir != 'c' && seguir != 'd' && seguir != 'e' && seguir != 'f' && seguir != 'g' && seguir != 'h' && seguir != 'i' && seguir != 'j' && seguir != 'k' && seguir != 'l' && seguir != 'm')
    {
        printf("\nOpcion seleccionada incorrecta. Reingrese: ");
        fflush(stdin);
        scanf("%c", &seguir);
    }
}

int menuInformes(){

    char seguir;
    system("cls");
    printf("------ MENU INFORMES | LAVADOS ------\n\n");
    printf("a) INFORMAR PRECIO DE TODOS LOS TRABAJOS\n");
    printf("b) MOSTRAR VEHICULOS MODELO 2010 EN ADELANTE\n");
    printf("c) MOSTRAR VEHICULOS POR\n");
    printf("d)\n");
    printf("e) SALIR\n\n");
    printf("Elija opcion: ");
    fflush(stdin);
    scanf("%c", &seguir);
    while (seguir != 'a' && seguir != 'b' && seguir != 'c' && seguir != 'd' && seguir != 'e'){
       printf("\nOpcion seleccionada incorrecta. Reingrese: ");
        fflush(stdin);
        scanf("%c", &seguir);
    }
    return seguir;
}

/*void menuInformesCases(Trabajos trabajos[], int tamT, Servicios servicio[], int tamS, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC){
    char seguir = 'n';

    do{
        switch(menuInformes()){
    case 'a':
        break;
    case 'b':
        break;
    case 'c':
        break;
    case 'd':
        break;
    case 'e':
        printf("Confirmar salida (y/n): ");
        fflush(stdin);
        scanf("%c", &seguir);
        break;
        }
    system("pause");
    }while(seguir == 'n');

}*/
