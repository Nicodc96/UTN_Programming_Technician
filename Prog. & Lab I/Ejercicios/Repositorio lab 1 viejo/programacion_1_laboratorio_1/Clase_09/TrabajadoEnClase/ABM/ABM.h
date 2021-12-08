

typedef struct{
    int dia;
    int mes;
    int anio;
}eFecha;

typedef struct{
    int legajo;
    char nombre[20];
    int edad;
    char sexo;
    int nota1;
    int nota2;
    float promedio;
    eFecha fechaIngreso;
    int isEmpty;
}eAlumno;

eAlumno newAlumno(int legajo, char nombre[], char sexo, int edad, int n1, int n2, eFecha fecha);
void mostrarAlumnos(eAlumno vec[], int tam);
void mostrarAlumno(eAlumno x);
void ordenarAlumnos(eAlumno vec[], int tam);
void startAlumnos(eAlumno alumnos[], int tam);
int highAlumno(eAlumno alumnos[], int tam);
int lowAlumno (eAlumno alumnos[], int tam);
int modifyAlumno(eAlumno alumnos[], int tam);
int searchEmpty(eAlumno alumnos[], int tam);
int searchAlumno(int legajo, eAlumno alumnos[], int tam);
int menu();
