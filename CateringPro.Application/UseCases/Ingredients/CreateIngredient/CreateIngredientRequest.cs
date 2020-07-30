using CateringPro.Application.Services;
using CateringPro.Domain.Enumerations;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientRequest : IUseCaseRequest<CreateIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public MeasurementType MeasurementType { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
