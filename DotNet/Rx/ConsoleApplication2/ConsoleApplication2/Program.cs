using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    interface IObservable<T>
    {
        void Subscribe(IObserver<T> observer);
        void Unsubscribe(IObserver<T> observer);
    }

    interface IObserver<T>
    {
        void LetMeKnowWhenThatHappens();
    }

    public class Observable<T> : IObservable<T>
    {
        private List<IObserver<T>> _observers = 
            new List<IObserver<T>>();

        public void Subscribe(IObserver<T> observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver<T> observer)
        {
            _observers.Remove(observer);
        }

        public void Do()
        {
            if (/*soething happend */)
            {
                if (_observers != null && _observers.Count > 0)
                    foreach (var observer in _observers)
                        observer.LetMeKnowWhenThatHappens();
            }
        }
    }
}
