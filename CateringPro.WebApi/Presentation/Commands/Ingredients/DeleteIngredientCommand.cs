using System.Text.Json.Serialization;

namespace CateringPro.WebApi.Presentation.Commands.Ingredients
{

    /// <summary>
    /// The Command to delete an Ingredient
    /// </summary>
    public class DeleteIngredientCommand
    {

        #region - - - - - - Properties - - - - - -

        [JsonIgnore]
        public long IngredientID { get; set; }

        #endregion Properties

    }

}
