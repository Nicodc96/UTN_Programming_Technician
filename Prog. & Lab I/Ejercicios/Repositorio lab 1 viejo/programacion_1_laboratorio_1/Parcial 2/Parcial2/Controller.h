#ifndef CONTROLLER_H_INCLUDED
#define CONTROLLER_H_INCLUDED
#include "Linkedlist.h"

int controller_loadArchive(char* path, LinkedList* lista);
int controller_listArchive(LinkedList* lista);
int controller_filter45Days(LinkedList* lista);
int controller_filterMachos(LinkedList* lista);
int controller_listCallejeros(LinkedList* lista);

#endif // CONTROLLER_H_INCLUDED
