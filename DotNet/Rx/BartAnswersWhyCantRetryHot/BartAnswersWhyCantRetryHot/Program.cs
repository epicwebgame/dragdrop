using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace BartAnswersWhyCantRetryHot
{
    class Program
    {
        // This program is meant to parse the commentary Bart de Smet
        // made in response to my question, "Why doesn't Rx allow retrying of hot observables?"
        // Reference: https://github.com/Reactive-Extensions/Rx.NET/issues/238#issuecomment-247894496
        static void Main(string[] args)
        {
            ExternalSourceHotThatKeepsTerminationState();

            Console.ReadKey();
        }

        static void ExternalSourceBasedHotWithNoStateAboutTermination()
        {
            var account = new BankAccount();
            var i = 0;
            Task.Run(() => { while(i++ < 100) account.Deposit(1); });

            account.Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            account.Subscribe(v => WriteLine($"late (and unsafe because bad producer): {v}"),
                e => WriteLine($"late (and unsafe because bad producer): {e.Message}"),
                () => WriteLine("late (and unsafe because bad producer) done!"));

            // If we leave the following 3 lines of code
            // commented, the late (and unsafe) observer
            // lingers on hopelessly while the producer's
            // (BankAccount class') thread is long dead and
            // has been retired to the thread pool.
            // But if we uncomment these lines, we observe
            // the bad behavior of our bad producer BankAccount class.
            // It violates the Rx contract. It is not storing the termination
            // state and reproducing it but is actually attempting to produce
            // another value after it was previous terminated. But we don't get to know
            // because:
            // 1. The observer is unsafe once again because (2) below;
            // 2. The producer BankAccount does not ensure safe observer
            Thread.Sleep(2000);
            Console.WriteLine("\nAnd much later...\n");
            account.Deposit(1);

            // In summary, I make the following conclusions of Bart's comments thus far:
            // Since Rx has no control over producers of hot sequences, hot sequences
            // cannot be reliably retried. Therefore, including Retry as a feature on
            // hot observables would be something that works sometimes (if the author of the observable
            // was mindful of creating safe observers and communicating termination state)
            // and doesn't at others (idiot programmer). It would be best, therefore, to not
            // have that feature.
        }

        static void RetryExternalSourceBasedHotWithNoStateAboutTermination()
        {
            var account = new BankAccount();
            var i = 0;
            Task.Run(() => { while (i++ < 100) account.Deposit(1); });

            account.Retry(3).Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            account.Retry(3).Subscribe(v => WriteLine($"late: {v}"),
                e => WriteLine($"late: {e.Message}"),
                () => WriteLine("late done!"));
        }

        static void SubjectBasedHotSoTerminalNotificationPreservedForLateComers()
        {
            var hot = new Hot();

            hot.Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            hot.Subscribe(v => WriteLine($"late: {v}"),
                e => WriteLine($"late: {e.Message}"),
                () => WriteLine("late done!"));
        }

        static void RetrySubjectBasedHotSoTerminalNotificationPreservedForLateComers()
        {
            var hot = new Hot();

            hot.Retry(3).Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            hot.Retry(3).Subscribe(v => WriteLine($"late: {v}"),
                e => WriteLine($"late: {e.Message}"),
                () => WriteLine("late done!"));
        }

        static void ExternalSourceHotThatKeepsTerminationState()
        {
            var school = new School();
            int i = 0;
            Task.Run(() => { while (++i <= 100) school.Admit(new Student(i)); });

            school.Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            school.Subscribe(v => WriteLine($"late: {v}"),
                e => WriteLine($"late: {e.Message}"),
                () => WriteLine("late done!"));

            // This should report back the termination state
            // with the last exception without attempting to produce
            // another value. Let's see.
            // And it does the right thing.
            Thread.Sleep(2000);
            Console.WriteLine("And much later...");
            school.Admit(new Student(100));
        }

        static void RetryExternalSourceHotThatKeepsTerminationState()
        {
            var school = new School();
            int i = 0;

            // I am guessing that here again, you can't retry producing
            // values out of this hot observable School because the code
            // that actually produces these values is external to the producer.
            // Or, one may say that the producer itself is outside of the control
            // of Rx, as is evident with the line of code below.
            // There is no way for the Retry operator to know how to re-generate
            // the values for the School object previously generated or to
            // even generate new ones.
            // But theoretically, if it was possible, or if such a producer
            // were to internally cache old values and spit them out or were
            // to use one of the subjects that cached values (ReplaySubject)
            // then retrying this operation would result, as Bart correctly
            // suggests, in an infinite loop of "recieving an exception and 
            // retrying the operation only to receive the same exception again."
            Task.Run(() => { while (++i <= 100) school.Admit(new Student(i)); });

            school.Retry(3).Subscribe(
                v => WriteLine($"early: {v}"),
                e => WriteLine($"early: {e.Message}"),
                () => WriteLine("early done!"));

            Thread.Sleep(6000);

            school.Retry(3).Subscribe(v => WriteLine($"late: {v}"),
                e => WriteLine($"late: {e.Message}"),
                () => WriteLine("late done!"));
        }
    }

    // Hot observable linked to an external source
    // and preserving no state about termination
    // of the sequence. If we use an ISubject<T> here,
    // it will tell late subscribers / observers of previous
    // terminal state, so this one doesn't use any subjects.
    public class BankAccount : IObservable<decimal>
    {
        private decimal _balance = 0m;

        // Mimic subject, but poorly
        private List<IObserver<decimal>> _observers = new List<IObserver<decimal>>();

        public void Deposit(decimal amount)
        {
            try
            {
                if (_balance >= 5) throw new Exception("Oops!");

                Thread.Sleep(1000);
                _balance += amount;
                Notify(_balance);
            }
            catch(Exception ex)
            {
                Notify(ex);
            }
        }

        public void Withdraw(decimal amount) { /* Same as deposit() ... */ }

        public IDisposable Subscribe(IObserver<decimal> observer)
        {
            if (observer == null) throw new ArgumentNullException("observer");
            _observers.Add(observer);
            return Disposable.Create(() => { });
        }

        protected virtual void Notify(decimal v)
        {
            _observers?.ForEach(o => o.OnNext(v));
        }

        protected virtual void Notify(Exception ex)
        {
            _observers?.ForEach(o => o.OnError(ex));
        }
    }

    public class Student
    {
        public Student(int rollNumber)
        {
            RollNumber = rollNumber;
        }

        public int RollNumber { get; set; }

        public override string ToString()
        {
            return RollNumber.ToString();
        }
    }

    public class School : IObservable<Student>
    {
        // Mimic subject that communicates termination state
        // and therefore ensures safe observers
        private List<IObserver<Student>> _observers = new List<IObserver<Student>>();
        private List<Student> _students = new List<Student>();
        private bool _erred = false;
        private Exception _lastException = null;

        public void Admit(Student student)
        {
            try
            {
                if (_erred)
                {
                    Notify(_lastException);
                    return;
                }

                if (student.RollNumber >= 5) throw new Exception("Oops!");

                Thread.Sleep(1000);
                _students.Add(student);
                Notify(student);
            }
            catch (Exception ex)
            {
                _lastException = ex;
                Notify(ex);
            }
        }

        public IDisposable Subscribe(IObserver<Student> observer)
        {
            if (observer == null) throw new ArgumentNullException("observer");
            _observers.Add(observer);
            return Disposable.Create(() => { });
        }

        protected virtual void Notify(Student v)
        {
            _observers?.ForEach(o => o.OnNext(v));
        }

        protected virtual void Notify(Exception ex)
        {
            _observers?.ForEach(o => o.OnError(ex));
        }
    }

    class Hot : IObservable<int>
    {
        private ISubject<int> _subject = new Subject<int>();

        public Hot()
        {
            var source = Observable.Generate(1, 
                i => i <= 100, 
                i => ++i, 
                i => { if (i == 5) throw new Exception("Oops!"); else return i; }, 
                i => TimeSpan.FromSeconds(1));

            source.Subscribe(_subject);
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            return _subject.Subscribe(observer);
        }
    }
}