using FluentValidation;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInputPortValidator : AbstractValidator<UpdateIngredientInputPort> // :  IUseCaseInputPortValidator<CreateIngredientInputPort,ValidationResult>
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientInputPortValidator()
            => _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();

        #endregion Constructors

    }

}
