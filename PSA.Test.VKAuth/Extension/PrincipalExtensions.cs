using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using static AspNet.Security.OAuth.Vkontakte.VkontakteAuthenticationConstants;

namespace PSA.Test.VKAuth.Extension
{
    public static class PrincipalExtensions
    {
      
            public static string GetFullName(this ClaimsPrincipal user)
            {
                var giveName =user.FindFirst(ClaimTypes.GivenName).Value;
                var lastName = user.FindFirst(ClaimTypes.Surname).Value;
                return giveName == null && lastName == null? null : string.Format("{0} {1}",giveName,lastName);
            }
            public static string GetThumbnail(this ClaimsPrincipal user)
            {
                var claim = ((ClaimsIdentity)user.Identity).FindFirst(Claims.ThumbnailUrl);
                return claim == null ? null : claim.Value;
            }
            
   
    }
}
