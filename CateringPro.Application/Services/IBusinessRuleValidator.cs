using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IBusinessRuleValidator<TRequest>
    {

        Task<ValidationResult> ValidateAsync(TRequest request, CancellationToken cancellationToken);

    }

    public static class IBusinessRuleValidatorExtensions
    {

        #region - - - - - - Methods - - - - - -

        public static ValidationResult GetValidationFailureResult<TRequest>(this IBusinessRuleValidator<TRequest> businessRuleValidator, string errorMessage)
            => new ValidationResult(new[] { new ValidationFailure(string.Empty, errorMessage) });

        public static ValidationResult GetValidationFailureResult<TRequest>(this IBusinessRuleValidator<TRequest> businessRuleValidator, string propertyName, string errorMessage)
            => new ValidationResult(new[] { new ValidationFailure(propertyName, errorMessage) });

        public static ValidationResult GetValidationSuccessResult<TRequest>(this IBusinessRuleValidator<TRequest> businessRuleValidator)
            => new ValidationResult();

        #endregion Methods

    }

}
