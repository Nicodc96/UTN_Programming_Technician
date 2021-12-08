#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define TAM 7

typedef struct{
    int id;
    char marca[20];
    char procesador[20];
    int precio;

}Notebooks;

void mostrarNotebook(Notebooks notebooks);
void mostrarNotebooks(Notebooks notebook[], int tam);
void ordenarNotebooks(Notebooks notebook[], int tam);

int main()
{
    Notebooks lista[] = {
        {50, "HP", "AMD", 6745},
        {33, "ASUS", "INTEL", 10752},
        {21, "ASUS", "AMD", 3425},
        {17, "EXO", "AMD", 8942},
        {26, "HP", "INTEL", 11864},
        {74, "EXO", "AMD", 9567},
        {44, "HP", "INTEL", 7599},
    };
    printf("ARRAY SIN ORDENAR\n\n");
    mostrarNotebooks(lista, TAM);

    printf("\nARRAY ORDENADO POR MARCA\n\n");
    ordenarNotebooks(lista, TAM);
    mostrarNotebooks(lista, TAM);

    return 0;
}


void mostrarNotebook(Notebooks notebooks){
    printf("%d   %10s   %10s       %d\n", notebooks.id, notebooks.marca, notebooks.procesador, notebooks.precio);
}

void mostrarNotebooks(Notebooks notebook[], int tam){
    printf("ID        MARCA    PROCESADOR     PRECIO\n\n");
    for (int i = 0; i < tam; i++){
        mostrarNotebook(notebook[i]);
    }
}

void ordenarNotebooks(Notebooks notebook[], int tam){
    //char auxChar[20];
    //int auxInt;
    Notebooks auxNotebooks;
    for (int i = 0; i < tam-1; i++){
        for (int j = i+1; j < tam; j++){
            if (strcmp(notebook[i].marca, notebook[j].marca) < 0){
                auxNotebooks = notebook[i];
                notebook[i] = notebook[j];
                notebook[j] = auxNotebooks;
            }
            if (strcmp(notebook[i].marca, notebook[j].marca) == 0 && notebook[i].precio > notebook[j].precio){
                auxNotebooks = notebook[i];
                notebook[i] = notebook[j];
                notebook[j] = auxNotebooks;
            }
        }
    }
}
