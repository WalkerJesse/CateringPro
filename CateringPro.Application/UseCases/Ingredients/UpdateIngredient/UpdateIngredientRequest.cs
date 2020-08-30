using CateringPro.Application.Services;
using CateringPro.Domain.Enumerations;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientRequest : IUseCaseRequest<UpdateIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        public MeasurementType MeasurementType { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
