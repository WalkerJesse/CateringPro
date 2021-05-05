using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System;
using System.Threading;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeProfile()
        {
            _ = this.CreateMap<CreateRecipeRequest, Recipe>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore())
                    .ForMember(dest => dest.Ingredients, opts => opts.MapFrom(src => src.Ingredients))
                    .AfterMap((src, dest) => dest.Ingredients.ForEach(ri => ri.Recipe = dest));

            _ = this.CreateMap<Recipe, CreateRecipeResponse>()
                    .ForMember(dest => dest.RecipeID, opts => opts.MapFrom(src => new Func<long>(() => src.ID)))
                    .ForMember(dest => dest.RecipeName, opts => opts.MapFrom(src => src.Name));

            _ = this.CreateMap<RecipeIngredientDto, RecipeIngredient>()
                    .ForMember(dest => dest.ID, opts => opts.Ignore())
                    .ForMember(dest => dest.Ingredient, opts => opts.MapFrom<IngredientResolver>())
                    .ForMember(dest => dest.Recipe, opts => opts.Ignore());
        }

        #endregion Constructors

    }

    public class IngredientResolver : IValueResolver<RecipeIngredientDto, RecipeIngredient, Ingredient>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientResolver(IPersistenceContext persistenceContext)
        {
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IValueResolver Implementation - - - - - -

        public Ingredient Resolve(RecipeIngredientDto source, RecipeIngredient destination, Ingredient destMember, ResolutionContext context)
            => this.m_PersistenceContext.FindAsync<Ingredient>(new object[] { source.IngredientID }, CancellationToken.None).Result;

        #endregion IValueResolver Implementation

    }

}
