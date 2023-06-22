using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pragmatic.Client.MVC.Models;
using System.Diagnostics;
using Microsoft.Identity.Web;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.Identity.Web.Resource;
using Microsoft.Identity.Abstractions;

namespace Pragmatic.Client.MVC.Controllers
{
    [Authorize]
    //[AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")] // Must replace RequiredScope (see Blazor) or access tokens won't be refreshed
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class HomeController : Controller
    {
        //private readonly IDownstreamApi _downstreamWebApi;
        //private readonly APIOptions _apiOptions;
        //private readonly ILogger<HomeController> _logger;

        public HomeController(/*ILogger<HomeController> logger, IDownstreamApi downstreamWebApi, APIOptions apiOptions*/)
        {
            //_logger = logger;
            //_downstreamWebApi = downstreamWebApi;
            //_apiOptions = apiOptions;
        }

        public async Task<IActionResult> Index()
        {
            //using var response = await _downstreamWebApi
            //    .CallWebApiForUserAsync("DownstreamApi", 
            //        options =>
            //        {
            //            options.BaseUrl = _apiOptions.BaseAddress;
            //            options.RelativePath = "values"; // NB! "api/" is included in the default BaseAddress
            //        })
            //    .ConfigureAwait(false);
            
            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //    var apiResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //    ViewData["ApiResult"] = apiResult;
            //}
            //else
            //{
            //    var error = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            //    throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}: {error}");
            //};

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}