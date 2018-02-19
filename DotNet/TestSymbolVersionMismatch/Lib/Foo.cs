using System.Diagnostics;

namespace Lib
{
    public class Foo
    {
        public Foo()
        {
            Debug.Print("In Foo ctor");
        }

        public string Name { get; set; }

        public string NewProperty { get; set; }
    }
}
