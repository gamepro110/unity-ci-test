using thingGame;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ScriptableGun))]
public class ScriptableGunEditor : Editor
{
   private void OnEnable()
   {
      item = (ScriptableGun)target;
   }

   public override void OnInspectorGUI()
   {
      this.TextField(
         ref item.Name,
         "Name",
         ""
         );

      this.HelpBox("Damage");
      this.FloatSlider(
          ref item.Damage,
          1,
          200,
         "Damage",
         ""
         );

      this.FloatSlider(
         ref item.Multishot,
         1,
         4.5f,
         "Multishot",
         "the chance to shoot mutiple bullets in a single shot, 1 == 1 bullet, 1.5 == 50% chance to shoot 2 bullets"
         );

      this.HelpBox("Critical");
      this.FloatSlider(
         ref item.CriticalChance,
         0,
         450,
         "Critical chance %",
         "chance to deal critical damage, can go above 100. if higher than 100 its applied multiple times"
         );

      this.FloatSlider(
         ref item.CriticalDamage,
         1,
         10,
         "critical damage multiplier",
         "how much the damage is multiplied on a crit"
         );

      this.HelpBox("Status");
      this.FloatSlider(
         ref item.StatusChance,
         0,
         300,
         "Status chance"
         );

      this.IntSlider(
         ref item.StatusDuration,
         1,
         20,
         "Status Duration",
         "Duration of the status effect"
         );

      this.HelpBox("Gun stats");
      this.FloatSlider(
         ref item.Accuracy,
         0,
         1,
         "Accuracy"
         );

      this.FloatSlider(
         ref item.ReloadTime,
         10,
         0.1f,
         "reload speed",
         "how long it will take to reload in seconds"
         );
      this.IntSlider(
         ref item.MagazineCapacity,
         1,
         200,
         "Magazine Capasity"
         );
      ammoMultiplier = EditorGUILayout.IntSlider(
         new GUIContent(
            "Num magazines",
            ""
            ),
         ammoMultiplier,
         1,
         20
         );
      item.MaxAmmo = item.MagazineCapacity * ammoMultiplier;

      EditorGUILayout.Space();

      this.TextArea(
         ref item.Description,
         "Item Description"
         );
   }

   private int ammoMultiplier = 1;
   private ScriptableGun item;
}