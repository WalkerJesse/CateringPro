using AutoMapper;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientProfile()
            => _ = this.CreateMap<UpdateIngredientInputPort, Ingredient>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore());

        #endregion Constructors

    }

}
