using System.Collections.Generic;

namespace CateringPro.Application.Dtos
{

    public class RecipeDto
    {

        #region - - - - - - Properties - - - - - -

        public long RecipeID { get; set; }

        public List<RecipeIngredientDto> Ingredients { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
