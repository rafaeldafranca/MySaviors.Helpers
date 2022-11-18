namespace MySaviors.Helpers.Extensions
{
    public static class EnumExtensions
    {
        public static TEnum ParseExact<TEnum>(this TEnum source, string value, TEnum defaultValue = default)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            if (Enum.IsDefined(typeof(TEnum), value.IsNumeric() ? int.Parse(value) : value))
            {
                source = (TEnum)Enum.Parse(typeof(TEnum), value);

                return source;
            }

            return defaultValue;
        }

        public static List<TEnum> ToList<TEnum>(this TEnum source)
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            var result = new List<TEnum>();

            foreach (TEnum element in Enum.GetValues(typeof(TEnum)))
                result.Add(element);

            return result;
        }
    }
}
