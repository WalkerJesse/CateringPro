using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInteractor : IUseCaseInteractor<CreateRecipeInputPort, ICreateRecipeOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(CreateRecipeInputPort inputPort, ICreateRecipeOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Recipe = this.m_Mapper.Map<Recipe>(inputPort);

            this.m_PersistenceContext.Add(_Recipe);

            return outputPort.PresentRecipeAsync(this.m_Mapper.Map<CreatedRecipeDto>(_Recipe), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
