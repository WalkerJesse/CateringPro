namespace CateringPro.Application.Extensions
{

    public static class StringExtensions
    {

        #region - - - - - - Methods - - - - - -

        public static bool IsNullOrEmpty(this string value)
            => string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace(this string value)
            => string.IsNullOrWhiteSpace(value);

        #endregion Methods

    }

}
