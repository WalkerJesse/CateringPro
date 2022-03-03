using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
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

        public Task CreateIngredientAsync(CreateIngredientInputPort inputPort, ICreateIngredientOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public Task DeleteIngredientAsync(DeleteIngredientInputPort inputPort, IDeleteIngredientOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public Task GetIngredientsAsync(IGetIngredientsOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(new GetIngredientsInputPort(), outputPort, cancellationToken);

        public Task UpdateIngredientAsync(UpdateIngredientInputPort inputPort, IUpdateIngredientOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        #endregion Methods

    }

}
