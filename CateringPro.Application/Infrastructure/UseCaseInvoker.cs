using CateringPro.Application.Services;
using CateringPro.Common.CodeContracts;
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
        {
            this.m_ServiceProvider = serviceProvider ?? throw CodeContract.ArgumentNullException(nameof(serviceProvider));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task InvokeUseCaseAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>
        {
            var _UseCaseInteractor = this.m_ServiceProvider.GetService(typeof(IUseCaseInteractor<TRequest, TResponse>));
            return ((IUseCaseInteractor<TRequest, TResponse>)_UseCaseInteractor).HandleAsync(request, presenter, cancellationToken);
        }

        public Task ValidateUseCaseAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>
        {
            var _UseCaseValidator = this.m_ServiceProvider.GetService(typeof(IUseCaseValidator<TRequest, TResponse>));
            return ((IUseCaseValidator<TRequest, TResponse>)_UseCaseValidator).HandleAsync(request, presenter, cancellationToken);
        }

        #endregion Methods

    }

}
