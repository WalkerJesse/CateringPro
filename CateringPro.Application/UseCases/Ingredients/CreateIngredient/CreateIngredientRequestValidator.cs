using FluentValidation;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientRequestValidator : AbstractValidator<CreateIngredientRequest>
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientRequestValidator()
        {
            _ = this.RuleFor(i => i.MeasurementType).NotEmpty();
            _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();
        }

        #endregion Constructors

    }

}
