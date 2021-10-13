using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace thingGame
{
   public class PlayerPickupBehaviour : MonoBehaviour
   {
      private void Start()
      {
         selection = GetComponent<PlayerSelection>();
         input = FindObjectOfType<InputManager>();
         input.AddPickup(OnPickup);
      }

      private void OnDestroy()
      {
         input.RemovePickup(OnPickup);
      }

      private void OnPickup()
      {
         selection
            .GetSelection
            .GetComponent<IPickupable>()
            ?.OnPickup(gameObject);
      }

      private PlayerSelection selection;
      private InputManager input;
   }
}