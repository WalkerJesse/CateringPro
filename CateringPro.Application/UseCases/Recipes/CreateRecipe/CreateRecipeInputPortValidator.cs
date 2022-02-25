using CateringPro.Application.Infrastructure.Validation;
using FluentValidation;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInputPortValidator : BaseValidator<CreateRecipeInputPort>
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeInputPortValidator()
            => _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();

        #endregion Constructors

    }

}
