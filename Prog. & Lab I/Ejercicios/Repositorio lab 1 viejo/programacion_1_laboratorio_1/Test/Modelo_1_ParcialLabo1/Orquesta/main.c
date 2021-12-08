#include <stdio.h>
#include <stdlib.h>
#include "Orquestas.h"
#include "Instrumentos.h"
#include "Musicos.h"
#include "Informes.h"

#define TAM_ORQUESTAS 50
#define TAM_INSTRUMENTOS 20
#define TAM_MUSICOS 1000

int menuDeOpciones();
int menuDeInformes();

int main()
{
    eOrquesta listaOrquestas[TAM_ORQUESTAS];
    eInstrumento listaIntrumentos[TAM_INSTRUMENTOS];
    eMusico listaMusicos[TAM_MUSICOS];
    char seguir = 'n';
    int orquestas = 50;
    int instrumentos = 0;
    int musicos = 1000;

    inicializarOrquestas(listaOrquestas, TAM_ORQUESTAS);
    inicializarMusicos(listaMusicos, TAM_MUSICOS);
    inicializarInstrumentos(listaIntrumentos, TAM_INSTRUMENTOS);

    orquestas = orquestas + hardcodearOrquestas(listaOrquestas, TAM_ORQUESTAS, 7);
    instrumentos = instrumentos + hardcodearInstrumentos(listaIntrumentos, TAM_INSTRUMENTOS, 6);
    musicos = musicos + hardcodearMusicos(listaMusicos, TAM_MUSICOS, 17);

    do{
        switch(menuDeOpciones())
        {
        case 1:
            if(agregarOrquesta(listaOrquestas, TAM_INSTRUMENTOS, orquestas))
            {
                orquestas++;
            }
            break;
        case 2:
            if(bajaOrquesta(listaOrquestas, TAM_ORQUESTAS))
            {
                printf("Se ha dado de baja correctamente!\n");
            }
            break;
        case 3:
            system("cls");
            mostrarOrquestas(listaOrquestas, TAM_ORQUESTAS);
            break;
        case 4:
            if(agregarMusico(listaMusicos, musicos, TAM_MUSICOS, listaIntrumentos, TAM_INSTRUMENTOS, listaOrquestas, TAM_ORQUESTAS))
            {
                musicos++;
            }
            break;
        case 5:
            modificarMusico(listaMusicos, TAM_MUSICOS, listaIntrumentos, TAM_INSTRUMENTOS, listaOrquestas, TAM_ORQUESTAS);
            break;
        case 6:
            if(bajaMusico(listaMusicos, TAM_MUSICOS, listaOrquestas, TAM_ORQUESTAS, listaIntrumentos, TAM_INSTRUMENTOS))
            {
                printf("Se ha dado de baja correctamente!\n");
            }
            break;
        case 7:
            system("cls");
            mostrarMusicos(listaMusicos, TAM_MUSICOS, listaIntrumentos, TAM_INSTRUMENTOS, listaOrquestas, TAM_ORQUESTAS);
            break;
        case 8:
            if(agregarInstrumento(listaIntrumentos, TAM_INSTRUMENTOS, instrumentos))
            {
                instrumentos++;
            }
            break;
        case 9:
            system("cls");
            mostrarInstrumentos(listaIntrumentos, TAM_INSTRUMENTOS);
            break;
        case 10:
            switch(menuDeInformes())
            {
            case 1:
                informarOrquesta5Musicos(listaMusicos, TAM_MUSICOS, listaOrquestas, TAM_ORQUESTAS);
                break;
            case 2:
                listarMusicosDeOrquesta(listaMusicos, TAM_MUSICOS, listaOrquestas, TAM_ORQUESTAS, listaIntrumentos, TAM_INSTRUMENTOS);
                break;
            case 3:
                informarMusicosCuerdas(listaMusicos, TAM_MUSICOS, listaIntrumentos, TAM_INSTRUMENTOS);
                break;
            case 4:
                printf("\nEsta saliendo del menu informes...\n");
                break;
            default:
                printf("Opcion seleccionada incorrecta\n");
            }
            break;
        case 11:
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
    printf("--------- MENU DE OPCIONES | ORQUESTA ---------\n\n");
    printf("1) Agregar Orquesta\n");
    printf("2) Eliminar Orquesta\n");
    printf("3) Imprimir Orquestas\n");
    printf("4) Agregar Musico\n");
    printf("5) Modificar Musico\n");
    printf("6) Eliminar Musico\n");
    printf("7) Imprimir Musicos\n");
    printf("8) Agregar Instrumento\n");
    printf("9) Imprimir Instrumentos\n");
    printf("10) Menu Informes\n");
    printf("11) Salir\n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);

    return opcion;
}

int menuDeInformes()
{
    int opcion;
    system("cls");
    printf("--------- MENU DE INFORMES | ORQUESTA ---------\n\n");
    printf("1) Listar orquestas con mas de 5 musicos\n");
    printf("2) Listar todos los musicos de una orquesta determinada\n");
    printf("3) Listar musicos que utilizen instrumentos de cuerdas\n");
    printf("4) Salir\n\n");
    printf("Elija opcion: ");
    scanf("%d", &opcion);
    return opcion;
}
