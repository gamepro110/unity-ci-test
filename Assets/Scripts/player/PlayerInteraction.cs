using UnityEngine;

namespace thingGame
{
   public class PlayerInteraction : MonoBehaviour
   {
      private void Start()
      {
         playerSelection = GetComponent<PlayerSelection>();
         input = FindObjectOfType<InputManager>();

         input.AddInteractable(Interact);
      }

      private void OnDestroy()
      {
         input.RemoveInteractable(Interact);
      }

      private void Interact()
      {
         if (input.IsInteracting)
         {
            playerSelection
               .GetSelection
               ?.GetComponent<IInteractable>()
               ?.OnInteraction(gameObject);
         }
      }

      private PlayerSelection playerSelection;
      private InputManager input;
   }
}