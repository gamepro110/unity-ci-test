using UnityEngine;

namespace thingGame
{
   public class PlayerJump : MonoBehaviour
   {
      private void Start()
      {
         playerGravity = GetComponent<PlayerGravity>();
         input = FindObjectOfType<InputManager>();

         input.AddJump(Jump);
      }

      private void OnDestroy()
      {
         input.RemoveJump(Jump);
      }

      private void Jump()
      {
         if (playerGravity.IsGrounded)
         {
            playerGravity.JumpPlayer(jumpHeight);
         }
      }

      [Header("parameters")]
      [SerializeField, Range(1, 15)]
      private float jumpHeight;

      private PlayerGravity playerGravity;
      private InputManager input;
   }
}