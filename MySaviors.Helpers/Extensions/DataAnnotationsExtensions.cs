﻿using System.ComponentModel;

namespace MySaviors.Helpers.Extensions
{
    public static class DataAnnotationsExtensions
    {
        public static string Description(this Enum enumerador)
        {
            var fi = enumerador.GetType().GetField(enumerador.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }

            return enumerador.ToString();
        }

        public static string Description(this Type _class)
        {
            var attr = _class.GetCustomAttributes(typeof(DescriptionAttribute), false)
                             .FirstOrDefault()
                             as DescriptionAttribute;

            return attr.Description;
        }

        public static string AttributeDescription(this Type _class, string propertyName)
        {
            DescriptionAttribute result = null;

            var propertyInfos = _class.GetProperties();

            var propertyInfo = propertyInfos.FirstOrDefault(f => f?.Name == propertyName);

            result = propertyInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

            return result.Description;
        }
    }
}
