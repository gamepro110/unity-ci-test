using System;
using UnityEngine;

namespace thingGame
{
   public class GameManager : MonoBehaviour
   {
      private void Start()
      {
         EventManager.AddListener<PlayerDeathEvent>(OnPlayerDeath);
      }

      private void OnDestroy()
      {
         EventManager.RemoveListener<PlayerDeathEvent>(OnPlayerDeath);
      }

      private void OnPlayerDeath(PlayerDeathEvent action)
      {
         Debug.Log("Player Died");
      }
   }
}