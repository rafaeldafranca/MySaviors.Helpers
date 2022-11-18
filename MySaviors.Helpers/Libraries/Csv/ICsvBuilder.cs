namespace MySaviors.Helpers.Libraries.Csv
{
    public interface ICsvBuilder<T> where T : class
    {
        string BuildCsvFromListOf(IEnumerable<T> data, bool includeHeader, char separator);
    }
}
