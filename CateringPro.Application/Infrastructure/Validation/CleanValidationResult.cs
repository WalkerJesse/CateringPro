using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Collections.Generic;

namespace CateringPro.Application.Infrastructure.Validation
{

    public class CleanValidationResult : ValidationResult, IValidationResult
    {

        #region - - - - - - Constructors - - - - - -

        public CleanValidationResult(IEnumerable<ValidationFailure> validationFailures) : base(validationFailures) { }

        public CleanValidationResult(ValidationResult validationResult) : base(validationResult.Errors) { }

        #endregion Constructors

    }

}
