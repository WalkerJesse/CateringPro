using System.Collections.Generic;

namespace CateringPro.Domain.Entities
{

    public class Recipe
    {

        #region - - - - - - Properties - - - - - -

        public long ID { get; set; }

        public ICollection<RecipeIngredient> Ingredients { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
