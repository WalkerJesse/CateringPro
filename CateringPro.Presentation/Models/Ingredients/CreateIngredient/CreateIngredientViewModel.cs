namespace CateringPro.Presentation.Models.Ingredients.CreateIngredient
{

    public class CreateIngredientViewModel
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

        /// <summary>
        /// The Name of the created Ingredient
        /// </summary>
        public string MeasurementType { get; set; }

        #endregion Properties

    }

}
