using System;
using UnityEngine;

namespace thingGame
{
   public class Objective : ScriptableObject
   {
      internal static event Action<Objective> OnObjectiveCreated;

      internal static event Action<Objective> OnObjectiveCompleted;

      private void Awake()
      {
         OnObjectiveCreated?.Invoke(this);
      }

      public void UpdateObjective(string descriptionText, string counterText, string notificationText)
      {
         ObjectiveUpdateEvent evt = Events.ObjectiveUpdateEvent;
         evt.Objective = this;
         evt.Description = descriptionText;
         evt.CounterText = counterText;
         evt.NotificationText = notificationText;
         evt.IsComplete = IsCompleted;
         EventManager.Broadcast(evt);
      }

      public void CompleteObjective(string descriptionText, string counterText, string notificationText)
      {
         Complete = true;

         ObjectiveUpdateEvent evt = Events.ObjectiveUpdateEvent;
         evt.Objective = this;
         evt.Description = descriptionText;
         evt.CounterText = counterText;
         evt.NotificationText = notificationText;
         evt.IsComplete = IsCompleted;
         EventManager.Broadcast(evt);

         OnObjectiveCompleted?.Invoke(this);
      }

      internal bool IsCompleted => Complete;

      internal bool IsBlocking => !(Complete || IsOptional);

      [SerializeField, Tooltip("name that will be shown")]
      private string Title = "title...";

      [SerializeField, Tooltip("short text explaining the objective that will be shown")]
      private string Description = "...";

      [SerializeField, Tooltip("wether its required or not")]
      private bool IsOptional = false;

      [SerializeField, Range(0, 30), Tooltip("delay before it becomes visible")]
      private float DelayVisible;

      [SerializeField] private bool Complete;
   }
}