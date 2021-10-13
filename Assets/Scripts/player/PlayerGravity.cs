using UnityEngine;

namespace thingGame
{
   public class PlayerGravity : MonoBehaviour
   {
      private void Start()
      {
         controller = GetComponent<CharacterController>();
      }

      private void Update()
      {
         grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

         if (grounded && velocity.y < 0)
         {
            velocity.y = -2;
         }

         velocity.y += gravityForce * Time.deltaTime;

         controller.Move(velocity * Time.deltaTime);
      }

      internal void JumpPlayer(float height)
      {
         velocity.y = Mathf.Sqrt(height * -2 * gravityForce);
      }

      internal bool IsGrounded => grounded;

      [Header("Parameters")]
      [SerializeField]
      private Transform groundCheck;

      [SerializeField, Range(0, 2)]
      private float groundDistance;

      [SerializeField, Range(0, -20)]
      private float gravityForce;

      [Space]
      [SerializeField]
      private LayerMask groundMask;

      [SerializeField]
      private Vector3 velocity;

      private bool grounded;
      private CharacterController controller;
   }
}