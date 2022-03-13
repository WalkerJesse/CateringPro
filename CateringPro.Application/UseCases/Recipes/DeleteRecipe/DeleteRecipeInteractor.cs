using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.DeleteRecipe
{

    public class DeleteRecipeInteractor : IUseCaseInteractor<DeleteRecipeInputPort, IDeleteRecipeOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteRecipeInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(DeleteRecipeInputPort inputPort, IDeleteRecipeOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Recipe = this.m_PersistenceContext.Find<Recipe>(new object[] { inputPort.RecipeID });

            if (_Recipe == null)
                return outputPort.PresentRecipeNotFound(inputPort.RecipeID, cancellationToken);

            this.m_PersistenceContext.Remove(_Recipe);

            return outputPort.PresentDeletedRecipeAsync(this.m_Mapper.Map<RecipeDto>(_Recipe), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
