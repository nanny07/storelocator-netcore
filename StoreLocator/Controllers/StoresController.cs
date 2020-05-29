using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLocator.Models;
using StoreLocator.Services;

namespace StoreLocator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoreServices _storeService;

        public StoresController(StoreServices storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public ActionResult<IList<Store>> Get() => _storeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetStore")]
        public ActionResult<Store> Get(string id)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            return store;
        }

        [HttpPost]
        public ActionResult<Store> Create(Store store)
        {
            if(!string.IsNullOrEmpty(store.Id))
            {
                return BadRequest("Store Id is not null");
            }

            _storeService.Insert(store);

            return CreatedAtRoute("GetStore", new { id = store.Id.ToString() }, store);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Store storeInput)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storeService.Update(id, storeInput);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var store = _storeService.Get(id);

            if (store == null)
            {
                return NotFound();
            }

            _storeService.Delete(store.Id);

            return NoContent();
        }
    }
}
