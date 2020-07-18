using System;

namespace CateringPro.Application.Exceptions
{

    public class NotFoundException : Exception
    {

        #region - - - - - - Constructors - - - - - -

        public NotFoundException(string resourceName, object key) : base($"{resourceName} ({key}) was not found.") { }

        #endregion Constructors

    }

}
