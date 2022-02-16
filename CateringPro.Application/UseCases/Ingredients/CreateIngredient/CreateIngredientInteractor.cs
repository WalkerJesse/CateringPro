using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInteractor : IUseCaseInteractor<CreateIngredientInputPort, ICreateIngredientOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task HandleAsync(CreateIngredientInputPort inputPort, ICreateIngredientOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_Mapper.Map<Ingredient>(inputPort);

            this.m_PersistenceContext.Add(_Ingredient);

            return outputPort.PresentIngredientAsync(this.m_Mapper.Map<CreatedIngredientDto>(_Ingredient), cancellationToken);
        }

        #endregion Methods

    }

}
