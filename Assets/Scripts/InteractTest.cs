using UnityEngine;

namespace thingGame
{
   public class InteractTest : MonoBehaviour, IInteractable
   {
      public void OnInteraction(GameObject player)
      {
         player
            .GetComponent<PlayerDamageble>()
            .DoDamage(amount);
      }

      [SerializeField, Range(0, 100)] private int amount = 5;
   }
}