namespace CateringPro.WebApi.Interface.Ingredients.Commands
{

    /// <summary>
    /// The Command to create an Ingredient
    /// </summary>
    public class CreateIngredientCommand
    {

        #region - - - - - - Properties - - - - - -

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
