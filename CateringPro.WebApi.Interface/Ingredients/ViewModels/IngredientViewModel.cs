namespace CateringPro.WebApi.Interface.Ingredients.ViewModels
{

    /// <summary>
    /// The View Model for an Ingredient
    /// </summary>
    public class IngredientViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The ID of the Ingredient
        /// </summary>
        public long IngredientID { get; set; }

        /// <summary>
        /// The Name of the Ingredient
        /// </summary>
        public string IngredientName { get; set; }

        #endregion Properties

    }

}
