using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Services
{

    public class ControllerAction
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;
        private readonly IUseCaseInvoker m_UseCaseInvoker;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public ControllerAction(IMapper mapper, IPersistenceContext persistenceContext, IUseCaseInvoker useCaseInvoker)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
            this.m_UseCaseInvoker = useCaseInvoker ?? throw CodeContract.ArgumentNullException(nameof(useCaseInvoker));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public async Task<IActionResult> CreateAsync<TViewModel, TUseCaseRequest, TUseCaseResponse>(object command, CancellationToken cancellationToken) where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
        {
            var _Presenter = new CreateCommandPresenter<TUseCaseResponse, TViewModel>(this.m_Mapper);
            var _Request = this.m_Mapper.Map<TUseCaseRequest>(command);

            await this.m_UseCaseInvoker.ValidateUseCaseBusinessRulesAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.ValidateUseCaseAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.InvokeUseCaseAsync(_Request, _Presenter, cancellationToken);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(cancellationToken);

            return _Presenter.Result;
        }

        public async Task<IActionResult> ReadAsync<TViewModel, TUseCaseRequest, TUseCaseResponse>(object query, CancellationToken cancellationToken) where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
        {
            var _Presenter = new ReadQueryPresenter<TUseCaseResponse, TViewModel>(this.m_Mapper);
            var _Request = this.m_Mapper.Map<TUseCaseRequest>(query);

            await this.m_UseCaseInvoker.ValidateUseCaseBusinessRulesAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.ValidateUseCaseAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.InvokeUseCaseAsync(_Request, _Presenter, cancellationToken);

            return _Presenter.Result;
        }

        public async Task<IActionResult> UpdateAsync<TUseCaseRequest, TUseCaseResponse>(object command, Action<TUseCaseRequest> assignKeyAction, CancellationToken cancellationToken) where TUseCaseRequest : IUseCaseRequest<TUseCaseResponse>
        {
            var _Presenter = new UpdateCommandPresenter<TUseCaseResponse>(this.m_Mapper);
            var _Request = this.m_Mapper.Map<TUseCaseRequest>(command);

            assignKeyAction.Invoke(_Request);

            await this.m_UseCaseInvoker.ValidateUseCaseBusinessRulesAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.ValidateUseCaseAsync(_Request, _Presenter, cancellationToken);

            if (!_Presenter.ValidationError)
                await this.m_UseCaseInvoker.InvokeUseCaseAsync(_Request, _Presenter, cancellationToken);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(cancellationToken);

            return _Presenter.Result;
        }

        #endregion Methods

    }

}
