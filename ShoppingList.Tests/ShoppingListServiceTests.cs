using ShoppingList.Application.Interfaces;
using ShoppingList.Application.Services;
using ShoppingList.Domain.Models;
using Xunit;

namespace ShoppingList.Tests;

public class ShoppingListServiceTests
{
    [Fact]
    public void AddItem_ReturnAddedItem()
    {
        var service = new  ShoppingListService();
        var item = service.Add("Apples", 10, "Pink Lady");
        Assert.Equal("Apples", item.Name);
        Assert.Equal(10, item.Quantity);
        Assert.Equal("Pink Lady", item.Notes);
        Assert.False(item.IsPurchased);
    }
    [Fact]
    public void GetAll_ShouldReturnNullWhenArrayIsNotFull()
    {
        var service = new ShoppingListService();
        var expected = 10;
        var index = expected;
        for (int i = 0; i < expected; i++)
        {
            service.Add("Apples", 10, "Pink Lady");
        }
        var actual = service.GetAll().Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void GetShoppingItem_ById_ShouldRetunItem()
    {
        var service = new ShoppingListService();
        var milk = service.Add("Milk", 2, "Lactose-free");


        //Act
        var actual = service.GetById(milk.Id);
        
        //Assert
        Assert.Equal("Apples", milk.Name);
    }
    
    [Fact]
    public void GetById_WithValidId_ShouldReturnItem()
    {
        //Arrange
        var service = new ShoppingListService();
        var milk = service.Add("Milk", 2, "Lactose-free");


        //Act
        var actual = service.GetById(milk.Id);

        //Assert
        Assert.NotNull(actual);
        Assert.Equal(milk.Name, actual.Name);
        
    }
    
    
 /*   private void AddTestData(IShoppingListService service)
    {
        var items = new ShoppingItem[5];
        service.Add("Dishwasher tablets", 1, "80st/pack - Rea");
        service.Add("Ground meat", 1, "2kg - origin Sweden");
        service.Add("Apples", 10, "Pink Lady");
        service.Add("Toothpaste", 1, "Colgate");
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
        foreach (var item in items)
        {
            service.Add(item.Name, item.Id, item.Notes, item.IsPurchased);
        }
        //return items;
    }*/
 /*
    [Fact]
    public void GetShoppingItem_ById_ShouldReturnItem()
    {
        var sut = new ShoppingListService();
        var expected = TestItems().First();

        // Act
        var actual = sut.GetById(expected.Id);

        // Assert
        Assert.Equal(expected.Id, actual.Id);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Quantity, actual.Quantity);
        Assert.Equal(expected.Notes, actual.Notes);
        Assert.Equal(expected.IsPurchased, actual.IsPurchased);
    }
    */
    
    
    
    // TODO: Write your tests here following the TDD workflow

                                                                                                                                                                                                                                                                                                                                                                      // Example test structure:
                                                                                                                                                                                                                                                                                                                                                                        // [Fact]
    // public void Add_WithValidInput_ShouldReturnItem()
    // {
    //     // Arrange
    //     var service = new ShoppingListService();
    //
    //     // Act
    //     var item = service.Add("Milk", 2, "Lactose-free");
    //
    //     // Assert
    //     Assert.NotNull(item);
    //     Assert.Equal("Milk", item!.Name);
    //     Assert.Equal(2, item.Quantity);
    // }
}

