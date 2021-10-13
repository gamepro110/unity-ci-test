using NUnit.Framework;
using UnityEngine;
using thingGame;
using System.Collections.Generic;

public class InventoryTests
{
   [Test]
   public void AddNewItem()
   {
      GameObject player = Object.Instantiate(Resources.Load<GameObject>("PlayerCharacter"));
      PlayerInventory inventory = player.GetComponent<PlayerInventory>();
      ScriptableItem scriptableItem = Object.Instantiate(Resources.Load<ScriptableItem>("Items/Healing Blob"));
      GameObject heal = new GameObject(
         "",
         typeof(HealItem)
         );
      HealItem healItem = heal.GetComponent<HealItem>();

      inventory.Start();

      scriptableItem.Amount = 10;
      healItem.item = scriptableItem;

      inventory.PickupItem(healItem);

      Assert.AreEqual(1, inventory.GetInventory.Count);
      Assert.AreEqual(10, inventory.GetInventory[0].item.Amount);
   }

   [Test(TestOf = typeof(PlayerInventory))]
   public void UseItemTest()
   {
      GameObject player = Object.Instantiate(Resources.Load<GameObject>("PlayerCharacter"));
      ScriptableItem scriptableItem = Object.Instantiate(Resources.Load<ScriptableItem>("Items/Healing Blob"));
      GameObject heal = Object.Instantiate(Resources.Load<GameObject>("Items/Healing Blob"));

      PlayerInventory inventory = player.GetComponent<PlayerInventory>();
      HealItem healItem = heal.GetComponent<HealItem>();

      scriptableItem.Amount = 10;
      healItem.item = scriptableItem;

      inventory.Start();
      healItem.Start();

      inventory.PickupItem(healItem);
      Assert.AreEqual(1, inventory.GetInventory.Count);
      Assert.AreEqual(10, inventory.GetInventory[0].item.Amount);

      inventory.GetInventory[0].UseItem(player);

      Assert.AreEqual(9, inventory.GetInventory[0].item.Amount);
      inventory.GetInventory.Clear();
   }
}