﻿using CleanArchitecture.Mediator.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace CateringPro.WebApi.Infrastructure.Authentication
{

    public class AuthenticatedClaimsPrincipalProvider : IAuthenticatedClaimsPrincipalProvider
    {

        #region - - - - - - Fields - - - - - -

        private readonly IHttpContextAccessor m_HttpContextAccessor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public AuthenticatedClaimsPrincipalProvider(IHttpContextAccessor httpContextAccessor)
            => this.m_HttpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));

        #endregion Constructors

        #region - - - - - - Properties - - - - - -

        public ClaimsPrincipal AuthenticatedClaimsPrincipal => this.m_HttpContextAccessor.HttpContext.User;

        #endregion Properties

    }

}
