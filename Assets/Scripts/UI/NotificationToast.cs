using UnityEngine;

namespace thingGame.UI
{
   public class NotificationToast : MonoBehaviour
   {
      private void Update()
      {
         float timeSinceInit = Time.time - initTime;

         if (timeSinceInit < FadeInDuration)
         {
            CanvasGroup.alpha = timeSinceInit / FadeInDuration;
         }
         else if (timeSinceInit < FadeInDuration + VisibleDuration)
         {
            CanvasGroup.alpha = 1f;
         }
         else if (timeSinceInit < FadeInDuration + VisibleDuration + FadeOutDuration)
         {
            CanvasGroup.alpha = 1 - (timeSinceInit - FadeInDuration - VisibleDuration) / FadeOutDuration;
         }
         else
         {
            CanvasGroup.alpha = 0f;
            Destroy(gameObject);
         }
      }

      public void Initialize(string text)
      {
         TextContent.text = text;
         initTime = Time.time;

         init = true;
      }

      public float TotalRunTime => VisibleDuration + FadeInDuration + FadeOutDuration;

      public bool Initialized => init;

      [Tooltip("the text to be displayed")]
      public TMPro.TextMeshProUGUI TextContent;

      [Tooltip("the canvas used for fading")]
      public CanvasGroup CanvasGroup;

      [Range(0f, 100f), Tooltip("how long wil it be visible")]
      public float VisibleDuration;

      [Range(0f, 5f), Tooltip("time it takes to fade in")]
      public float FadeInDuration;

      [Range(0f, 5f), Tooltip("time it takes to fade out")]
      public float FadeOutDuration;

      private bool init = false;
      private float initTime;
   }
}