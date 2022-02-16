using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractor : IUseCaseInteractor<DeleteIngredientInputPort, IDeleteIngredientOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(DeleteIngredientInputPort inputPort, IDeleteIngredientOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_PersistenceContext.FindAsync<Ingredient>(new object[] { inputPort.IngredientID }, cancellationToken);

            if (_Ingredient == null)
                return outputPort.PresentIngredientNotFound(inputPort.IngredientID, cancellationToken);

            this.m_PersistenceContext.RemoveAsync(_Ingredient);

            return outputPort.PresentDeletedIngredientAsync(this.m_Mapper.Map<IngredientDto>(_Ingredient), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
