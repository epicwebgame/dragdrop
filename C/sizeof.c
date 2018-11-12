#include<stdio.h>

int main()
{
    /*
    See also:

    C Data Types
    https://www.tutorialspoint.com/cprogramming/c_data_types.htm

    Permalink: https://stackoverflow.com/q/11438794/303685
    Transient Link: https://stackoverflow.com/questions/11438794/is-the-size-of-c-int-2-bytes-or-4-bytes
    Title: Is the size of C “int” 2 bytes or 4 bytes?

    Contrast with the C# program in the SizeOf folder.
    And: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sizeof

    */

   printf("\nSize of:\n");
   printf("\tchar: %d\n", sizeof(char));
   printf("\tshort: %d\n", sizeof(short));
   printf("\tint: %d\n", sizeof(int));
   printf("\tlong: %d\n", sizeof(long));
   printf("\tfloat: %d\n", sizeof(float));
   printf("\tdouble: %d\n", sizeof(double));
   printf("\tlong double: %d\n", sizeof(long double));
   printf("\n");

   return 0;
}