﻿using CateringPro.Application.Infrastructure.Authorisation;
using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public interface ICreateIngredientOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<ValidationResult> // IUseCaseInputPortValidator<ValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientAsync(CreatedIngredientDto ingredient, CancellationToken cancellationToken);

        #endregion Methods

    }

}
