using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Infrastructure.Pipeline
{

    public class RequestValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IEnumerable<IValidator<TRequest>> m_Validators;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RequestValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.m_Validators = validators;
        }

        #endregion Constructors

        #region - - - - - - IPipelineBehavior Implementation - - - - - -

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var _ValidationContext = new ValidationContext(request);

            var _Failures = this.m_Validators
                .Select(v => v.Validate(_ValidationContext))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (_Failures.Any()) throw new ValidationException(_Failures);

            return next();
        }

        #endregion IPipelineBehavior Implementation

    }

}
