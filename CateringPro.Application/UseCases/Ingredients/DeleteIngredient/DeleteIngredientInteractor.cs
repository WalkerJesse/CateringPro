using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractor : IUseCaseInteractor<DeleteIngredientInputPort, IDeleteIngredientOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientInteractor(IPersistenceContext persistenceContext)
            => this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(DeleteIngredientInputPort inputPort, IDeleteIngredientOutputPort outputPort, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_PersistenceContext.Find<Ingredient>(new object[] { inputPort.IngredientID });

            if (_Ingredient == null)
                return outputPort.PresentIngredientNotFound(inputPort.IngredientID, cancellationToken);

            this.m_PersistenceContext.Remove(_Ingredient);

            return outputPort.PresentDeletedIngredientAsync(inputPort.IngredientID, cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
