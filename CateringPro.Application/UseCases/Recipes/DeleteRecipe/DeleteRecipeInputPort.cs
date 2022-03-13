using CleanArchitecture.Mediator;

namespace CateringPro.Application.UseCases.Recipes.DeleteRecipe
{

    public class DeleteRecipeInputPort : IUseCaseInputPort<IDeleteRecipeOutputPort>
    {

        #region - - - - - - Properties - - - - - -

        public long RecipeID { get; set; }

        #endregion Properties

    }

}
