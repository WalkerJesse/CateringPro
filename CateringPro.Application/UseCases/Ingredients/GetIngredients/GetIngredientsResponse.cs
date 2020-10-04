using System.Collections.Generic;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsResponse
    {

        #region - - - - - - Properties - - - - - -

        public List<IngredientDto> Ingredients { get; set; }

        #endregion Properties

    }

    public class IngredientDto
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        public string IngredientName { get; set; }

        #endregion Properties

    }

}
