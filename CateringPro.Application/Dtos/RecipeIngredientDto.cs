namespace CateringPro.Application.Dtos
{

    public class RecipeIngredientDto
    {

        #region - - - - - - Properties - - - - - -

        public IngredientDto Ingredient { get; set; }

        public decimal Measurement { get; set; }

        public MeasurementTypeDto MeasurementType { get; set; }

        public RecipeDto Recipe { get; set; }

        #endregion Properties
    }

}
