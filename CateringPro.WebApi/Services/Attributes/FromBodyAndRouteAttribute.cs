using CateringPro.WebApi.Infrastructure.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace CateringPro.WebApi.Services.Attributes
{

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromBodyAndRouteAttribute : Attribute, IBindingSourceMetadata
    {

        #region - - - - - - Properties - - - - - -

        public BindingSource BindingSource => BodyAndRouteBindingSource.BodyAndRoute;;

        #endregion Properties

    }

}
