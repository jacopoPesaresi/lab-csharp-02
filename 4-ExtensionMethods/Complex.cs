namespace ExtensionMethods
{
    using System;

    /// <inheritdoc cref="IComplex"/>
    public class Complex : IComplex
    {
        private readonly double re;
        private readonly double im;

        /// <summary>
        /// Initializes a new instance of the <see cref="Complex"/> class.
        /// </summary>
        /// <param name="re">the real part.</param>
        /// <param name="im">the imaginary part.</param>
        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        /// <inheritdoc cref="IComplex.Real"/>
        public double Real => re;

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary => im;

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus => Math.Sqrt(Math.Pow(Real,2) + Math.Pow(Imaginary,2));

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase => Math.Atan2(Imaginary, Real);

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            if (Real.Equals(0.0))
            {
                if (Imaginary.Equals(0.0))
                {
                    return "0";
                }
                else
                {
                    return (Imaginary.Equals(1.0) ? "i" : Imaginary.Equals(-1.0) ? "-i" : $"{Imaginary}i");
                }
            } 
            else 
            {
                if (Imaginary.Equals(0.0))
                {
                    return $"{Real}";
                }
                else
                {
                    return  $"{Real} " 
                    + ((Imaginary > 0) ? "+ " : "- ") 
                    + ((Imaginary > 0) ? 
                        (Imaginary.Equals(1.0) ? "i" : $"{Imaginary}i") : 
                        (Imaginary.Equals(-1.0) ? "i" : $"{-1*Imaginary}i"));
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return this.Real.Equals(other.Real) && this.Imaginary.Equals(other.Imaginary);
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is IComplex)) return false;
            return this.Equals((IComplex)obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
        }
    }
}
