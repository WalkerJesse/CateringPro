using System;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeResponse
    {

        #region - - - - - - Properties - - - - - -

        public Func<long> RecipeID { get; set; }

        public string RecipeName { get; set; }

        #endregion Properties

    }

}
