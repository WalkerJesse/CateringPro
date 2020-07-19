using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Common.CodeContracts;
using CateringPro.Presentation.Models.Ingredients.CreateIngredient;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Presentation.Controllers
{

    public class IngredientController
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IMediator m_Mediator;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientController(IMapper mapper, IMediator mediator, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
            this.m_Mediator = mediator ?? throw CodeContract.ArgumentNullException(nameof(mediator));
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public async Task<CreateIngredientViewModel> CreateIngredientAsync(CreateIngredientCommand command, CancellationToken cancellationToken)
        {
            var _Request = this.m_Mapper.Map<CreateIngredientRequest>(command);
            var _Response = await this.m_Mediator.Send(_Request, cancellationToken);

            return this.m_Mapper.Map<CreateIngredientViewModel>(_Response);
        }

        #endregion Methods

    }

}
