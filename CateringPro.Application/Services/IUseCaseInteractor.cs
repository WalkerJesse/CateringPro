using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IUseCaseInteractor<TRequest, TResponse>
    {

        Task HandleAsync(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken);

    }

}
