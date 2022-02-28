using CleanArchitecture.Mediator;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInputPort : IUseCaseInputPort<IDeleteIngredientOutputPort>
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        #endregion Properties

    }

}
