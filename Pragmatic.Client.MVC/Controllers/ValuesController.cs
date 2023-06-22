using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Abstractions;
using Microsoft.Identity.Web;
using Pragmatic.Client.MVC.Models;
using System.Diagnostics;

namespace Pragmatic.Client.MVC.Controllers
{

    [Authorize]
    [AuthorizeForScopes(ScopeKeySection = "DownstreamApi:Scopes")] // Must replace RequiredScope or access tokens won't be refreshed
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ValuesController : Controller
    {
        private readonly IDownstreamApi _downstreamApi;
        private readonly APIOptions _apiOptions;
        //private readonly ITokenAcquisition _tokenAcquisition;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger, IDownstreamApi downstreamApi, APIOptions apiOptions/*, ITokenAcquisition tokenAcquisition*/)
        {
            _logger = logger;
            _downstreamApi = downstreamApi;
            _apiOptions = apiOptions;
            //_tokenAcquisition = tokenAcquisition;
        }

        // GET: values
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            //var accessToken = _tokenAcquisition.GetAccessTokenForUserAsync(new string[] { "AllAccess" });
            try
            {
                var apiResult = await _downstreamApi.GetForUserAsync<List<ValueModel>>("DownstreamApi", options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = "values";
                });

                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }

        }

        // GET: Values/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var apiResult = new ValueModel();
                apiResult = await _downstreamApi.GetForUserAsync<ValueModel>("DownstreamApi", options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = $"values/{id}";
                });
                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }
        }

        // GET: Values/Create
        [HttpGet]
        public ActionResult Create()
        {
            var model = new ValueModel
            {
                Name = "Value " + Guid.NewGuid().ToString()
            };
            return View(model);
        }

        // POST: Values/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ValueModel model)
        {
            try
            {
                var response = await _downstreamApi.PostForUserAsync<ValueModel, ValueModel>("DownstreamApi", model, options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = "values";
                });

                if (response != null)
                {
                    return RedirectToAction("Index", "Values");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }
        }

        // GET: Values/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var apiResult = await _downstreamApi.GetForUserAsync<ValueModel>("DownstreamApi", options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = $"values/{id}";
                });
                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }

        }


        // POST: Values/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, ValueModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _downstreamApi.PutForUserAsync<ValueModel>("DownstreamApi", model, options =>
                    {
                        options.BaseUrl = _apiOptions.BaseAddress;
                        options.RelativePath = $"values/{model.Id}";
                    });
                    return RedirectToAction("Index", "Values");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }

        }

        // GET: values/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var apiResult = new ValueModel();
                apiResult = await _downstreamApi.GetForUserAsync<ValueModel>("DownstreamApi", options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = $"values/{id}";
                });

                return View(apiResult);
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }
        }


        // POST: values/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, ValueModel model)
        {
            try
            {
                var result = _downstreamApi.DeleteForUserAsync<ValueModel>("DownstreamApi", model, options =>
                {
                    options.BaseUrl = _apiOptions.BaseAddress;
                    options.RelativePath = $"values/{id}";
                });

                return RedirectToAction("Index", "Values");
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorMessage = ex.Message });
            }

        }
    }
}
