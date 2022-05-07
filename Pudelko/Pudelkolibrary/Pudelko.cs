using System.Collections;

namespace Pudelkolibrary
{


    public enum UnitOfMeasure
    {
        milimeter = 1,
        centimeter = 10,
        meter = 1000
    }

    public sealed class Pudelko : IFormattable, IEquatable<Pudelko>
    {
        private readonly double aa;
        private readonly double bb;
        private readonly double cc;

        public override string ToString()
        {
            return $"{String.Format("{0:0.000}", A)} m × {String.Format("{0:0.000}", B)} m × {String.Format("{0:0.000}", C)} m";
        }

        public Pudelko()
        {
            aa = 100;
            bb = 100;
            cc = 100;
        }
        public Pudelko(double a, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a * (double)unit < 1 || a * (double)unit > 10000) throw new ArgumentOutOfRangeException(); ;
            aa = (int)(a * (double)unit);
            bb = 100;
            cc = 100;
        }
        public Pudelko(double a, double b, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a * (double)unit < 1 || a * (double)unit > 10000) throw new ArgumentOutOfRangeException(); ;
            if (b * (double)unit < 1 || b * (double)unit > 10000) throw new ArgumentOutOfRangeException(); ;
            aa = (int)(a * (double)unit);
            bb = (int)(b * (double)unit);
            cc = 100;
        }
        public Pudelko(double a, double b, double c, UnitOfMeasure unit = UnitOfMeasure.meter)
        {
            if (a * (double)unit < 1 || a * (double)unit > 10000) throw new ArgumentOutOfRangeException();
            if (b * (double)unit < 1 || b * (double)unit > 10000) throw new ArgumentOutOfRangeException();
            if (c * (double)unit < 1 || c * (double)unit > 10000) throw new ArgumentOutOfRangeException();
            aa = (int)(a * (double)unit);
            bb = (int)(b * (double)unit);
            cc = (int)(c * (double)unit);
        }

        public double Pole
        {
            get { return Math.Round(A * B * 2 + A * C * 2 + B * C * 2, 6); }
        }
        public double Objetosc
        {
            get { return Math.Round(A * B * C, 9); }
        }
        public double A
        {
            get { return aa / 1000; }
        }
        public double B
        {
            get { return bb / 1000; }
        }
        public double C
        {
            get { return cc / 1000; }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return A;
                        case 1: return B;
                        case 2: return C;
                    default: throw new ArgumentOutOfRangeException(nameof(index));
                }
            }
        }

        public bool Equals(Pudelko? other)
        {
            if (other == null) return false;

            List<double> thisList = new List<double>() { A, B, C };
            List<double> otherList = new List<double>() { other.A, other.B, other.C };

            thisList.Sort();
            otherList.Sort();

            for (int i = 0; i < 3; i++)
            {
                if (thisList[i] != otherList[i]) return false;
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (!(obj is Pudelko)) return false;

            return Equals((Pudelko)obj);
        }

        public override int GetHashCode()
        {
            double[] doubles = new double[3] { A, B, C };
            return doubles.GetHashCode();
        }

        public static bool operator ==(Pudelko pLeft, Pudelko pRight)
        {
            return Equals(pLeft, pRight);
        }

        public static bool operator !=(Pudelko pLeft, Pudelko pRight)
        {
            return !(pLeft == pRight);
        }

        public static explicit operator double[](Pudelko p)
        {
            return new double[3] { p.A, p.B, p.C };
        }

        public static implicit operator Pudelko(ValueTuple<int, int, int> tuple)
        {
            return new Pudelko(tuple.Item1, tuple.Item2, tuple.Item3, UnitOfMeasure.milimeter);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            throw new NotImplementedException();
        }

        public string ToString(string? format)
        {
            if (format == null) format = "m";
            double multiplier;
            string stringFormat;
            switch (format)
            {
                case "mm": multiplier = 1000;
                        break;
                case "cm": multiplier = 100;
                    break;
                case "m": multiplier = 1;
                    break;
                default: throw new FormatException();
            }
            switch (format)
            {
                case "mm": stringFormat = "{0:0}";
                    break;
                case "cm": stringFormat = "{0:0.0}";
                    break;
                case "m": stringFormat = "{0:0.000}";
                    break;
                default: throw new FormatException();

            }
            return $"{String.Format(stringFormat, A * multiplier)} {format} × {String.Format(stringFormat, B * multiplier)} {format} × {String.Format(stringFormat, C * multiplier)} {format}";
        }
    }
}