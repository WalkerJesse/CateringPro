using System;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreatedRecipeDto
    {

        #region - - - - - - Properties - - - - - -

        public Func<long> RecipeID { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
