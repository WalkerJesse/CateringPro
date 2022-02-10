using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace CateringPro.WebApi.Infrastructure.ModelBinding
{

    public class BodyAndRouteModelBinderProvider : IModelBinderProvider
    {

        #region - - - - - - Fields - - - - - -

        private BodyModelBinderProvider m_BodyModelBinderProvider;
        private ComplexTypeModelBinderProvider m_ComplexTypeModelBinderProvider;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public BodyAndRouteModelBinderProvider(BodyModelBinderProvider bodyModelBinderProvider, ComplexTypeModelBinderProvider complexTypeModelBinderProvider)
        {
            this.m_BodyModelBinderProvider = bodyModelBinderProvider ?? throw new ArgumentNullException(nameof(bodyModelBinderProvider));
            this.m_ComplexTypeModelBinderProvider = complexTypeModelBinderProvider ?? throw new ArgumentNullException(nameof(complexTypeModelBinderProvider));
        }

        #endregion Constructors

        #region - - - - - - IModelBinderProvider Implementation - - - - - -

        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context?.BindingInfo?.BindingSource?.CanAcceptDataFrom(BodyAndRouteBindingSource.BodyAndRoute) ?? false)
                return new BodyAndRouteModelBinder(this.m_BodyModelBinderProvider.GetBinder(context), this.m_ComplexTypeModelBinderProvider.GetBinder(context));

            return null;
        }

        #endregion IModelBinderProvider Implementation

    }

}
