﻿using MySaviors.Helpers.Extensions;
using System.Text.RegularExpressions;

namespace MySaviors.Helpers.Types
{
    public struct Cpf
    {
        #region Atributes

        public string FormatedValue { get; }
        public string OriginalValue { get; }
        public long NumericValue { get; }
        public string Value { get; }

        #endregion

        #region Constructors

        public Cpf(long value)
            : this()
        {
            this.OriginalValue = value.ToString();

            if (this.IsValid())
            {
                this.Value = this.OriginalValue;

                this.FormatedValue = long.Parse(this.Value).ToString(@"000\.000\.000\-00");

                this.NumericValue = value;
            }
        }

        public Cpf(string value)
            : this()
        {
            this.OriginalValue = value;

            if (this.IsValid())
            {
                this.Value = this.OriginalValue.OnlyNumeric();

                this.FormatedValue = long.Parse(this.Value).ToString(@"000\.000\.000\-00");

                this.NumericValue = long.Parse(this.Value);
            }
        }

        #endregion

        #region Operators

        public static implicit operator Cpf(string value)
            => new Cpf(value);

        public static implicit operator Cpf(long value)
            => new Cpf(value);

        #endregion

        #region Methods

        public bool IsEmpty()
            => 0.Equals(this.Value);

        public bool IsNull()
            => string.IsNullOrEmpty(this.Value);
        public bool IsValid()
            => IsValid(this.OriginalValue);

        #endregion

        #region Static methods

        public static bool IsValid(string value)
        {
            var result = false;

            if (!string.IsNullOrEmpty(value))
            {
                var valueString = Regex.Replace(value, "[^0-9]+", "");

                if (!Regex.IsMatch(valueString, "(^0+$|^1+$|^2+$|^3+$|^4+$|^5+$|^6+$|^7+$|^8+$|^9+$)", RegexOptions.Multiline))
                {
                    if (valueString.Length == 11)
                    {
                        var cpf_array = new int[11];

                        for (int i = 0; i < 11; i++)
                        {
                            cpf_array[i] = int.Parse(valueString[i].ToString());
                        }

                        result = Validation(cpf_array);
                    }
                }
            }

            return result;
        }

        private static bool Validation(int[] a)
        {
            int x = 0;
            int result = 0;
            int sum = 0;
            int dgverif1 = 0;
            int dgverif2 = 0;
            bool valido = false;

            for (int i = 0, j = 10; i <= 8; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;

                sum += x;
            }

            result = sum % 11;

            if (result < 2)
            {
                dgverif1 = 0;
            }
            else
            {
                dgverif1 = (11 - result);
            }

            sum = 0;
            result = 0;
            x = 0;

            for (int i = 0, j = 11; i <= 9; i++, j--)
            {
                x = Convert.ToInt32(a[i]) * j;

                sum += x;
            }

            result = sum % 11;

            if (result < 2)
            {
                dgverif2 = 0;
            }
            else
            {
                dgverif2 = (11 - result);
            }

            valido = ((a[9] == dgverif1) && (a[10] == dgverif2));

            return valido;
        }

        #endregion
    }
}
