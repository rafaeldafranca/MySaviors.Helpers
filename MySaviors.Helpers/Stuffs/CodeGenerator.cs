using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySaviors.Helpers.Stuffs
{
    public class CodeGenerator
    {
        public static string Generate(int size, string prefix = "")
        {
            var random = new Random();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            if (size < 0)
                size = 0;

            var result = new string(
                Enumerable.Repeat(chars, size - prefix.Length)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());

            return prefix + result;
        }
    }
}
