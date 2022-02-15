using CateringPro.Domain.Enumerations;

namespace CateringPro.Domain.Entities
{

    public class RecipeIngredient
    {

        #region - - - - - - Properties - - - - - -

        public Ingredient Ingredient { get; set; }

        public decimal Measurement { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public Recipe Recipe { get; set; }

        #endregion Properties

    }

}
