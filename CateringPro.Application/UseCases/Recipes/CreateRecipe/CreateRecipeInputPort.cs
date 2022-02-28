using CleanArchitecture.Mediator;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInputPort : IUseCaseInputPort<ICreateRecipeOutputPort>
    {

        #region - - - - - - Properties - - - - - -

        public string Name { get; set; }

        #endregion Properties

    }

}
