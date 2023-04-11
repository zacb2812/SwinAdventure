using NUnit.Framework;
using System;
using SwinAdventure;

namespace SwinAdventureTests
{
    [TestFixture()]
    public class TestIdentifiableObject
    {
        [Test()]
        public void TestAreYou()
        {
            string[] TestIds = { "Fred", "Bob" };
            IdentifiableObject newObject = new IdentifiableObject(TestIds);
            Assert.IsTrue(newObject.AreYou("Bob"));
        }

        [Test()]
        public void TestNotAreYou()
        {
            string[] TestIds = { "Fred", "Bob" };
            IdentifiableObject newObject = new IdentifiableObject(TestIds);
            Assert.IsFalse(newObject.AreYou("Boby"));
        }

        [Test()]
        public void TestCaseSensitive()
        {
            string[] TestIds = { "Fred", "Bob" };
            IdentifiableObject newObject = new IdentifiableObject(TestIds);
            Assert.IsTrue(newObject.AreYou("BOB"));
        }

        [Test()]
        public void FirstID()
        {
            string[] TestIds = { "Fred", "Bob" };
            IdentifiableObject newObject = new IdentifiableObject(TestIds);
            StringAssert.AreEqualIgnoringCase(newObject.FirstID, TestIds[0]);
        }

        [Test()]
        public void TestAddID()
        {
            string[] TestIds = { "Fred", "Bob" };
            IdentifiableObject newObject = new IdentifiableObject(TestIds);
            newObject.AddIdentifier("Wilma");
            Assert.IsTrue(newObject.AreYou("Wilma"));
        }
    }
}
