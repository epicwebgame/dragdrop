using System;
using Ninject;

namespace ConsoleApplication13
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();

            kernel.Bind<IProcessor>().To<Intel>();
            
            var laptop = kernel.Get<Laptop>();

            Console.WriteLine(laptop.GetType().Name);

            Console.ReadKey();
        }
    }

    class Laptop
    {
        public Laptop(IProcessor processor, Keyboard keyboard, 
            Mouse mouse, HardDrive hardDrive)
        {

        }
    }

    interface IProcessor { }
    class Intel : IProcessor { }
    class Keyboard { }
    class HardDrive { }

    class Mouse
    {
        public Mouse(Button left, Button right, Wheel wheel)
        {

        }
    }

    class Button { }
    class Wheel
    {
        private Wheel() { }
    }
}
