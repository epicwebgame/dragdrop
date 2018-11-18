using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("My snippet works");

        var length = 10;

        for (int i = 0; i < length; i++)
        {
            Console.WriteLine(i);
        }

        Console.ReadKey();
    }
}