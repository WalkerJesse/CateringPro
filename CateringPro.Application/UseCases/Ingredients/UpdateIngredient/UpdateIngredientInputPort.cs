using CleanArchitecture.Mediator;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInputPort : IUseCaseInputPort<IUpdateIngredientOutputPort>
    {

        #region - - - - - - Properties - - - - - -

        public long IngredientID { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
