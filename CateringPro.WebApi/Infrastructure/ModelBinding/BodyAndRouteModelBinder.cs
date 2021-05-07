using CateringPro.Common.CodeContracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Infrastructure.ModelBinding
{

    public class BodyAndRouteModelBinder : IModelBinder
    {

        #region - - - - - - Fields - - - - - -

        private readonly IModelBinder m_BodyBinder;
        private readonly IModelBinder m_ComplexBinder;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public BodyAndRouteModelBinder(IModelBinder bodyBinder, IModelBinder complexBinder)
        {
            this.m_BodyBinder = bodyBinder ?? throw CodeContract.ArgumentNullException(nameof(bodyBinder));
            this.m_ComplexBinder = complexBinder ?? throw CodeContract.ArgumentNullException(nameof(complexBinder));
        }

        #endregion Constructors

        #region - - - - - - IModelBinder Implementation - - - - - -

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            await this.m_BodyBinder.BindModelAsync(bindingContext);

            if (bindingContext.Result.IsModelSet)
                bindingContext.Model = bindingContext.Result.Model;

            await this.m_ComplexBinder.BindModelAsync(bindingContext);
        }

        #endregion IModelBinder Implementation

    }

}
