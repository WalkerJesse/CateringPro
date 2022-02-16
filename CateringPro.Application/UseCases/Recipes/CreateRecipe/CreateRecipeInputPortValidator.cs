using FluentValidation;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInputPortValidator : AbstractValidator<CreateRecipeInputPort>  // :  IUseCaseInputPortValidator<CreateIngredientInputPort,ValidationResult>
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeInputPortValidator()
            => _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();

        #endregion Constructors

    }

}
