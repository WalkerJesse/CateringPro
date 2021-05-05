using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Common.CodeContracts;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Services
{

    public abstract class Presenter<TResponse> : IPresenter<TResponse>
    {

        #region - - - - - - Fields - - - - - -

        protected readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public Presenter(IMapper mapper)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
        }

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public bool PresentedSuccessfully { get; set; }

        public IActionResult Result { get; set; }

        public bool ValidationError { get; set; }

        #endregion Properties

        #region - - - - - - Methods - - - - - -

        public abstract Task PresentAsync(TResponse response, CancellationToken cancellationToken);

        public Task PresentNotFoundAsync(EntityRequest entityRequest, CancellationToken cancellationToken)
        {
            this.ValidationError = true;
            this.Result = new NotFoundObjectResult(this.m_Mapper.Map<ValidationProblemDetails>(entityRequest));
            return Task.CompletedTask;
        }

        public Task PresentValidationFailureAsync(ValidationResult result, CancellationToken cancellationToken)
        {
            this.ValidationError = true;
            this.Result = new BadRequestObjectResult(this.m_Mapper.Map<ValidationProblemDetails>(result));
            return Task.CompletedTask;
        }

        #endregion Methods

    }

    public class CreateCommandPresenter<TResponse, TViewModel> : Presenter<TResponse>
    {

        public CreateCommandPresenter(IMapper mapper) : base(mapper)
        {
        }

        public override Task PresentAsync(TResponse response, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new LateCreatedResult<TViewModel>(string.Empty, () => this.m_Mapper.Map<TViewModel>(response));
            return Task.CompletedTask;
        }

        #region - - - - - - Nested Classes - - - - - -

        private class LateCreatedResult<TResult> : CreatedResult
        {

            #region - - - - - - Constructors - - - - - -

            public LateCreatedResult(string location, Func<TResult> resultFunc) : base(location, resultFunc)
            {
            }

            #endregion Constructors

            #region - - - - - - Methods - - - - - -

            public override Task ExecuteResultAsync(ActionContext context)
            {
                this.Value = ((Func<TResult>)this.Value).Invoke();

                return base.ExecuteResultAsync(context);
            }

            #endregion Methods

        }

        #endregion Nested Classes

    }

    public class ReadQueryPresenter<TResponse, TViewModel> : Presenter<TResponse>
    {

        public ReadQueryPresenter(IMapper mapper) : base(mapper)
        {
        }

        public override Task PresentAsync(TResponse response, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new OkObjectResult(this.m_Mapper.Map<TViewModel>(response));
            return Task.CompletedTask;
        }

    }

    public class UpdateCommandPresenter<TResponse> : Presenter<TResponse>
    {

        public UpdateCommandPresenter(IMapper mapper) : base(mapper)
        {
        }

        public override Task PresentAsync(TResponse response, CancellationToken cancellationToken)
        {
            this.PresentedSuccessfully = true;
            this.Result = new NoContentResult();
            return Task.CompletedTask;
        }

    }

}
