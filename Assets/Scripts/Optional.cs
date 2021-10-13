using System;
using UnityEngine;

namespace thingGame
{
   /// <typeparam name="T">prefered to be nullable</typeparam>
   [Serializable]
   public struct Optional<T> where T : struct
   {
      public Optional(T? initialValue, bool enable = true)
      {
         enabled = enable;
         value = initialValue;
      }

      [SerializeField] private bool enabled;
      [SerializeField] private T? value;

      public bool Enabled { get => enabled; set => enabled = value; }

      public T? Value
      {
         get => enabled ? value : null;
         set => this.value = (T)value;
      }
   }
}