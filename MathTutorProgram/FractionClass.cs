using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathTutorProgram
{
    class FractionClass
    {
        private int numerator;
        private int denomiator; 

        public FractionClass()
        {
           numerator = 0; 
            denomiator = 1; 
        }

        public FractionClass(int num, int den)
        {
            numerator = num; 
            denomiator = den; 
        }

        public int Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
            }
        }

        public int Denominator
        {
            get
            {
                return denomiator;
            }
            set
            {
                denomiator = value;
            }
        }

        public bool Equals(decimal numAnswer, decimal denAnswer)
        {
            if (numerator == Convert.ToInt32(numAnswer) && denomiator == Convert.ToInt32(denAnswer))
                return true;
            else
                return false; 
        }

        public FractionClass Add(FractionClass other)
        {
            int num = numerator;
            int den = denomiator;
            if (den == other.Denominator)
            {
                num += other.Numerator; 
            }
            else
            {
                num = (num * other.Denominator) + (other.Numerator * den);
                den *= other.Denominator;
            }

            int gcd = GCD(num, den); 
            try
            {
                num = num / gcd;
                den = den / gcd;
            }
            catch(Exception ex)
            {
            }

            return new FractionClass(num, den);
        }

        public FractionClass Suubtract(FractionClass other)
        {
            int num = numerator;
            int den = denomiator;
            if (den == other.Denominator)
            {
                num -= other.Numerator;
            }
            else
            {
                num = (num * other.Denominator) - (other.Numerator * den);
                den *= other.Denominator;
            }

            int gcd = GCD(num, den);
            try
            {
                num = num / gcd;
                den = den / gcd;
            }
            catch (Exception ex)
            {
            }
            return new FractionClass(num, den);
        }

        public FractionClass Multiply(FractionClass other)
        {
            int num = numerator*other.Numerator;
            int den = denomiator*other.Denominator;

            int gcd = GCD(num, den);
            try
            {
                num = num / gcd;
                den = den / gcd;
            }
            catch (Exception ex)
            {
            }
            return new FractionClass(num, den); 
        }

        public FractionClass Divide(FractionClass other)
        {
           int num = numerator * other.Denominator;
           int den = denomiator * other.Numerator;

           int gcd = GCD(num, den);
           try
           {
               num = num / gcd;
               den = den / gcd;
           }
           catch (Exception ex)
           {
           }
           return new FractionClass(num, den);
        }

        public int GCD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return GCD(b, a % b);
            }
        }

    }
}
