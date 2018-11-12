using System;
using System.Runtime.InteropServices;

namespace SizeOf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSize of:");
            Console.WriteLine($"\tbyte: {sizeof(byte)}");
            Console.WriteLine($"\tchar: {sizeof(char)}");
            Console.WriteLine($"\tshort: {sizeof(short)}");
            Console.WriteLine($"\tint: {sizeof(int)}");
            Console.WriteLine($"\tlong: {sizeof(long)}");
            Console.WriteLine($"\tfloat: {sizeof(float)}");
            Console.WriteLine($"\tdouble: {sizeof(double)}");
            Console.WriteLine($"\tdecimal: {sizeof(decimal)}");

            // error CS0233: 'DateTime' does not have a predefined size, 
            // therefore sizeof can only be used in an unsafe context 
            // (consider using System.Runtime.InteropServices.Marshal.SizeOf)
            // Console.WriteLine($"\tDateTime: {sizeof(DateTime)}");

            // System.ArgumentException: Type 'System.DateTime' cannot be 
            // marshaled as an unmanaged structure; no meaningful size or 
            // offset can be computed.
            // Console.WriteLine($"\tDateTime: {Marshal.SizeOf(new DateTime())}");

            Console.WriteLine();
        }
    }
}
