using CateringPro.Domain.Enumerations;
using MediatR;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientRequest : IRequest<CreateIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public MeasurementType MeasurementType { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
