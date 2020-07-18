using System.Threading.Tasks;

namespace CateringPro.Application.Services.Pipeline
{

    public interface IBusinessRuleValidator<TRequest>
    {

        Task Evaluate(TRequest request);

    }

}
