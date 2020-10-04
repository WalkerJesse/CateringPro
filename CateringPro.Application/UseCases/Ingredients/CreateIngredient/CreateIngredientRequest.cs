using CateringPro.Application.Services;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientRequest : IUseCaseRequest<CreateIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public string Name { get; set; }

        #endregion Properties

    }

}
