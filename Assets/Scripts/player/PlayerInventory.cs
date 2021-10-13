using System.Collections.Generic;
using UnityEngine;

namespace thingGame
{
   public class PlayerInventory : MonoBehaviour
   {
      public void Start()
      {
         inventory = new List<ItemBase>();

         inventory.RemoveAll(x => x == null);
      }

      public void PickupItem(ItemBase item)
      {
         if (inventory.Contains(item))
         {
            ItemBase it = inventory.Find(x => x.item.ID == item.item.ID);
            it.item.Amount += item.item.Amount;
         }
         else
         {
            inventory.Add(item);
         }
      }

      public void PickupItem(IEnumerable<ItemBase> items)
      {
         List<ItemBase> itemList = (List<ItemBase>)items;
         itemList
            .ForEach(
            x => PickupItem(x)
            );
      }

      public void UseItem(int ID)
      {
         ItemBase item = inventory.Find(x => x.item.ID == ID);
         if (item != null)
         {
            //notify
            item.UseItem(gameObject);
         }
      }

      public List<ItemBase> GetInventory => inventory;

      [SerializeField] private List<ItemBase> inventory = new List<ItemBase>();
   }
}