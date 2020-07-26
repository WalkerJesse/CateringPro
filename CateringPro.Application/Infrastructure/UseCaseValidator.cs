using CateringPro.Application.Services;
using CateringPro.Common.CodeContracts;
using FluentValidation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Infrastructure
{

    public class UseCaseValidator<TRequest, TResponse> : IUseCaseValidator<TRequest, TResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IValidator<TRequest> m_RequestValidator;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public UseCaseValidator(IValidator<TRequest> requestValidator)
        {
            this.m_RequestValidator = requestValidator ?? throw CodeContract.ArgumentNullException(nameof(requestValidator));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseValidator Implementation - - - - - -

        public Task HandleAsync(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken)
        {
            var _ValidationResult = this.m_RequestValidator.Validate(request);

            if (_ValidationResult.Errors.Any())
                return presenter.PresentValidationFailureAsync(_ValidationResult, cancellationToken);

            return Task.CompletedTask;
        }

        #endregion IUseCaseValidator Implementation

    }

}
