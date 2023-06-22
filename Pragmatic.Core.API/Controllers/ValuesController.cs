using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Pragmatic.Common.Entities;
using Pragmatic.Core.DAL.Repositories;
using System;

namespace Pragmatic.Core.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ValuesController : ControllerBase
    {
        List<ValueModel> valuesList;
        private readonly IValuesRepository repo;

        public ValuesController(IValuesRepository _repository)
        {
            valuesList = new List<ValueModel>();
            repo = _repository;
        }


        // GET: api/values
        [HttpGet]
        public async Task<List<ValueModel>> Get()
        {
            valuesList = await repo.GetValuesAsync();
            return valuesList;
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ValueModel> Get(int id)
        {
            return await repo.GetValueByIdAsync(id);
        }


        // POST api/values/create
        [HttpPost]
        public async Task<ValueModel> Post([FromBody] ValueModel value)
        {
            if (ModelState.IsValid)
            {
                value = await repo.CreateValueAsync(value);
            }
            return value;
        }

        //PUT api/values/edit/5
        [HttpPut("{id}")]
        public void Put(int Id, [FromBody] ValueModel model)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateValueAsync(model);
            }

        }

        //DELETE: api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            repo.DeleteValueByIdAsync(id);
        }


        ////GET: api/values/delete/5
        //// Named GET action used here as there is no delete extension method in the DownstreamWebApi interface that clients use. TOOD: Upgrade clients to use DownstreamApi interface.
        //[HttpGet("delete/{id}")]
        //public void Delete(int id)
        //{
        //    repo.DeleteValueByIdAsync(id);
        //}
    }
}

