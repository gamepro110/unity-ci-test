using UnityEngine;

namespace thingGame
{
   public class PlayerDamageble : Damageble
   {
      protected override void Start()
      {
         base.Start();
         EventManager.AddListener<PlayerDamageEvent>(OnDmgEvent);
      }

      private void OnDestroy()
      {
         EventManager.RemoveListener<PlayerDamageEvent>(OnDmgEvent);
      }

      public override void OnDeath()
      { EventManager.Broadcast(Events.PlayerDeathEvent); }

      private void OnDmgEvent(PlayerDamageEvent evt)
      {
         DoDamage(evt.DamageValue);
         EventManager.Broadcast(new DisplayMessageEvent
         {
            Message = string.Format(
               "{0} caused {1} dmg to player",
               evt.Sender.name,
               evt.DamageValue
               ),
         });
      }
   }
}