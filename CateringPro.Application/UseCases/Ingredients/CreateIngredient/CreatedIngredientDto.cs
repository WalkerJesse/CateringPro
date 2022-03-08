using System;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreatedIngredientDto
    {

        #region - - - - - - Properties - - - - - -

        public Func<long> IngredientID { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
