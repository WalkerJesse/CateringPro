using CleanArchitecture.Services;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInputPort : IUseCaseInputPort<ICreateIngredientOutputPort>
    {

        #region - - - - - - Properties - - - - - -

        public string Name { get; set; }

        #endregion Properties

    }

}
