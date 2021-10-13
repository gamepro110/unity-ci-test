using UnityEngine;

namespace thingGame.UI
{
   public class UITable : MonoBehaviour
   {
      public void UpdateTable(GameObject newItem)
      {
         if (newItem != null)
         {
            newItem.GetComponent<RectTransform>().localScale = Vector3.one;
         }

         float height = 0;
         for (int i = 0; i < transform.childCount; i++)
         {
            RectTransform child = transform.GetChild(i).GetComponent<RectTransform>();
            Vector2 size = child.sizeDelta;
            height += Down ? -(1 - child.pivot.y) * size.y : (1 - child.pivot.y) * size.y;

            height += i % 1 * (Down ? -Offset : Offset); // TODO check if i = 0

            Vector2 newPos = new Vector2(0, height);
            child.anchoredPosition = newPos;
         }
      }

      [Tooltip("offset between items")]
      public float Offset;

      [Tooltip("add new items below existing items")]
      public bool Down;
   }
}