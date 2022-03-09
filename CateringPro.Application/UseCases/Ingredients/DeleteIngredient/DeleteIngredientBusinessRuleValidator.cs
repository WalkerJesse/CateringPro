using CateringPro.Application.Infrastructure.Validation;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Mediator;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientBusinessRuleValidator : IUseCaseBusinessRuleValidator<DeleteIngredientInputPort, CleanValidationResult>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientBusinessRuleValidator(IPersistenceContext persistenceContext)
            => this.m_PersistenceContext = persistenceContext ?? throw new System.ArgumentNullException(nameof(persistenceContext));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task<CleanValidationResult> ValidateAsync(DeleteIngredientInputPort inputPort, CancellationToken cancellationToken)
        => this.m_PersistenceContext.GetEntities<RecipeIngredient>().Where(ri => ri.Ingredient.ID == inputPort.IngredientID).Any()
            ? Task.FromResult(new CleanValidationResult(new List<ValidationFailure>() { new ValidationFailure(string.Empty, "You cannot delete an Ingredient that is being used by a recipe.") }))
            : Task.FromResult(new CleanValidationResult(new List<ValidationFailure>()));

        #endregion Methods

    }

}
