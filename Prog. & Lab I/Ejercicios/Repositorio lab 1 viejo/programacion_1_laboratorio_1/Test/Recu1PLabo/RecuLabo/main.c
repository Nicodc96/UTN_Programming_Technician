#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "Pilotos.h"
#include "Naves.h"

#define TAM_PILOTOS 10
#define TAM_NAVES 20
#define TAM_MISIONES 10

int menuDeOpciones();
int menuDeInformes();


int main()
{
    char seguir = 'n';
    char resp;
    ePiloto listadePilotos[TAM_PILOTOS];
    eNave listadeNaves[TAM_NAVES];
    eMisiones listadeMisiones[TAM_MISIONES];
    int pilotos = 1;
    int naves = 20;
    int misiones = 10;

    inicializarPilotos(listadePilotos, TAM_PILOTOS);
    inicializarNaves(listadeNaves, TAM_NAVES);
    inicializarNaves(listadeMisiones, TAM_MISIONES);

    pilotos = pilotos + hardcodearPilotos(listadePilotos, TAM_PILOTOS, 7);

    do
    {
        switch(menuDeOpciones())
        {
        case 1:
            system("cls");
            printf("--------- GESTION DE NAVES | AGENCIA ---------\n\n");
            printf("A) ALTAS\n");
            printf("B) MODIFICAR\n");
            printf("C) BAJAS\n");
            printf("D) LISTAR\n");
            printf("E) SALIR\n\n");
            printf("Ingrese opcion: ");
            fflush(stdin);
            scanf("%c", &resp);
            while(resp != 'a' && resp != 'A' && resp != 'b' && resp != 'B' && resp != 'c' && resp != 'C' && resp != 'd' && resp != 'D' && resp != 'e' && resp != 'E')
            {
                printf("Error! Ingrese una opcion correcta!: ");
                fflush(stdin);
                scanf("%c", &resp);
            }
            if(resp == 'a' || resp == 'A')
            {
                if(altaNave(listadeNaves, TAM_NAVES, naves))
                {
                    naves++;
                }
            }
            if(resp == 'c' || resp == 'C')
            {
                bajaNave(listadeNaves, TAM_NAVES);
            }
            if(resp == 'd' || resp == 'D')
            {
                system("cls");
                listarNaves(listadeNaves, TAM_NAVES);
            }
            if(resp == 'e' || resp == 'E')
            {
                printf("\nEsta saliendo del menu Gestion de Naves...\n");
            }
            break;
        case 2:
            system("cls");
            printf("--------- GESTION DE PILOTOS | AGENCIA ---------\n\n");
            printf("A) Listar Pilotos\n");
            printf("B) SALIR\n\n");
            printf("Ingrese opcion: ");
            fflush(stdin);
            scanf("%c", &resp);
                while(resp != 'a' && resp != 'A' && resp != 'b' && resp != 'B')
                {
                    printf("Error! Ingrese una opcion correcta!: ");
                    fflush(stdin);
                    scanf("%c", &resp);
                }
                if(resp == 'a' || resp == 'A')
                {
                    mostrarPilotos(listadePilotos, TAM_PILOTOS);
                } else
                    {
                        printf("\nEsta saliendo del menu gestion de pilotos...\n");
                    }
            break;
        case 3:
             system("cls");
            printf("--------- GESTION DE MISIONES | AGENCIA ---------\n\n");
            printf("A) GENERAR MISION\n");
            printf("B) LISTAR MISION\n");
            printf("C) SALIR\n\n");
            scanf("%c", &resp);
                while(resp != 'a' && resp != 'A' && resp != 'b' && resp != 'B' && resp != 'c' && resp != 'C')
                {
                    printf("Error! Ingrese una opcion correcta!: ");
                    fflush(stdin);
                    scanf("%c", &resp);
                }
            if(resp == 'a' || resp == 'A')
            {

            }
            if(resp == 'b' || resp == 'B')
            {
                mostrarMisiones(listadeMisiones, TAM_MISIONES);
            }
            if(resp == 'c' || resp == 'C')
            {
                printf("\nEsta saliendo del menu gestion de misiones...\n");
            }
            break;
        case 4:
            switch(menuDeInformes())
            {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                printf("\nEsta saliendo del menu de informes...\n");
                break;
            }
            break;
        case 5:
            printf("Confimar salida (y/n): ");
            fflush(stdin);
            scanf("%c", &seguir);
            while(seguir != 'n' && seguir != 'y')
            {
                printf("Respuesta incorrecta. Ingrese 'y' o 'n': ");
                fflush(stdin);
                scanf("%c", &seguir);
            }
            break;
        default:
            printf("Opcion seleccionada incorrecta!\n");
        }
        system("pause");
    }while(seguir == 'n');
    return 0;
}

int menuDeOpciones()
{
    int opcion;
    system("cls");
    printf("--------- MENU DE OPCIONES | UTN FRA ---------\n\n");
    printf("1) GESTION DE NAVES\n");
    printf("2) GESTION DE PILOTOS\n");
    printf("3) GESTION DE MISIONES\n");
    printf("4) MENU DE INFORMES\n");
    printf("5) SALIR \n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);

    return opcion;
}

int menuDeInformes()
{
    int opcion;
    system("cls");
    printf("--------- MENU DE INFORMES | UTN FRA ---------\n\n");
    printf("1) \n");
    printf("2) \n");
    printf("3) \n");
    printf("4) SALIR\n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);

    return opcion;
}
