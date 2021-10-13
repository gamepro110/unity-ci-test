using UnityEngine;

namespace thingGame
{
   public class OutlineSelection : MonoBehaviour, ISelectable
   {
      public void OnSelect(Transform selection, int outlineWidth)
      {
         Outline outline = selection.GetComponent<Outline>();
         if (outline != null)
         {
            outline.OutlineWidth = outlineWidth;
         }
      }

      public void OnDeselect(Transform selection)
      {
         Outline outline = selection.GetComponent<Outline>();
         if (outline != null)
         {
            outline.OutlineWidth = 0;
         }
      }
   }
}