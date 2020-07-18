using System;

namespace CateringPro.Application.Exceptions
{

    public class BusinessRuleViolationException : Exception
    {

        #region - - - - - - Constructors - - - - - -

        public BusinessRuleViolationException(string reason) : base(reason) { }

        #endregion Constructors

    }

}
