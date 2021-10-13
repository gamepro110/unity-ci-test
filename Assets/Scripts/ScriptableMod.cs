using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace thingGame
{
   [CreateAssetMenu(fileName = "Mod", menuName = "Scriptable/New Mod")]
   public class ScriptableMod : ScriptableObject
   {
      public int ID;
      public string Name = "...";
      public float AccuracyMultiplier = 1;
      public float DamageMultiplier = 1;
      public float MultishotMultiplier = 1;
      public float CriticalChanceMultiplier = 1;
      public float CriticalDamageMultiplier = 1;
      public float StatusChanceMultiplier = 1;
      public float StatusDurationMultiplier = 1;
      public float ReloadSpeedMultiplier = 1;
      public float MagazineCapacityMultiplier = 1;
      public float MaxAmmoMultiplier = 1;
      public string Description = "...";
   }
}