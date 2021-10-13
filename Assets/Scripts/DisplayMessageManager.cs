using UnityEngine;

namespace thingGame
{
   public class DisplayMessageManager : MonoBehaviour
   {
      private void Awake()
      { EventManager.AddListener<DisplayMessageEvent>(OnNotificationEvent); }

      private void OnDestroy()
      { EventManager.RemoveListener<DisplayMessageEvent>(OnNotificationEvent); }

      private void OnNotificationEvent(DisplayMessageEvent evt)
      { CreateNotification(evt.Message); }

      public void CreateNotification(string text)
      {
         GameObject notificationInstance = Instantiate(NotificationPrefab, NotificationPanel);
         notificationInstance.transform.SetSiblingIndex(0);

         UI.NotificationToast toast = notificationInstance.GetComponent<UI.NotificationToast>();
         toast?.Initialize(text);
      }

      public RectTransform NotificationPanel;
      public GameObject NotificationPrefab;
   }
}