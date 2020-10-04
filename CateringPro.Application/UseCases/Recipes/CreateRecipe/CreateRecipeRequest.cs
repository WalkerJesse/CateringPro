using CateringPro.Application.Services;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeRequest : IUseCaseRequest<CreateRecipeResponse>
    {

        #region - - - - - - Properties - - - - - -

        public string Name { get; set; }

        #endregion Properties

    }

}
