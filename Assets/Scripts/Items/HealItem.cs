using UnityEngine;

namespace thingGame
{
   public class HealItem : ItemBase
   {
      public void Start()
      {
         item.OnUse = ItemAction;
      }

      private void ItemAction(GameObject player)
      {
         PlayerDamageble damageble = player.GetComponent<PlayerDamageble>();
         damageble?.DoHeal(HealAmount);
      }

      [SerializeField, Range(0, 20)] private int HealAmount = 5;
   }
}