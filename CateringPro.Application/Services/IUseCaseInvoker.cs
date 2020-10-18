using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IUseCaseInvoker
    {

        Task InvokeUseCaseAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>;

        Task ValidateUseCaseAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>;

        Task ValidateUseCaseBusinessRulesAsync<TRequest, TResponse>(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken) where TRequest : IUseCaseRequest<TResponse>;

    }

}
