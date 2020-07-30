using CateringPro.Domain.Enumerations;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientResponse
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        public string IngredientName { get; set; }

        public MeasurementType MeasurementType { get; set; }

        #endregion Properties

    }

}
