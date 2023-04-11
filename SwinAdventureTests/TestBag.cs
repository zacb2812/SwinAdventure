using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestBag
    {
        [Test()]
        public void TestBagLocatesItems()
        {
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book", "novel" }, "a book", "This book is very long");
            b.Inventory.Put(shovel);
            b.Inventory.Put(book);
            Assert.AreEqual(book, b.Locate("book"));
        }

        [Test()]
        public void TestBagLocatesItself()
        {
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Assert.AreEqual(b, b.Locate("backpack"));
        }

        [Test()]
        public void TestBagLocatesNothing()
        {
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            b.Inventory.Put(shovel);
            b.Inventory.Put(book);
            Assert.AreEqual(null, b.Locate("club"));
        }

        [Test()]
        public void TestBagFullDescription()
        {
            Bag b = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            b.Inventory.Put(shovel);
            b.Inventory.Put(book);
            StringAssert.StartsWith("You are carrying:", b.FullDescription);
        }

        [Test()]
        public void TestBag1InBag2()
        {
            Bag b1 = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Bag b2 = new Bag(new string[] { "bag2", "backpack2" }, "Bag 2", "Mighty Backpack");
            b1.Inventory.Put(b2);
            Assert.AreEqual(b2, b1.Locate("bag2"));
        }

        [Test()]
        public void TestBag1LocateOtherItems()
        {
            Bag b1 = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Bag b2 = new Bag(new string[] { "bag2", "backpack2" }, "Bag 2", "Mighty Backpack");
            b1.Inventory.Put(b2);
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            b1.Inventory.Put(shovel);
            b1.Inventory.Put(book);
            Assert.AreEqual(book, b1.Locate("book"));
        }

        [Test()]
        public void TestBag1CannotLocateItemsInBag2()
        {
            Bag b1 = new Bag(new string[] { "bag", "backpack" }, "Bag 1", "Mighty Backpack");
            Bag b2 = new Bag(new string[] { "bag2", "backpack2" }, "Bag 2", "Mighty Backpack");
            b1.Inventory.Put(b2);
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Item book = new Item(new string[] { "book" }, "a book", "This book is very long");
            b1.Inventory.Put(shovel);
            b2.Inventory.Put(book);
            Assert.AreNotEqual(book, b1.Locate("book"));
        }
    }
}