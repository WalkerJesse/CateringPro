using CateringPro.Application.Services;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Infrastructure
{

    public class UseCaseInvoker : IUseCaseInvoker
    {

        #region - - - - - - Fields - - - - - -

        private readonly IServiceProvider m_ServiceProvider;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public UseCaseInvoker(IServiceProvider serviceProvider)
            => this.m_ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public async Task InvokeUseCaseAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>
        {
            var _RequestValidator = (IValidator<TRequest>)this.m_ServiceProvider.GetService(typeof(IValidator<TRequest>));
            if (_RequestValidator != null)
            {
                var _ValidationResult = await _RequestValidator.ValidateAsync(request, cancellationToken);
                if (!_ValidationResult.IsValid)
                {
                    await presenter.PresentValidationFailureAsync(_ValidationResult, cancellationToken);
                    return;
                }
            }

            var _BusinessRuleValidator = (IBusinessRuleValidator<TRequest>)this.m_ServiceProvider.GetService(typeof(IBusinessRuleValidator<TRequest>));
            if (_BusinessRuleValidator != null)
            {
                var _ValidationResult = await _BusinessRuleValidator.ValidateAsync(request, cancellationToken);
                if (!_ValidationResult.IsValid)
                {
                    await presenter.PresentValidationFailureAsync(_ValidationResult, cancellationToken);
                    return;
                }
            }

            var _UseCaseInteractor = (IUseCaseInteractor<TRequest, TResponse>)this.m_ServiceProvider.GetService(typeof(IUseCaseInteractor<TRequest, TResponse>));
            await _UseCaseInteractor.HandleAsync(request, presenter, cancellationToken);
        }

        #endregion Methods

    }

}
