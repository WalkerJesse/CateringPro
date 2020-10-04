namespace CateringPro.WebApi.Interface.Ingredients.ViewModels
{

    /// <summary>
    /// The View Model to Create an Ingredient
    /// </summary>
    public class IngredientViewModel
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The ID of the created Ingredient
        /// </summary>
        public long IngredientID { get; set; }

        /// <summary>
        /// The Name of the created Ingredient
        /// </summary>
        public string IngredientName { get; set; }

        #endregion Properties

    }

}
