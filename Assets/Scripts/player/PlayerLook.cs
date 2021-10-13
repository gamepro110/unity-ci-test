using UnityEngine;

namespace thingGame
{
   public class PlayerLook : MonoBehaviour
   {
      private void Start()
      {
         Cursor.lockState = CursorLockMode.Locked;
         input = FindObjectOfType<InputManager>();

         input.AddLooking(Look);
      }

      private void OnDestroy()
      {
         input.RemoveLooking(Look);
      }

      private void Look(Vector2 val)
      {
         lookX = val.x * mouseSensitivity * Time.deltaTime;
         lookY = val.y * mouseSensitivity * Time.deltaTime;

         xRotation -= lookY;

         xRotation = Mathf.Clamp(xRotation, minLookAngle, maxLookAngle);

         cameraObj.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
         transform.Rotate(Vector3.up * lookX);
      }

      [Header("visual settings")]
      [SerializeField]
      private float mouseSensitivity = 100;

      [SerializeField]
      private GameObject cameraObj = null;

      [Space]
      [SerializeField, Range(0, -180)]
      private float minLookAngle;

      [SerializeField, Range(0, 180)]
      private float maxLookAngle;

      private float lookX = 0;
      private float lookY = 0;
      private float xRotation = 0;

      private InputManager input;
   }
}