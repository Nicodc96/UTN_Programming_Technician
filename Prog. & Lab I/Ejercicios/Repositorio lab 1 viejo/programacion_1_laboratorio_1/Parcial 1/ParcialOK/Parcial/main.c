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

#define TAMF 25
#define TAMM 5
#define TAMC 5
#define TAMA 25
#define TAMS 4
#define TAMT 25

int menuPrincipal();

void mostrarVehiculosModernos(Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC);
void precioTotalTrabajos(Trabajos trabajo[], int tamT, Servicios servicio[], int tamS);
void menuInformesCases(Trabajos trabajos[], int tamT, Servicios servicio[], int tamS, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC);
int menuInformes();

int main()
{
    Marcas listaMarcas[TAMM];
    Color listaColores[TAMC];
    Servicios listaServicios[TAMS];
    Autos listaAutos[TAMA];
    Trabajos listaTrabajos[TAMT];

    int marca = 1000;
    int color = 5000;
    int servicio = 20000;
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

    do{
        switch(menuPrincipal()){
    case 'a':
        if(autoAltaAutos(listaAutos, TAMA, autos)){
            autos++;
        }
        break;
    case 'b':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        menuModificarAutos(listaAutos, TAMA, listaColores, TAMC, listaMarcas, TAMM);
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'c':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        bajaAuto(listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC);
        } else
            {
                printf("\nSe debe dar de ALTA a un auto antes de realizar esta accion.\n");
            }
        break;
    case 'd':
        checkTrue = checkAuto(listaAutos, TAMA);
        if (checkTrue == 1){
        listarVehiculosOrdenados(listaAutos, TAMA);
        mostrarAutos(listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC);
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
        menuInformesCases(listaTrabajos, TAMT, listaServicios, TAMS, listaAutos, TAMA, listaMarcas, TAMM, listaColores, TAMC);
        break;
    case 'k':
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
    printf("j) MENU INFORMES\n");
    printf("k) SALIR\n\n");
    printf("Elija opcion: ");
    fflush(stdin);
    scanf("%c", &seguir);
    while (seguir != 'a' && seguir != 'b' && seguir != 'c' && seguir != 'd' && seguir != 'e' && seguir != 'f' && seguir != 'g' && seguir != 'h' && seguir != 'i' && seguir != 'j' && seguir != 'k')
    {
        printf("\nOpcion seleccionada incorrecta. Reingrese: ");
        fflush(stdin);
        scanf("%c", &seguir);
    }
    return seguir;
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

void menuInformesCases(Trabajos trabajos[], int tamT, Servicios servicio[], int tamS, Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC){
    char seguir = 'n';

    do{
        switch(menuInformes()){
    case 'a':
        precioTotalTrabajos(trabajos, tamT, servicio, tamS);
        break;
    case 'b':
        mostrarVehiculosModernos(vehiculos, tamA, marca, tamM, color, tamC);
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

}

void precioTotalTrabajos(Trabajos trabajo[], int tamT, Servicios servicio[], int tamS){
    int sumar = 0;
    for(int i = 0; i < tamT;  i++){
        for(int j = 0; j < tamS; j++){
            if(trabajo[i].idServicio == servicio[j].id){
                sumar+=servicio[j].precio;
            }
        }
    }
    printf("El precio total de los trabajos realizados es: $%d\n\n", sumar);
}

void mostrarVehiculosModernos(Autos vehiculos[], int tamA, Marcas marca[], int tamM, Color color[], int tamC){
    printf("\n\n------ LISTADO DE VEHICULOS MODELO 2010 O SUPERIOR ------\n\n");
    printf("ID AUTO   PATENTE     MARCA      COLOR   MODELO\n\n");
    for (int i = 0; i < tamA; i++){
        if(vehiculos[i].modelo >= 2010 && vehiculos[i].isEmpty == 0){
            mostrarAuto(vehiculos[i], marca, tamM, color, tamC);
        }
    }
    printf("\n");
}
