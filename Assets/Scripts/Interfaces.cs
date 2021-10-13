using UnityEngine;

namespace thingGame
{
   public interface ISelectable
   {
      void OnSelect(Transform selection, int outlineWidth);

      void OnDeselect(Transform selection);
   }

   public interface IInteractable
   {
      void OnInteraction(GameObject player);
   }

   public interface IPickupable
   {
      void OnPickup(GameObject player);
   }

   public interface IItem : IPickupable, IInteractable
   {
      void UseItem(GameObject player);
   }

   public interface IDamageble
   {
      abstract void DoHeal(int amount);

      abstract void DoDamage(int amount);

      abstract void OnDeath();
   }

   public interface IGun : IPickupable
   {
      abstract void DoReload();

      abstract void Fire();
   }
}