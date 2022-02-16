using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Domain.Entities;

namespace CateringPro.Application.Infrastructure.Mappings
{

    public class DtoMappingProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public DtoMappingProfile()
        {
            _ = this.CreateMap<Ingredient, IngredientDto>()
                .ForMember(dest => dest.IngredientID, opts => opts.MapFrom(src => src.ID));
        }

        #endregion Constructors

    }

}
