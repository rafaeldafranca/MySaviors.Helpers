using MySaviors.Helpers.Extensions;

namespace MySaviors.Helpers.Types
{
    public struct Cep
    {
        #region Atributes
        private const string formatType = @"00\.000\-00";
        public string FormatedValue { get; }
        public string OriginalValue { get; }
        public long NumericValue { get; }
        public string Value { get; }

        #endregion

        #region Constructors

        public Cep(long value)
            : this()
        {
            this.OriginalValue = value.ToString();

            if (this.IsValid())
            {
                this.Value = this.OriginalValue;

                this.FormatedValue = long.Parse(this.Value).ToString(formatType);

                this.NumericValue = value;
            }
        }

        public Cep(string value)
            : this()
        {
            this.OriginalValue = value;

            if (this.IsValid())
            {
                this.Value = this.OriginalValue.OnlyNumeric();

                this.FormatedValue = long.Parse(this.Value).ToString(formatType);

                this.NumericValue = long.Parse(this.Value);
            }
        }

        #endregion

        #region Operators

        public static implicit operator Cep(string value)
            => new Cep(value);

        public static implicit operator Cep(long value)
            => new Cep(value);

        #endregion

        #region Methods

        public bool IsEmpty()
            => 0.Equals(this.Value);

        public bool IsNull()
            => string.IsNullOrEmpty(this.Value);
        public bool IsValid()
           => IsValid(this.OriginalValue);

        #endregion

        #region Static Methods

        public static bool IsValid(string value)
        {
            return (value.OnlyNumeric().Count() == 8);
        }

        #endregion

    }
}
