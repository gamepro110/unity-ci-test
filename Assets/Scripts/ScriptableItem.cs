using System;
using UnityEngine;

namespace thingGame
{
   [CreateAssetMenu(fileName = "item", menuName = "Scriptable/New Item")]
   public class ScriptableItem : ScriptableObject
   {
      public int ID;
      public string Name = "...";
      public string Description = "...";
      public int Amount = 1;
      public Action<GameObject> OnUse = (GameObject player) => Debug.LogWarning("'OnUse' is undefined!", player);
   }
}