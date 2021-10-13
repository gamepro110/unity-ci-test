#if UNITY_EDITOR
using thingGame;
using UnityEditor;

[CustomEditor(typeof(ScriptableMod))]
public class ScriptableModEditor : Editor
{
   private void OnEnable()
   {
      item = (ScriptableMod)target;
   }

   protected override void OnHeaderGUI()
   {
      EditorGUILayout.HelpBox(
         "Scriptable Mod Editor",
         MessageType.Info
         );
   }

   public override void OnInspectorGUI()
   {
      this.TextField(
         ref item.Name,
         "Name"
         );

      this.HelpBox("Damage");
      this.FloatSlider(
         ref item.DamageMultiplier,
         0,
         3,
         "Damage multiplier",
         "multiply base dmg"
         );

      this.FloatSlider(
         ref item.MultishotMultiplier,
         0,
         5,
         "Multishot multiplier",
         "multiply base multishot"
         );

      this.HelpBox("Crit");
      this.FloatSlider(
         ref item.CriticalChanceMultiplier,
         0,
         5,
         "Critical chance multiplier",
         "multiply base crit chance"
         );

      this.FloatSlider(
         ref item.CriticalDamageMultiplier,
         1,
         10,
         "Critical damage multiplier",
         "multiply base critical dmg"
         );

      this.HelpBox("Status");
      this.FloatSlider(
         ref item.StatusChanceMultiplier,
         0,
         3,
         "Status chance multiplier",
         "multiply base status chance"
         );

      this.FloatSlider(
         ref item.StatusDurationMultiplier,
         0,
         5,
         "Status Duration Multiplier"
         );

      this.HelpBox("Gun Stats");
      this.FloatSlider(
         ref item.AccuracyMultiplier,
         0,
         2,
         "Accuracy Multiplier"
         );

      this.FloatSlider(
         ref item.ReloadSpeedMultiplier,
         -3,
         3,
         "Reload speed multiplier",
         "multiply base Reload speed, for faster reloading"
         );

      this.FloatSlider(
         ref item.MagazineCapacityMultiplier,
         0,
         3,
         "Magazine Capacity Multiplier"
         );

      this.FloatSlider(
         ref item.MaxAmmoMultiplier,
         0,
         3,
         "Max Ammo Multiplier",
         "changes the number of full magazines this gun can have"
         );
   }

   private ScriptableMod item;
}
#endif