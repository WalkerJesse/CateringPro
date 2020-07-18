using System;

namespace CateringPro.Common.CodeContracts
{

    public class StringIsEmptyException : ArgumentException
    {

        #region - - - - - - Constructors - - - - - -

        public StringIsEmptyException(string paramName) : base($"{paramName} cannot be String.Empty.", paramName) { }

        #endregion Constructors

    }

}
