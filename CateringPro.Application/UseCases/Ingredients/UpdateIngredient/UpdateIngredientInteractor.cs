using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInteractor : IUseCaseInteractor<UpdateIngredientInputPort, IUpdateIngredientOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(UpdateIngredientInputPort inputPort, IUpdateIngredientOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_PersistenceContext.Find<Ingredient>(new object[] { inputPort.IngredientID });

            if (_Ingredient == null)
                return outputPort.PresentIngredientNotFound(inputPort.IngredientID, cancellationToken);

            return outputPort.PresentIngredientAsync(this.m_Mapper.Map<IngredientDto>(this.m_Mapper.Map(inputPort, _Ingredient)), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
