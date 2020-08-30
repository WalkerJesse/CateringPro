using FluentValidation;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientRequestValidator : AbstractValidator<UpdateIngredientRequest>
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientRequestValidator()
        {
            _ = this.RuleFor(i => i.MeasurementType).NotEmpty();
            _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();
        }

        #endregion Constructors

    }

}
