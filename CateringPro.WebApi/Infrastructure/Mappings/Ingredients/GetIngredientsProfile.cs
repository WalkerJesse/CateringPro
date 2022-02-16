using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.WebApi.Interface.Ingredients.Queries;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class GetIngredientsProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsProfile()
        {
            _ = this.CreateMap<IngredientDto, IngredientViewModel>();

            _ = this.CreateMap<GetIngredientsQuery, GetIngredientsRequest>();

            _ = this.CreateMap<IGetIngredientsOutputPort, IngredientsViewModel>();
        }

        #endregion Constructors

    }

}
