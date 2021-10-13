using System;
using UnityEngine;

namespace thingGame
{
   public class InputManager : MonoBehaviour
   {
      private delegate void PickupAction();

      private delegate void InteractionAction();

      private delegate void JumpAction();

      private delegate void MoveAction(Vector2 val);

      private delegate void LookAction(Vector2 val);

      private static event PickupAction OnPickup;

      private static event InteractionAction OnInteraction;

      private static event JumpAction OnJump;

      private static event MoveAction OnMove;

      private static event LookAction OnLook;

      internal bool IsPickingup => controls.Player.PickupItem.triggered;
      internal bool IsInteracting => controls.Player.Interaction.triggered;
      private bool IsJumping => controls.Player.jump.triggered;
      private Vector2 Movement => controls.Player.move.ReadValue<Vector2>();
      private Vector2 LookInput => controls.Player.look.ReadValue<Vector2>();

      private void Awake()
      { controls = new Controls(); }

      private void OnEnable()
      { controls.Enable(); }

      private void OnDisable()
      { controls.Disable(); }

      private void Update()
      {
         OnMove(Movement);
         OnLook(LookInput);

         if (IsJumping && OnJump != null)
         {
            OnJump();
         }

         if (IsInteracting && OnInteraction != null)
         {
            OnInteraction();
         }

         if (IsPickingup && OnPickup != null)
         {
            OnPickup();
         }
      }

      // Both Add<thing> and Remove<thing> are neccecary

      internal void AddMovement(Action<Vector2> action)
      { OnMove += (Vector2 val) => action(val); }

      internal void AddLooking(Action<Vector2> action)
      { OnLook += (Vector2 val) => action(val); }

      internal void AddJump(Action action)
      { OnJump += () => action(); }

      internal void AddInteractable(Action action)
      { OnInteraction += () => action(); }

      internal void AddPickup(Action action)
      { OnPickup += () => action(); }

      internal void RemoveMovement(Action<Vector2> action)
      { OnMove -= (Vector2 val) => action(val); }

      internal void RemoveLooking(Action<Vector2> action)
      { OnLook -= (Vector2 val) => action(val); }

      internal void RemoveJump(Action action)
      { OnJump -= () => action(); }

      internal void RemoveInteractable(Action action)
      { OnInteraction -= () => action(); }

      internal void RemovePickup(Action action)
      { OnPickup -= () => action(); }

      private Controls controls;
   }
}