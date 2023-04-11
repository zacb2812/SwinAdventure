using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestInventory
    {
        [Test()]
        public void TestFindItem()
        {
            Inventory inventory = new Inventory();
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            inventory.Put(shovel);
            Assert.IsTrue(inventory.HasItem("spade"));
        }

        [Test()]
        public void TestNoFindItem()
        {
            Inventory inventory = new Inventory();
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            inventory.Put(shovel);
            Assert.IsFalse(inventory.HasItem("book"));
        }

        [Test()]
        public void TestFetchItem()
        {
            Inventory inventory = new Inventory();
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            inventory.Put(shovel);
            Assert.AreEqual(shovel, inventory.Fetch("shovel"));
            Assert.IsTrue(inventory.HasItem("shovel"));
        }

        [Test()]
        public void TestTakeItem()
        {
            Inventory inventory = new Inventory();
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            inventory.Put(shovel);
            Assert.AreEqual(shovel, inventory.Take("shovel"));
            Assert.IsFalse(inventory.HasItem("shovel"));
        }

        [Test()]
        public void TestItemList()
        {
            Inventory inventory = new Inventory();
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            inventory.Put(shovel);
            inventory.Put(book);
            StringAssert.AreEqualIgnoringCase("a shovel (shovel)\na book (book)\n", inventory.ItemList);
        }
    }
}
