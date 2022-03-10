using System;

namespace RomanNum
{
    public class RomanNumber:ICloneable, IComparable
    {
        protected ushort romanNum;
        public object Clone()
        {
            return new RomanNumber(romanNum);
        }
        public int CompareTo(object? obj)
        {
            if (obj is RomanNumber rom) return romanNum - ((RomanNumber)obj).romanNum;
            throw new RomanNumberException("Некоректное значение параметра");
        }
        public RomanNumber(ushort n)
        {
            if (n <= 0 || n > 3999)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            romanNum = n;
        }
        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Ошибка: параметр содержит значение null");
            if (n1.romanNum + n2.romanNum > 3999)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            return new RomanNumber((ushort)(n1.romanNum + n2.romanNum));
        }

        public static RomanNumber operator +(RomanNumber? n1, RomanNumber? n2)
        {
            return Add(n1, n2);
        }

        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Ошибка: параметр содержит значение null");
            if (n1.romanNum <= n2.romanNum)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            return new RomanNumber((ushort)(n1.romanNum - n2.romanNum));
        }

        public static RomanNumber operator -(RomanNumber? n1, RomanNumber? n2)
        {
            return Sub(n1, n2);
        }

        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Ошибка: параметр содержит значение null");
            if (n1.romanNum * n2.romanNum > 3999)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            return new RomanNumber((ushort)(n1.romanNum * n2.romanNum));
        }
        public static RomanNumber operator *(RomanNumber? n1, RomanNumber? n2)
        {
            return Mul(n1, n2);
        }

        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                throw new RomanNumberException("Ошибка: параметр содержит значение null");
            if (n2.romanNum <= 0)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            if (n1.romanNum / n2.romanNum == 0)
                throw new RomanNumberException("Ошибка: Выход за пределы допустимых значений");
            return new RomanNumber((ushort)(n1.romanNum / n2.romanNum));
        }

        public static RomanNumber operator /(RomanNumber? n1, RomanNumber? n2)
        {
            return Div(n1, n2);
        }

        public override string ToString()
        {
            string answer = "";
            string romanSymb = "IVXLCDM";
            int digit, rn = romanNum;
            for (int i = 0; i <= 3; i++)
            {
                digit = rn % 10;
                if (digit != 0)
                {
                    if (digit <= 3)
                        for (int j = 0; j < digit; j++)
                            answer = romanSymb[i * 2] + answer;
                    else if(digit == 4)
                    {
                        answer = romanSymb[i * 2 + 1] + answer;
                        answer = romanSymb[i * 2] + answer;
                    }
                    else if (digit == 9)
                    {
                        answer = romanSymb[i * 2 + 2] + answer;
                        answer = romanSymb[i * 2] + answer;
                    }
                    else
                    {
                        for (int j = 0; j < digit - 5; j++)
                            answer = romanSymb[i * 2] + answer;
                        answer = romanSymb[i * 2 + 1] + answer;
                    }
                }
                rn /= 10;
            }
            return answer;
        }

    }
}
