using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using VkNet.Abstractions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;

namespace PSA.Test.VKAuth.Controllers
{

    [Authorize]
    public class VKFriendsController : Controller
    {

        private readonly IConfiguration _configuration;

        private readonly IVkApi _vkApi;

        public VKFriendsController(IVkApi vkApi, IConfiguration configuration)
        {
            _vkApi = vkApi;
            _configuration = configuration;
        }
        public  IActionResult Index()
        {
            var friends =   _vkApi.Friends.Get(new VkNet.Model.RequestParams.FriendsGetParams
            { Count = 5, UserId = Convert.ToInt64( User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value ), Order = FriendsOrder.Random, Fields = ProfileFields.City | ProfileFields.Domain 
            }, false);
            

            return View(friends);
        }

    }
}