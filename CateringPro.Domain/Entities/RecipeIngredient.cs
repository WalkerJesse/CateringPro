using CateringPro.Domain.Enumerations;

namespace CateringPro.Domain.Entities
{

    public class RecipeIngredient
    {

        #region - - - - - - Properties - - - - - -

        public long ID { get; set; }

        public int Measurement { get; set; }

        public Ingredient Ingredient { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public Recipe Recipe { get; set; }

        #endregion Properties

    }

}
