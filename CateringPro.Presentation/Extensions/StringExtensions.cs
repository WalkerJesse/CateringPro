using FluentValidation;
using FluentValidation.Results;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CateringPro.Presentation.Extensions
{

    public static class StringExtensions
    {

        #region - - - - - - Methods - - - - - -

        public static bool IsNullOrWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value);

        public static string ScreamingSnakeCaseToTitleCase(this string thisString, string propertyName)
        {
            if (thisString.IsNullOrWhiteSpace())
                return thisString;

            if (!Regex.IsMatch(thisString, "^([A-Z]+_?)*[A-Z]$"))
                throw new ValidationException(new[] { new ValidationFailure(propertyName, "The value must be in SCREAMING_SNAKE_CASE") });

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(thisString.ToLower()).Replace("_", " ");
        }

        #endregion Methods

    }

}