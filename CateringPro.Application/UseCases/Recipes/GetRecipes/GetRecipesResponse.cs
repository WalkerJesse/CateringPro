using System.Collections.Generic;

namespace CateringPro.Application.UseCases.Recipes.GetRecipes
{

    public class GetRecipesResponse
    {

        #region - - - - - - Properties - - - - - -

        public List<RecipeDto> Recipes { get; set; }

        #endregion Properties

    }

    public class RecipeDto
    {

        #region - - - - - - Properties - - - - - -

        public long RecipeID { get; set; }

        public string RecipeName { get; set; }

        #endregion Properties

    }

}
