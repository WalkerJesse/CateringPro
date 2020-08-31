using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.WebApi.Interface.Ingredients.Commands;

namespace CateringPro.WebApi.Infrastructure.Mappings.Ingredients
{

    public class DeleteIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientProfile()
        {
            _ = this.CreateMap<DeleteIngredientCommand, DeleteIngredientRequest>()
                .ForMember(dest => dest.IngredientID, opts => opts.Ignore());
        }

        #endregion Constructors

    }

}
