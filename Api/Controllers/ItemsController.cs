using Api.Domain;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("items")]
public class ItemsController : ControllerBase
{
    private readonly IItemsService _itemsService;

    public ItemsController(IItemsService itemsService)
    {
        _itemsService = itemsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ItemDto>>> Get()
    {
        var items = await _itemsService.GetItems();
        return Ok(items);
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<ItemDto>>> Post([FromForm]string[] items)
    {
        var response = await _itemsService.GetSelectedItems(items);
        return Ok(response);
    }
}