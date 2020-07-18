using System;

namespace CateringPro.Common.CodeContracts
{

    public class ItemExpressionIsNullException : Exception
    {

        #region - - - - - - Constructors - - - - - -

        public ItemExpressionIsNullException() : base("Item Expression cannot be null.") { }

        #endregion Constructors

    }

}
