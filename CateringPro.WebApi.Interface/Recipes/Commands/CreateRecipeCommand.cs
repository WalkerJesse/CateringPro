using CateringPro.WebApi.Interface.Recipes.ViewModels;
using System.Collections.Generic;

namespace CateringPro.WebApi.Interface.Recipes.Commands
{

    /// <summary>
    /// The Command to create an Recipe
    /// </summary>
    public class CreateRecipeCommand
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// A list of Ingredients to add to the Recipe
        /// </summary>
        public List<RecipeIngredientViewModel> Ingredients { get; set; }

        /// <summary>
        /// The Name of the Recipe
        /// </summary>
        public string Name { get; set; }

        #endregion Properties

    }

}
