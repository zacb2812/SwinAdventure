using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestPlayer
    {
        [Test()]
        public void TestPlayerIdentifiable()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Assert.IsTrue(p.AreYou("me"));
        }

        [Test()]
        public void TestPlayerLocateItems()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book", "novel" }, "a book", "This book is very long");
            p.Inventory.Put(shovel);
            p.Inventory.Put(book);
            Assert.AreEqual(book, p.Locate("book"));
        }

        [Test()]
        public void TestPlayerLocateItself()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Assert.AreEqual(p, p.Locate("inventory"));
        }

        [Test()]
        public void TestPlayerLocateNothing()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            p.Inventory.Put(shovel);
            p.Inventory.Put(book);
            Assert.AreNotEqual(shovel, p.Locate("club"));
        }

        [Test()]
        public void TestPlayerFullDescription()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            p.Inventory.Put(shovel);
            p.Inventory.Put(book);
            StringAssert.StartsWith("You are carrying:", p.FullDescription);
        }
    }
}