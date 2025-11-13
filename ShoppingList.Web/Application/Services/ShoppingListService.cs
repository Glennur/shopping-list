using ShoppingList.Application.Interfaces;
using ShoppingList.Domain.Models;

namespace ShoppingList.Application.Services;

public class ShoppingListService : IShoppingListService
{
    private int _nextIndex;
    private ShoppingItem[] _items = new ShoppingItem[5];

    public ShoppingListService()
    {
        // Initialize with demo data for UI demonstration
        // TODO: Students can remove or comment this out when running unit tests
        
        //_items = GenerateDemoItems();
        _nextIndex = 0; // We have 4 demo items initialized
    }

    public IReadOnlyList<ShoppingItem> GetAll()
    {
        var list = new List<ShoppingItem>();
        for (int i = 0; i < _nextIndex; i++)
        {
            list.Add(_items[i]);
        }
        // TODO: Students - Return all items from the array (up to _nextIndex)
        return list;
    }

    public ShoppingItem? GetById(string id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item == null)
        {
            return null;
        }
        return item;
        // TODO: Students - Find and return the item with the matching id
    }

    public ShoppingItem? Add(string name, int quantity, string? notes)
    {
        var item = new ShoppingItem();
        item.Name = name;
        item.Quantity = quantity;
        if (_nextIndex >= _items.Length)
        {
            Array.Resize(ref  _items, _items.Length * 2);
        }
        item.Notes = notes;
        _items[_nextIndex] = item;
        _nextIndex++;
        
            
        // TODO: Students - Implement this method
        
        // Return the created item
        return item;
    }

    public ShoppingItem? Update(string id, string name, int quantity, string? notes)
    {
        // TODO: Students - Implement this method
        // Return the updated item, or null if not found
        return null;
    }

    public bool Delete(string id)
    {
        // TODO: Students - Implement this method
        // Return true if deleted, false if not found
        return false;
    }

    public IReadOnlyList<ShoppingItem> Search(string query)
    {
        // TODO: Students - Implement this method
        // Return the filtered items
        return [];
    }

    public int ClearPurchased()
    {
        // TODO: Students - Implement this method
        // 1. Count items where IsPurchased == true
        // 2. Create logic to remove all purchased items from array
        // 3. Shift remaining items and update _nextIndex
        // 4. Return the count of removed items
        return 0;
    }

    public bool TogglePurchased(string id)
    {
        // TODO: Students - Implement this method
        // 1. Find item by id
        // 2. Toggle IsPurchased property
        // 3. Return true if successful, false if item not found
        return false;
    }

    public bool Reorder(IReadOnlyList<string> orderedIds)
    {
        // TODO: Students - Implement this method
        // 1. Validate that orderedIds is not null or empty
        // 2. Validate that all ids in orderedIds exist in the array
        // 3. Validate that orderedIds contains all current items (no missing or duplicate ids)
        // 4. Reorder items in the array according to orderedIds
        // 5. Return true if successful, false otherwise
        return false;
    }
    
    

    private ShoppingItem[] GenerateDemoItems()
    {
        var items = new ShoppingItem[5];
        items[0] = new ShoppingItem
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Dishwasher tablets",    
            Quantity = 1,
            Notes = "80st/pack - Rea",
            IsPurchased = false
        };
        items[1] = new ShoppingItem
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Ground meat",
            Quantity = 1,
            Notes = "2kg - origin Sweden",
            IsPurchased = false
        };
        items[2] = new ShoppingItem
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Apples",
            Quantity = 10,
            Notes = "Pink Lady",
            IsPurchased = false
        };
        items[3] = new ShoppingItem
        {
            Id = Guid.NewGuid().ToString(),
            Name = "Toothpaste",
            Quantity = 1,
            Notes = "Colgate",
            IsPurchased = false
        };
        return items;
    }
}