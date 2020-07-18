using System.Reflection;

namespace CateringPro.Infrastructure
{

    public class AssemblyUtility
    {

        #region - - - - - - Methods - - - - - -

        public static Assembly GetAssembly() => typeof(AssemblyUtility).Assembly;

        #endregion Methods

    }

}
