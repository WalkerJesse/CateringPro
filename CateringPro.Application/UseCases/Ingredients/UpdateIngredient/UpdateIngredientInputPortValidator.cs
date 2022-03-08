using CateringPro.Application.Infrastructure.Validation;
using FluentValidation;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInputPortValidator : BaseValidator<UpdateIngredientInputPort>
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientInputPortValidator()
            => _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();

        #endregion Constructors

    }

}
