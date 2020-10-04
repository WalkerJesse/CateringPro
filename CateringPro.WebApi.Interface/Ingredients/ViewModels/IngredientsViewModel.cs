using System.Collections.Generic;

namespace CateringPro.WebApi.Interface.Ingredients.ViewModels
{

    /// <summary>
    /// The View Model of Ingredients
    /// </summary>
    public class IngredientsViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// A List of Ingredients
        /// </summary>
        public List<IngredientViewModel> Ingredients { get; set; }

        #endregion Properties

    }

}
