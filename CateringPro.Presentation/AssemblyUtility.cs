using System.Reflection;

namespace CateringPro.Presentation
{

    public class AssemblyUtility
    {

        #region - - - - - - Methods - - - - - -

        public static Assembly GetAssembly() => typeof(AssemblyUtility).Assembly;

        #endregion Methods

    }

}
