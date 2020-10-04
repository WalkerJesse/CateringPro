using CateringPro.Application.Services;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientRequest : IUseCaseRequest<UpdateIngredientResponse>
    {

        #region - - - - - - Properties - - - - - -

        public long ID { get; set; }

        public string Name { get; set; }

        #endregion Properties

    }

}
