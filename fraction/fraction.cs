namespace ConsoleApp4
{
    class fraction
    {
        public fraction() { }
        public fraction(Int32 dividend , Int32 divider)
        {
            this.dividend = dividend * (divider >= 0 ? 1 : -1);
            this.divider = divider * (divider >= 0 ? 1 : -1);
        }

        public static fraction operator +(fraction A, fraction B)
        {
            if (A.divider == B.divider) return new fraction(A.dividend + B.dividend, A.divider);
            else if (A.divider % B.divider == 0 || B.divider % A.divider == 0)
            {
                return new fraction(A.dividend * (B.divider / A.divider == 0 ? 1 : B.divider / A.divider) +
                                   B.dividend * (A.divider / B.divider == 0 ? 1 : A.divider / B.divider), (A.divider > B.divider ? A.divider : B.divider));
            }
            return new fraction(A.dividend * B.divider + B.dividend * A.divider, A.divider * B.divider);
        }
        public static fraction operator -(fraction A, fraction B)
        {
            if (A.divider == B.divider) return new fraction(A.dividend - B.dividend, A.divider);
            else if (A.divider % B.divider == 0 || B.divider % A.divider == 0)
            {
                return new fraction(A.dividend * (B.divider / A.divider == 0 ? 1 : B.divider / A.divider) -
                                   B.dividend * (A.divider / B.divider == 0 ? 1 : A.divider / B.divider), (A.divider > B.divider ? A.divider : B.divider));
            }
            return new fraction(A.dividend * B.divider - B.dividend * A.divider , A.divider * B.divider);
        }
        public static fraction operator *(fraction A, fraction B) => new fraction(A.dividend * B.dividend , A.divider * B.divider);
        public static fraction operator /(fraction A, fraction B) => new fraction(A.dividend * B.divider , A.divider * B.dividend);
        public static bool operator >(fraction A, fraction B) => ((Single)A.dividend / (Single)A.divider > B.dividend / (Single)B.divider);
        public static bool operator <(fraction A, fraction B) => ((Single)A.dividend / (Single)A.divider < B.dividend / (Single)B.divider);
        public static bool operator ==(fraction A, fraction B) => ((Single)A.dividend / (Single)A.divider == B.dividend / (Single)B.divider);
        public static bool operator !=(fraction A, fraction B) => ((Single)A.dividend / (Single)A.divider != B.dividend / (Single)B.divider);

        public override bool Equals(object? obj) => obj is fraction fraction &&
                  (Single)this.dividend / (Single)this.divider == (Single)fraction.dividend / (Single)fraction.divider;
        public override string ToString() => $"({this.dividend/this.divider}) {this.dividend%this.divider}/{this.divider}";
        private Int32 dividend { get; } 
        private Int32 divider { get; }

    }
}
