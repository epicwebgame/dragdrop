namespace AggregateAPGPHPFibbonacci
{
    public struct Fraction
    {
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;

            Value = Numerator / Denominator;
        }

        public int Numerator { get; }
        public int Denominator { get; }

        public double Value { get; }

        public override string ToString()
        {
            return string.Format($"{Numerator}/{Denominator}");
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            // int numerator, denominator;
            // Calculate the Lowest Common Multiple of the Denominators
            // This is the new Denominator

            // Multiply the thingies requied to be multiplied
            // with each of the numerators

            // Add the numerators now. This is the new Numerator

            // Reduce the numerator and denominator to its lowest form

            return new Fraction(1, 2);
        }

        // op_Subtraction
        // ..

        // op_Multiply
        // ...
    }
}
