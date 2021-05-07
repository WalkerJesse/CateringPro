using System.Text.Json.Serialization;

namespace CateringPro.WebApi.Interface.Ingredients.Commands
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
