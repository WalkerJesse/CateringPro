using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CateringPro.Common.Extensions
{

    public static class StringExtensions
    {

        #region - - - - - - Methods - - - - - -

        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static string ToDelimitedPascalCase(this string thisString, string delimiter)
        {
            if (thisString.IsNullOrWhiteSpace())
                return thisString;

            //Weird things happen if it does not begin with a capital letter
            if (!Regex.IsMatch(thisString, "^[A-Z]"))
                return thisString;

            var _Matches = Regex.Matches(thisString, "[A-Z][^A-Z]*")
                                .OfType<Match>()
                                .ToList();

            return _Matches.Any() ?
                _Matches.Select(x => x.Value.Trim()).ToSeperatorDelimited(delimiter) :
                thisString;
        }

        public static string ToSeperatorDelimited(this IEnumerable<string> strings, string seperator = ", ")
            => strings == null ? string.Empty : string.Join(seperator, strings);

        #endregion Methods

    }

}
