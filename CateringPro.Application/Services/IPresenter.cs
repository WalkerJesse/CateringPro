using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services
{

    public interface IPresenter<TResponse>
    {

        Task PresentAsync(TResponse response, CancellationToken cancellationToken);

        Task PresentNotFoundAsync(EntityRequest entityRequest, CancellationToken cancellationToken);

        Task PresentValidationFailureAsync(ValidationResult result, CancellationToken cancellationToken);

    }

    public class EntityRequest
    {

        public List<(string PropertyName, object Value)> Keys { get; set; }

        public static EntityRequest GetEntityRequest(string propertyName, object value)
            => new EntityRequest() { Keys = new List<(string PropertyName, object Value)> { (propertyName, value) } };

    }

}
