using UnityEngine;
using UnityEngine.UI;

namespace thingGame
{
   public class DebugHPText : MonoBehaviour
   {
      private void Start()
      {
         text = GetComponent<Text>();
         damageble = FindObjectOfType<PlayerDamageble>();
      }

      private void LateUpdate()
      {
         text.text = string.Format(
            displayText,
            damageble.GetHitpoints
            );
      }

      private Text text;
      private Damageble damageble;
      [SerializeField] private string displayText = "HP: {0}";
   }
}