using ApiCosmosDB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCosmosDB.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICosmosDbService _cosmosDbService;
        public ItemController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<List<Item>> Index()
        {
            return (await _cosmosDbService.GetItemsAsync("SELECT * FROM c")).ToList();
        }

        [HttpPost]
        [Route("CreateMine")]
        public async Task Create(Item item)
        {
            await _cosmosDbService.AddItemAsync(item);
        }

        [HttpPost]
        [Route("Create")]
        public async Task CreateAsync([Bind("Id,Name,Description,Completed")] Item item)
        {
           
                item.Id = Guid.NewGuid().ToString();
                await _cosmosDbService.AddItemAsync(item);
            
        }

        //[HttpPost]
        //[Route("Edit")]
        //public async Task<ActionResult> EditAsync([Bind("Id,Name,Description,Completed")] Item item)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await _cosmosDbService.UpdateItemAsync(item.Id, item);
        //        return RedirectToAction("Index");
        //    }

        //    return View(item);
        //}

        //[ActionName("Edit")]
        //public async Task<ActionResult> EditAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await _cosmosDbService.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[ActionName("Delete")]
        //public async Task<ActionResult> DeleteAsync(string id)
        //{
        //    if (id == null)
        //    {
        //        return BadRequest();
        //    }

        //    Item item = await _cosmosDbService.GetItemAsync(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(item);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //public async Task<ActionResult> DeleteConfirmedAsync([Bind("Id")] string id)
        //{
        //    await _cosmosDbService.DeleteItemAsync(id);
        //    return RedirectToAction("Index");
        //}

        //[ActionName("Details")]
        //public async Task<ActionResult> DetailsAsync(string id)
        //{
        //    return View(await _cosmosDbService.GetItemAsync(id));
        //}
    }
}
