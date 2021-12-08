#ifndef VEHICULOS_H_INCLUDED
#define VEHICULOS_H_INCLUDED

typedef struct
{
    int id;
    char dominio[6];
    int anio;
    char tipo;
}Vehiculo;

#endif // VEHICULOS_H_INCLUDED

Vehiculo* vehiculo_new();
Vehiculo* vehiculo_newParametros(char* idStr, char* dominioStr, char* anioStr);

int vehiculo_setId(Vehiculo* this, int id);
int vehiculo_getId(Vehiculo* this);

int vehiculo_setDominio(Vehiculo* this, char* dominio);
char* vehiculo_getDominio(Vehiculo* this);

int vehiculo_setAnio(Vehiculo* this, int anio);
int vehiculo_getAnio(Vehiculo* this);

int vehiculo_setTipo(Vehiculo* this, char tipo);
char vehiculo_getTipo(Vehiculo* this);
