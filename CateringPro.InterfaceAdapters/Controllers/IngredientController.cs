using CleanArchitecture.Mediator;

namespace CateringPro.InterfaceAdapters.Controllers
{

    public class IngredientController
    {

        #region - - - - - - Fields - - - - - -

        private readonly IUseCaseInvoker m_UseCaseInvoker;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientController(IUseCaseInvoker useCaseInvoker)
            => this.m_UseCaseInvoker = useCaseInvoker ?? throw new ArgumentNullException(nameof(useCaseInvoker));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        //public Task

        #endregion Methods

    }

}
