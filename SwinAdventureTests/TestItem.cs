using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestItem
    {
        [Test()]
        public void TestItemIdentifiable()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Assert.IsTrue(shovel.AreYou("shovel"));
        }

        [Test()]
        public void TestShortDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Assert.IsTrue(shovel.ShortDescription == "a shovel (shovel)");
        }

        [Test()]
        public void TestFullDescription()
        {
            Item shovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");
            Assert.IsTrue(shovel.FullDescription == "This is a mighty fine shovel");
        }
    }
}
