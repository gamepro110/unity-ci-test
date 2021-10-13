using System;
using UnityEngine;

namespace thingGame
{
   [CreateAssetMenu(fileName = "gun", menuName = "Scriptable/New Gun")]
   public class ScriptableGun : ScriptableObject
   {
      public int ID = 0;
      public float Accuracy = 1;
      public float Damage = 1;
      public float Multishot = 1;
      public float CriticalChance = 1;
      public float CriticalDamage = 1;
      public float StatusChance = 1;
      public float StatusDuration = 1;
      public float ReloadTime = 1;
      public int MagazineCapacity = 1;
      public int MaxAmmo = 1;
      public Action OnShoot;
      public ScriptableMod[] mods = new ScriptableMod[3];
      public string Name = "...";
      public string Description = "...";
   }
}