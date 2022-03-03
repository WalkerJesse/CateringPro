using System.Text.Json.Serialization;

namespace CateringPro.WebApi.Presentation.Commands.Ingredients
{

    /// <summary>
    /// The Command to update an Ingredient
    /// </summary>
    public class UpdateIngredientCommand
    {

        #region - - - - - - Properties - - - - - -

        [JsonIgnore]
        public long IngredientID { get; set; }

        /// <summary>
        /// The Name of the Ingredient
        /// </summary>
        public string Name { get; set; }

        #endregion Properties

    }

}
