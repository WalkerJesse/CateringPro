using System.Reflection;

namespace CateringPro.Application.Infrastructure
{

    public class AssemblyUtility
    {

        #region - - - - - - Methods - - - - - -

        public static Assembly GetAssembly() => typeof(AssemblyUtility).Assembly;

        #endregion Methods

    }

}
