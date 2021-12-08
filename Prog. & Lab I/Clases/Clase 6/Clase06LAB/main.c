#include <stdio.h>
#include <stdlib.h>

double factorial(int n);

int main()
{
    printf("%.0lf\n", factorial(20));
    return 0;
}

double factorial(int n)
{
    if (n <= 1)
    {
        return 1;
    } else
        {
            return n * factorial(n-1);
        }
}
