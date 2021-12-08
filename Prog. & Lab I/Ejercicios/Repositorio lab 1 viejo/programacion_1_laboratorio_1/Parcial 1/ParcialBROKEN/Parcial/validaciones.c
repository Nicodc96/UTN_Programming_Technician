#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "auto.h"
#include "servicio.h"

int validarPatente(int idPatente){
    while(idPatente > 999999 || idPatente < 100000){
        printf("ID de la patente incorrecta. Ingrese valor (100.000 - 999.999): ");
        scanf("%d", &idPatente);
        }
    return idPatente;
}

int verificarPatenteExistente(int idPatente, Autos vehiculos[], int tamA){
    int isEqual = 0;
    for (int i = 0; i < tamA; i++){
        if (idPatente == vehiculos[i].patente && vehiculos[i].isEmpty == 0){
            isEqual = 1;
        }
    }
    return isEqual;
}


int validarMarca(int idMarca){
    while(idMarca > 1004 || idMarca < 1000){
        printf("ID de la marca Incorrecta. Reingrese (1000-1004): ");
        scanf("%d", &idMarca);
    }
    return idMarca;
}

int validarColor(int idColor){
    while(idColor > 5004 || idColor < 5000){
        printf("ID del color incorrecto. Reingrese (5000-5004): ");
        scanf("%d", &idColor);
    }
    return idColor;
}

int validarModelo(int modelo){
    while(modelo < 1950 || modelo > 2019){
        printf("Fecha del modelo incorrecto. Ingrese una fecha valida (1950-2019): ");
        scanf("%d", &modelo);
    }
    return modelo;
}

int verificarAutoExistente(int id, Autos vehiculos[], int tamA){
    int indice = -1;
    for (int i = 0; i < tamA; i++){
        if(id == vehiculos[i].id){
            indice = i;
            break;
        }
    }
    return indice;
}

int verificarServicioExistente(int id, Servicios servicio[], int tamS){
    int indice = -1;
    for (int i = 0; i < tamS; i++){
        if(id == servicio[i].id){
            indice = i;
            break;
        }
    }
    return indice;
}

int validarDia(int dia){
    while(dia < 1 || dia > 31){
        printf("Dia ingresado incorrecto. Reingrese: ");
        scanf("%d", &dia);
    }
    return dia;
}

int validarMes(int mes){
    while(mes < 1 || mes > 12){
        printf("Mes ingresado incorrecto. Reingrese: ");
        scanf("%d", &mes);
    }
    return mes;
}

int validarAnio(int anio){
    while(anio < 2000 || anio > 2019){
        printf("Anio ingresado incorrecto. Reingrese: ");
        scanf("%d", &anio);
    }
    return anio;
}

int validarMeses(int dia, int mes){
    while (dia > 28 && mes == 2){
        printf("El mes de febrero tiene como maximo 28 dias. Reingrese Mes: ");
        scanf("%d", &mes);
    }
    while (dia == 31 && (mes == 4 || mes == 6 || mes == 9 || mes == 11)){
        printf("El mes ingresado tiene como maximo 30 dias. Reingrese Mes: ");
        scanf("%d", &mes);
    }
    return mes;
}
