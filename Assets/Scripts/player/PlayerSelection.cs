using UnityEngine;

namespace thingGame
{
   public class PlayerSelection : MonoBehaviour
   {
      private void Awake()
      {
         selectable = GetComponent<ISelectable>();
      }

      private void Update()
      {
         if (selection != null)
         {
            selectable.OnDeselect(selection);
         }

         selection = null;
         if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, rayLength, selectableMask))
         {
            selection = hit.transform;
         }

         if (selection != null)
         {
            selectable.OnSelect(selection, outlineWidth);
         }
      }

      internal Transform GetSelection => selection;

      [SerializeField] private Camera cam;

      [SerializeField, Range(1, 100)] private float rayLength;

      [SerializeField, Range(0, 10)] private int outlineWidth;

      [SerializeField] private LayerMask selectableMask;

      private ISelectable selectable;
      private Transform selection;

      private void OnDrawGizmos()
      {
         Gizmos.color = Color.red;
         if (Application.isPlaying)
         {
            Gizmos.DrawRay(cam.transform.position, cam.transform.forward * rayLength);
         }
      }
   }
}