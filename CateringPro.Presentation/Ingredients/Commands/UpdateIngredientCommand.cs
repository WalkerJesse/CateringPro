namespace CateringPro.WebApi.Interface.Ingredients.Commands
{

    /// <summary>
    /// The Command to update an Ingredient
    /// </summary>
    public class UpdateIngredientCommand
    {

        #region - - - - - - Properties - - - - - -

        /// <summary>
        /// The ID the Ingredient
        /// </summary>
        public string IngredientID { get; set; }

        /// <summary>
        /// The type of Measurement the Ingredient uses
        /// </summary>
        public string MeasurementType { get; set; }

        /// <summary>
        /// The Name of the Ingredient
        /// </summary>
        public string Name { get; set; }

        #endregion Properties

    }

}
