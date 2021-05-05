using System;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientResponse
    {

        #region - - - - - - Properties - - - - - -

        public Func<long> IngredientID { get; set; }

        public string IngredientName { get; set; }

        #endregion Properties

    }

}
