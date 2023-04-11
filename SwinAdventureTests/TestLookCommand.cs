using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestLookCommand
    {
        [Test()]
        public void TestLookAtMe()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            p.Inventory.Put(shovel);
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Item book = new Item(new string[] { "book", "novel" }, "a book", "This book is very long");
            b.Inventory.Put(book);
            p.Inventory.Put(b);
            LookCommand command = new LookCommand();
            Assert.AreEqual("You are carrying: \na shovel (shovel)\nBag 1 (bag)\n", (command.Execute(p, new string[] { "look", "at", "me" })));
        }

        [Test()]
        public void TestLookAtGem()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
            p.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.AreEqual("A bright red gem", (command.Execute(p, new string[] { "look", "at", "gem" })));
        }

        [Test()]
        public void TestLookAtUnk()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            LookCommand command = new LookCommand();
            Assert.AreEqual("I cannot find gem in Player 1", (command.Execute(p, new string[] { "look", "at", "gem" })));
        }

        [Test()]
        public void TestLookAtGemInInventory()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
            p.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.AreEqual("A bright red gem", (command.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" })));
        }

        [Test()]
        public void TestLookAtGemInBag()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
            b.Inventory.Put(gem);
            p.Inventory.Put(b);
            LookCommand command = new LookCommand();
            Assert.AreEqual("A bright red gem", (command.Execute(p, new string[] { "look", "at", "gem", "in", "bag" })));
        }

        [Test()]
        public void TestLookAtGemInNoBag()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Item gem = new Item(new string[] { "gem" }, "a gem", "A bright red gem");
            p.Inventory.Put(gem);
            LookCommand command = new LookCommand();
            Assert.AreEqual("I cannot find the bag", (command.Execute(p, new string[] { "look", "at", "gem", "in", "bag" })));
        }

        [Test()]
        public void TestLookAtNoGemInBag()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            p.Inventory.Put(b);
            LookCommand command = new LookCommand();
            Assert.AreEqual("I cannot find gem in Bag 1", (command.Execute(p, new string[] { "look", "at", "gem", "in", "bag" })));
        }

        [Test()]
        public void InvalidLook()
        {
            Player p = new Player("Player 1", "Mighty Player 1");
            LookCommand command = new LookCommand();
            Assert.AreEqual("I dont know how to look like that", (command.Execute(p, new string[] { "look", "around" })));
            Assert.AreEqual("Error in look input", (command.Execute(p, new string[] { "hello", "its", "me" })));
            Assert.AreEqual("What do you want to look in?", (command.Execute(p, new string[] { "look", "at", "a", "at", "b" })));
            Assert.AreEqual("What do you want to look at?", (command.Execute(p, new string[] { "look", "in", "bag" })));
        }
    }
}