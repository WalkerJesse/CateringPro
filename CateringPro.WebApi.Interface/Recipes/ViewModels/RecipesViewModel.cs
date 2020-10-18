using System.Collections.Generic;

namespace CateringPro.WebApi.Interface.Recipes.ViewModels
{

    /// <summary>
    /// The View Model for Recipes
    /// </summary>
    public class RecipesViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// A List of Recipes
        /// </summary>
        public List<RecipeViewModel> Recipes { get; set; }

        #endregion Properties

    }

}
