namespace CateringPro.WebApi.Presentation.ViewModels.RecipeIngredients
{

    /// <summary>
    /// The View Model for an Ingredient for a Recipe.
    /// </summary>
    public class RecipeIngredientViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The ID of the Ingredient.
        /// </summary>
        public long IngredientID { get; set; }

        /// <summary>
        /// The Measurement of the Ingredient.
        /// </summary>
        public decimal Measurement { get; set; }

        /// <summary>
        /// The Measurement Type of the Ingredient.
        /// </summary>
        public string MeasurementType { get; set; }

        #endregion Properties

    }

}
