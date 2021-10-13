using UnityEngine;

namespace thingGame
{
   public class Damageble : MonoBehaviour, IDamageble
   {
      protected virtual void Start()
      {
         MaxHitpoints = Hitpoints;
      }

      public int GetHitpoints => Hitpoints + TemporaryHitpoints;

      public virtual void DoHeal(int amount)
      {
         Hitpoints =
             (Hitpoints + amount > MaxHitpoints) ?
             MaxHitpoints :
             Hitpoints + amount;
      }

      public virtual void DoDamage(int amount)
      {
         Hitpoints =
             Hitpoints - amount < 1 ?
             0 :
             Hitpoints - amount;

         if (Hitpoints == 0)
         { OnDeath(); }
      }

      public virtual void OnDeath()
      {
         Destroy(gameObject);
      }

#if DEBUG

      public void SetHitpoints(int value)
      { Hitpoints = value; }

      public void SetMaxHitpoints(int value)
      { MaxHitpoints = value; }

#endif

      [SerializeField, Range(0, 10)] protected int Hitpoints = 10;
      protected int MaxHitpoints = 0;
      protected int TemporaryHitpoints = 0;
   }
}