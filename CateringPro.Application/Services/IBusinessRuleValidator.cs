using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IBusinessRuleValidator<TRequest, TResponse>
    {

        Task ValidateAsync(TRequest request, IPresenter<TResponse> presenter, CancellationToken cancellationToken);

    }

}
