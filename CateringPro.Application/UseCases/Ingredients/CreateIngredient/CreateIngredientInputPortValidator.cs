using FluentValidation;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInputPortValidator : AbstractValidator<CreateIngredientInputPort>
    {

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientInputPortValidator()
            => _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();

        #endregion Constructors

    }

}
