using System.Collections.Generic;
using UnityEngine;

namespace thingGame
{
   public class ItemBase : MonoBehaviour, IItem
   {
      public virtual void UseItem(GameObject player)
      {
         if (item.Amount > 0)
         {
            item.OnUse(player);
            item.Amount--;
         }
      }

      public virtual void OnInteraction(GameObject player)
      { UseItem(player); }

      public virtual void OnPickup(GameObject player)
      {
         PlayerInventory inventory = player.GetComponent<PlayerInventory>();
         inventory?.PickupItem(this);

         EventManager.Broadcast(new DisplayMessageEvent
         {
            Message = string.Format(
               " Picked up {0} {1}x ",
               item.name,
               item.Amount
               ),
            DelayBeforeDisplay = 0.5f
         });

         Destroy(gameObject);
      }

      protected List<IObserver> observers = new List<IObserver>();

      // Set to internal ouside of testing
      [SerializeField] public ScriptableItem item;
   }
}