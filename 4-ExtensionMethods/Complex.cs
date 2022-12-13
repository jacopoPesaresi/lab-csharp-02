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
        public double Real
        {
            get
            {
                return re;
                //throw new System.NotImplementedException();
            }
        }

        /// <inheritdoc cref="IComplex.Imaginary"/>
        public double Imaginary
        {
            get
            {
                return im;
                //throw new System.NotImplementedException();
            }
        }

        /// <inheritdoc cref="IComplex.Modulus"/>
        public double Modulus
        {
            get
            {
                return Math.Sqrt(Math.Pow(Real,2) + Math.Pow(Imaginary,2));
                //throw new System.NotImplementedException();
            }
        }

        /// <inheritdoc cref="IComplex.Phase"/>
        public double Phase
        {
            get
            {
                return Math.Atan2(Imaginary, Real);
                //throw new System.NotImplementedException();
            }
        }

        /// <inheritdoc cref="IComplex.ToString"/>
        public override string ToString()
        {
            if (Real.Equals(0.0) && Imaginary.Equals(0.0))
            {
                return "0";
            } 
            else if (Real.Equals(0.0))
            {
                return (Imaginary.Equals(1.0) ? "i" : Imaginary.Equals(-1.0) ? "-i" : $"{Imaginary}i");
            }
            else if (Imaginary.Equals(0.0))
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

        /// <inheritdoc cref="IEquatable{T}.Equals(T)"/>
        public bool Equals(IComplex other)
        {
            return this.Real.Equals(other.Real) && this.Imaginary.Equals(other.Imaginary);
            throw new System.NotImplementedException();
        }

        /// <inheritdoc cref="object.Equals(object?)"/>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is IComplex)) return false;
            return this.Equals((IComplex)obj);
            // TODO improve
            //return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Real, Imaginary);
            // TODO improve -fato
        }
    }
}
