using UnityEngine;

namespace thingGame
{
   public static class Events
   {
      public static ObjectiveUpdateEvent ObjectiveUpdateEvent = new ObjectiveUpdateEvent();
      public static AllObjectivesCompletedEvent AllObjectivesCompletedEvent = new AllObjectivesCompletedEvent();
      public static GameOverEvent GameOverEvent = new GameOverEvent();
      public static PlayerDeathEvent PlayerDeathEvent = new PlayerDeathEvent();
      public static EnenmyKillEvent EnenmyKillEvent = new EnenmyKillEvent();
      public static PickupEvent PickupEvent = new PickupEvent();
      public static PlayerDamageEvent DamageEvent = new PlayerDamageEvent();
      public static DisplayMessageEvent DisplayMessageEvent = new DisplayMessageEvent();
      public static PlayerWeaponPickup PlayerWeaponPickup = new PlayerWeaponPickup();
   }

   public class ObjectiveUpdateEvent : GameEvent
   {
      public Objective Objective;
      public string Description;
      public string CounterText;
      public bool IsComplete;
      public string NotificationText;
   }

   public class AllObjectivesCompletedEvent : GameEvent
   {
   }

   public class GameOverEvent : GameEvent
   {
      public bool win;
   }

   public class PlayerDeathEvent : GameEvent
   {
   }

   public class EnenmyKillEvent : GameEvent
   {
      public GameObject Enemy;
      public int RemainingEnemyCount;
   }

   public class PickupEvent : GameEvent
   {
      public GameObject Pickup;
   }

   public class PlayerWeaponPickup : GameEvent
   {
      public GameObject weapon;
   }

   public class PlayerDamageEvent : GameEvent
   {
      public GameObject Sender;
      public int DamageValue;
   }

   public class DisplayMessageEvent : GameEvent
   {
      public string Message;
      public float DelayBeforeDisplay;
   }
}