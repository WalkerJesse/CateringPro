using CateringPro.Application.Services.Pipeline;
using CateringPro.Common.CodeContracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Infrastructure.Pipeline
{

    public class BusinessRuleValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IEnumerable<IBusinessRuleValidator<TRequest>> m_Validators;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public BusinessRuleValidationBehaviour(IEnumerable<IBusinessRuleValidator<TRequest>> validators)
        {
            this.m_Validators = validators ?? throw CodeContract.ArgumentNullException(nameof(validators));
        }

        #endregion Constructors

        #region - - - - - - IPipelineBehavior Implementation - - - - - -

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            Task.WaitAll(this.m_Validators.Select(p => p.Evaluate(request)).ToArray(), cancellationToken);

            return next();
        }

        #endregion IPipelineBehavior Implementation

    }

}
