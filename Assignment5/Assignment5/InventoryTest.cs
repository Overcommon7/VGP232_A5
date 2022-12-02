using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Assignment5
{
    [TestFixture]
    public class InventoryTest
    {
        Inventory inventory;
        static Item axe = new Item("Axe", 1, ItemGroup.Equipment);
        static Item sword = new Item("Sword", 1, ItemGroup.Equipment);
        static Item HealthPotion = new Item("Health Potion", 1, ItemGroup.Consumable);

        [SetUp]
        public void SetUp()
        {
            inventory = new Inventory(10);
            inventory.AddItem(axe);
            inventory.AddItem(sword);
            inventory.AddItem(HealthPotion);
        }

        [TearDown]
        public void TearDown()
        {
            inventory = null;
        }

        [Test]
        public void Test_Inventory_RemoveItem_Found()
        {
            Item item;
            int originalSlots = inventory.AvailableSlots;
            inventory.TakeItem(axe.Name, out item);
            Assert.AreEqual(axe, item);
            Assert.Less(originalSlots, inventory.AvailableSlots);
        }

        [Test]
        public void Test_Inventory_RemoveItem_NotFound()
        {
            Item item;
            int originalSlots = inventory.AvailableSlots;
            inventory.TakeItem("Invalid", out item);
            Assert.AreEqual(originalSlots, inventory.AvailableSlots);
        }

        [Test]
        public void Test_Inventory_AddItem()
        {
            int originalSlots = inventory.AvailableSlots;
            var key = new Item("Golden Door Key", 1, ItemGroup.Key);
            inventory.AddItem(key);
            Assert.Less(inventory.AvailableSlots, originalSlots);
            Assert.AreEqual(inventory.ListAllItems().Contains(key), true);
        }

        [Test]
        public void Test_Reset_Inventory()
        {
            inventory.Reset();
            Assert.AreEqual(inventory.AvailableSlots, inventory.MaxSlots);
            Assert.AreEqual(inventory.ListAllItems().Count, 0);
        }
    }   
}
