using UnityEngine;

namespace thingGame
{
   public class PlayerMove : MonoBehaviour
   {
      private void Start()
      {
         controller = GetComponent<CharacterController>();

         input = FindObjectOfType<InputManager>();
         input.AddMovement(Move);
      }

      private void OnDestroy()
      {
         input.RemoveMovement(Move);
      }

      private void Move(Vector2 val)
      {
         movement = transform.right * val.x + transform.forward * val.y;
         controller.Move(Time.deltaTime * movementSpeed * movement);
      }

      [Header("Movement Settings")]
      [SerializeField, Range(1, 15)]
      private float movementSpeed;

      private Vector3 movement = Vector3.zero;
      private CharacterController controller;
      private InputManager input;
   }
}