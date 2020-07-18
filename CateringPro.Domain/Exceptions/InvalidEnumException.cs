using System;

namespace CateringPro.Domain.Exceptions
{

    public class InvalidEnumException : Exception
    {

        #region - - - - - - Constructors - - - - - -

        public InvalidEnumException(string resourceName) : base($"{resourceName} is not a valid enum.") { }

        #endregion Constructors

    }

}
