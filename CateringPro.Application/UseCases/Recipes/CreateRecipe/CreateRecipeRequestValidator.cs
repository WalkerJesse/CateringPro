using FluentValidation;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeRequestValidator : AbstractValidator<CreateRecipeRequest>
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeRequestValidator()
        {
            _ = this.RuleFor(i => i.Name).MaximumLength(100).NotEmpty();
        }

        #endregion Constructors

    }

}
