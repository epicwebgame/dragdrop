using System;

namespace NullableOfTEqualityCheck
{
    // Identity and value equality check for the immutable Nullable<T>
    class Program
    {
        static void Main(string[] args)
        {
            NullableEqualityTest();

            Console.ReadKey();
        }

        static void NullableEqualityTest()
        {
            int? first = 1;
            int? second = 1;
            Compare(first, second);
            Console.WriteLine();

            int one = 1;
            first = one;
            second = one;
            Compare(first, second);
            Console.WriteLine();

            int i = 1;
            int? x = i;
            long? y = x;
            Compare(x, y);
            Console.WriteLine();
        }

        static void Compare(Nullable<int> first, Nullable<int> second)
        {
            Console.WriteLine($"first == second: {first == second}");
            Console.WriteLine($"first.Equals(second): {first.Equals(second)}");
            Console.WriteLine($"object.Equals(first, second): {object.Equals(first, second)}");
            Console.WriteLine($"object.ReferenceEquals(first, second): {object.ReferenceEquals(first, second)}");
        }

        static void Compare(Nullable<int> first, Nullable<long> second)
        {
            Console.WriteLine($"first == second: {first == second}");
            Console.WriteLine($"first.Equals(second): {first.Equals(second)}");
            Console.WriteLine($"object.Equals(first, second): {object.Equals(first, second)}");
            Console.WriteLine($"object.ReferenceEquals(first, second): {object.ReferenceEquals(first, second)}");
        }

        static void CovarianceTest1()
        {
            ITree<object> tree = new Node<string>("Hello", "World!");
        }

        static void CovarianceTest2()
        {
            // Node<object> tree = new Node<string>("Hello", "World");
        }
    }

    // See this: http://stackoverflow.com/questions/36753579/algebraic-data-types-in-kotlin
    // Short url: http://stackoverflow.com/a/36753782/303685
    interface ITree<out T>
    {
    }

    class Tree<T>: ITree<T>
    {
    }

    sealed class Node<T> : Tree<T>
    {
        private readonly T _left;
        private readonly T _right;

        public Node(T left, T right)
        {
            _left = left;
            _right = right;
        }

        public T Left { get { return _left; } }
        public T Right { get { return _right; } }
    }

    sealed class Leaf<T> : Tree<T>
    {
        private T _value;

        public Leaf(T value) : base()
        {
            _value = value;
        }

        public T Value { get { return _value; } }
    }

    sealed class Dummy { }

    sealed class Empty : Tree<Dummy>
    {
        private static Empty _empty = null;
        private static object syncLock = new object();
        private Empty() { }
        public Empty Instance
        {
            get
            {
                if (_empty == null)
                {
                    lock (syncLock)
                    {
                        if (_empty == null)
                        {
                            _empty = new Empty();
                        }
                    }
                }

                return _empty;
            }
        }
    }
}
