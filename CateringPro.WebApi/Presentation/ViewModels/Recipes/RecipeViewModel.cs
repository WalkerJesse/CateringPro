using CateringPro.WebApi.Presentation.ViewModels.RecipeIngredients;
using System.Collections.Generic;

namespace CateringPro.WebApi.Presentation.ViewModels.Recipes
{

    /// <summary>
    /// The View Model for a Recipe.
    /// </summary>
    public class RecipeViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The Ingredients of the Recipe.
        /// </summary>
        public List<RecipeIngredientViewModel> Ingredients { get; set; }

        /// <summary>
        /// The ID of the Recipe.
        /// </summary>
        public long RecipeID { get; set; }

        /// <summary>
        /// The Name of the Recipe.
        /// </summary>
        public string RecipeName { get; set; }

        #endregion Properties

    }

}
