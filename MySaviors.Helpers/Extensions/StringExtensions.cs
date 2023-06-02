using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace MySaviors.Helpers.Extensions
{
    public static class StringExtensions
    {
        private static readonly List<string> _booleanValidValues = new() { "0", "1" };

        public static string GetMd5(this string value)
        {
            var sBuilder = new StringBuilder();
            var md5Hash = MD5.Create();

            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));

            return sBuilder.ToString();
        }

        public static string RemoveSpecialCharacters(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
                result = Regex.Replace(value, @"[^0-9a-zA-Z]+", string.Empty);

            return result;
        }

        public static bool IsEmail(this string value)
        {
            string emailPattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            return Regex.IsMatch(value, emailPattern, RegexOptions.IgnoreCase);
        }

        public static bool IsBoolean(this string value)
            => !string.IsNullOrEmpty(value) && _booleanValidValues.Contains(value) || bool.TryParse(value, out _);

        public static bool IsNumeric(this string value)
            => decimal.TryParse(value, out _);

        public static bool IsNotNumeric(this string value)
            => !IsNumeric(value);

        public static string OnlyNumeric(this string value)
        {
            var result = string.Empty;

            if (!string.IsNullOrEmpty(value))
            {
                foreach (var chr in value)
                    if (Char.IsNumber(chr))
                        result = string.Concat(result, chr);
            }
            else
                result = "0";

            return result;
        }

        public static string TakeString(this string value, int length, bool returnAllFound = false)
        {
            var result = string.Empty;
            length = length < 0 ? 0 : length;

            if (!string.IsNullOrEmpty(value))
            {
                if ((value.Length >= length) || (returnAllFound))
                {
                    length = value.Length >= length ? length : value.Length;

                    result = value.Substring(0, length);
                }

            }

            return result;
        }

        public static string TakeString(this string value, int iniPosition, int length, bool returnAllFound = false)
        {
            var result = string.Empty;
            length = length < 0 ? 0 : length;

            if (!string.IsNullOrEmpty(value))
            {
                if ((value.Length >= iniPosition + length) || (returnAllFound))
                {
                    length = value.Length >= iniPosition + length ? length : value.Length - iniPosition;
                    length = length < 0 ? 0 : length;

                    result = value.Substring(iniPosition, length);
                }

            }

            return result;
        }

        public static string FillRightZeros(this string input, int length)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var sb = new StringBuilder();
                if (input.IndexOf(",").Equals(-1)) input += ",";
                sb.Append(input);
                var s = input.Split(',');
                sb.Append(string.Concat(Enumerable.Repeat("0", length)));

                input = sb.ToString();
            }

            return input;
        }

        public static string AddQueyString(this string url, string queryStringKey, string queryStringValue)
        {
            var queryString = (url.Split('?').Length > 1) ? "&" : "?";
            return ($"{url}{queryString}{queryStringKey}={queryStringValue}").Replace(" ", "%20");
        }

        public static IEnumerable<string> FromSpaceSeparatedString(this string input)
        {
            input = input.Trim();
            return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public static string CleanUrlPath(this string url)
        {
            if (String.IsNullOrWhiteSpace(url)) url = "/";

            if (url != "/" && url.EndsWith("/"))
            {
                url = url.Substring(0, url.Length - 1);
            }

            return url;
        }

        public static string AddQueryString(this string url, string query)
        {
            if (!url.Contains('?'))
            {
                url += "?";
            }
            else if (!url.EndsWith("&"))
            {
                url += "&";
            }

            return url + query;
        }


        public static string AddHashFragment(this string url, string query)
        {
            if (!url.Contains('#'))
                url += "#";

            return url + query;
        }

    }
}
