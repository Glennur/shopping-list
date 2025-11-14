using ShoppingList.Application.Interfaces;
using ShoppingList.Application.Services;
using ShoppingList.Domain.Models;
using Xunit;

namespace ShoppingList.Tests;

/// <summary>
/// Unit tests for ShoppingListService.
///
/// IMPORTANT: Write your tests here using Test Driven Development (TDD)
///
/// TDD Workflow:
/// 1. Write a test for a specific behavior (RED - test fails)
/// 2. Implement minimal code to make the test pass (GREEN - test passes)
/// 3. Refactor the code if needed (REFACTOR - improve without changing behavior)
/// 4. Repeat for the next behavior
///
/// Test Examples:
/// - See ShoppingItemTests.cs for examples of well-structured unit tests
/// - Follow the Arrange-Act-Assert pattern
/// - Use descriptive test names: Method_Scenario_ExpectedBehavior
///
/// What to Test:
/// - Happy path scenarios (normal, expected usage)
/// - Input validation (null/empty IDs, invalid parameters)
/// - Edge cases (empty array, array expansion, last item, etc.)
/// - Array management (shifting after delete, compacting, reordering)
/// - Search functionality (case-insensitive, matching in name/notes)
///
/// Recommended Test Categories:
///
/// GetAll() tests:
/// - GetAll_WhenEmpty_ShouldReturnEmptyList
/// - GetAll_WithItems_ShouldReturnAllItems
/// - GetAll_ShouldNotReturnMoreThanActualItemCount
///
/// GetById() tests:
/// - GetById_WithValidId_ShouldReturnItem
/// - GetById_WithInvalidId_ShouldReturnNull
/// - GetById_WithNullId_ShouldReturnNull
/// - GetById_WithEmptyId_ShouldReturnNull
///
/// Add() tests:
/// - Add_WithValidInput_ShouldReturnItem
/// - Add_ShouldGenerateUniqueId
/// - Add_ShouldIncrementItemCount
/// - Add_WhenArrayFull_ShouldExpandArray
/// - Add_AfterArrayExpansion_ShouldContinueWorking
/// - Add_ShouldSetIsPurchasedToFalse
///
/// Update() tests:
/// - Update_WithValidId_ShouldUpdateAndReturnItem
/// - Update_WithInvalidId_ShouldReturnNull
/// - Update_ShouldNotChangeId
/// - Update_ShouldNotChangeIsPurchased
///
/// Delete() tests:
/// - Delete_WithValidId_ShouldReturnTrue
/// - Delete_WithInvalidId_ShouldReturnFalse
/// - Delete_ShouldRemoveItemFromList
/// - Delete_ShouldShiftRemainingItems
/// - Delete_ShouldDecrementItemCount
/// - Delete_LastItem_ShouldWork
/// - Delete_FirstItem_ShouldWork
/// - Delete_MiddleItem_ShouldWork
///
/// Search() tests:
/// - Search_WithEmptyQuery_ShouldReturnAllItems
/// - Search_WithNullQuery_ShouldReturnAllItems
/// - Search_MatchingName_ShouldReturnItem
/// - Search_MatchingNotes_ShouldReturnItem
/// - Search_ShouldBeCaseInsensitive
/// - Search_WithNoMatches_ShouldReturnEmpty
/// - Search_ShouldFindPartialMatches
///
/// ClearPurchased() tests:
/// - ClearPurchased_WithNoPurchasedItems_ShouldReturnZero
/// - ClearPurchased_ShouldRemoveOnlyPurchasedItems
/// - ClearPurchased_ShouldReturnCorrectCount
/// - ClearPurchased_ShouldShiftRemainingItems
///
/// TogglePurchased() tests:
/// - TogglePurchased_WithValidId_ShouldReturnTrue
/// - TogglePurchased_WithInvalidId_ShouldReturnFalse
/// - TogglePurchased_ShouldToggleFromFalseToTrue
/// - TogglePurchased_ShouldToggleFromTrueToFalse
///
/// Reorder() tests:
/// - Reorder_WithValidOrder_ShouldReturnTrue
/// - Reorder_WithInvalidId_ShouldReturnFalse
/// - Reorder_WithMissingIds_ShouldReturnFalse
/// - Reorder_WithDuplicateIds_ShouldReturnFalse
/// - Reorder_ShouldChangeItemOrder
/// - Reorder_WithEmptyList_ShouldReturnFalse
/// </summary>
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

