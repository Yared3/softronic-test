using Api.Models;

namespace Api.Domain;

public class ItemsService : IItemsService
{
    private readonly IHttpClientFactory _factory;

    public ItemsService(IHttpClientFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<ItemDto>> GetItems()
    {
        var client = _factory.CreateClient("item");
        var items = await client.GetFromJsonAsync<IEnumerable<ItemDto>>("/api/fetch");
        return items is null ? new List<ItemDto>() : items;
    }

    public async Task<IEnumerable<ItemDto>> GetSelectedItems(string[] selectedItems)
    {
        var items = await GetItems();
        items = items.Where(item => selectedItems.Contains(item.Id));
        return items;
    }
}
