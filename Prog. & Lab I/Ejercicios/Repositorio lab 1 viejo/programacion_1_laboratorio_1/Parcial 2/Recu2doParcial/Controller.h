#ifndef CONTROLLER_H_INCLUDED
#define CONTROLLER_H_INCLUDED

int controller_loadText(char* path,LinkedList* lista);
int controller_showList(LinkedList* lista);
int controller_filterType(LinkedList* lista);
int controller_showPosiciones(LinkedList* lista);

#endif // CONTROLLER_H_INCLUDED
