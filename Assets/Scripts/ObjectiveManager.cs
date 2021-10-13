using System.Collections.Generic;
using thingGame;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
   private void Awake()
   {
      Objective.OnObjectiveCreated += RegisterObjective;
   }

   private void LateUpdate()
   {
      if (Objectives.Count == 0 || ObjectivesCompleted)
      {
         return;
      }

      for (int i = 0; i < Objectives.Count; i++)
      {
         if (Objectives[i].IsBlocking)
         {
            return;
         }
      }

      ObjectivesCompleted = true;
      EventManager.Broadcast(Events.AllObjectivesCompletedEvent);
   }

   private void OnDestroy()
   {
      Objective.OnObjectiveCreated -= RegisterObjective;
   }

   private void RegisterObjective(Objective objective) => Objectives.Add(objective);

   [SerializeField] private List<Objective> Objectives = new List<Objective>();
   [SerializeField] private bool ObjectivesCompleted = false;
}