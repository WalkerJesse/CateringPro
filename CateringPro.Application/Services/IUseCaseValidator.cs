using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IUseCaseValidator<TRequest, TResponse>
    {

        Task HandleAsync(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken);

    }

}