using ClassLibrary2;
using System;

namespace ClassLibrary1
{
    public class Foo: Bar, IDisposable
    {
        public string Gar { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
