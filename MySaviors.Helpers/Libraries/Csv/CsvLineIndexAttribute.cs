using System;

namespace MySaviors.Helpers.Libraries.Csv
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CsvLineIndexAttribute
        : Attribute
    {
        #region Variables

        public int Position;
        public string DataTransform = string.Empty;

        #endregion

        #region Constructors

        public CsvLineIndexAttribute() { }

        public CsvLineIndexAttribute(int position)
            => Position = position;

        public CsvLineIndexAttribute(int position, string dataTransform)
        {
            Position = position;
            DataTransform = dataTransform;
        }

        #endregion
    }
}
