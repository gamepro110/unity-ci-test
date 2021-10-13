#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using thingGame;
using System.Linq;
using System.Collections.Generic;

public class ScriptableModWizard : ScriptableWizard
{
   [MenuItem("Scriptable/Mod Wizard", priority = 2)]
   public static void OnWizardOpen()
   { DisplayWizard<ScriptableModWizard>("Mod Wizard", "Create"); }

   private void OnEnable()
   { item = CreateInstance<ScriptableMod>(); }

   protected override bool DrawWizardGUI()
   {
      CanSave = true;

      ID = EditorGUILayout.IntField(
         new GUIContent("Unique ID"),
         ID
         );

      Name = EditorGUILayout.TextField(
         new GUIContent("Name"),
         Name
         );

      EditorGUILayout.Space();

      AccuracyMultiplier = EditorGUILayout.Slider(
         new GUIContent("Accuracy"),
         AccuracyMultiplier,
         0.1f,
         100f
         );

      DamageMultiplier = EditorGUILayout.Slider(
         new GUIContent("Damage"),
         AccuracyMultiplier,
         0f,
         2.5f
         );

      MultishotMultiplier = EditorGUILayout.Slider(
         new GUIContent("Multishot"),
         MultishotMultiplier,
         0,
         3
         );

      EditorGUILayout.Space();

      CriticalChanceMultiplier = EditorGUILayout.Slider(
         new GUIContent("Critical chance"),
         CriticalChanceMultiplier,
         -1,
         3
         );

      CriticalDamageMultiplier = EditorGUILayout.Slider(
         new GUIContent("Critical Damage"),
         CriticalDamageMultiplier,
         0,
         3
         );

      EditorGUILayout.Space();

      StatusChanceMultiplier = EditorGUILayout.Slider(
         new GUIContent("Status Chance"),
         StatusChanceMultiplier,
         0,
         3
         );

      StatusDurationMultiplier = EditorGUILayout.Slider(
         new GUIContent("Status Duration"),
         StatusDurationMultiplier,
         0,
         3
         );

      EditorGUILayout.Space();

      ReloadSpeedMultiplier = EditorGUILayout.Slider(
         new GUIContent("Reload Speed"),
         ReloadSpeedMultiplier,
         0,
         10
         );

      MagazineCapacityMultiplier = EditorGUILayout.Slider(
         new GUIContent("Magazine Capacity"),
         MagazineCapacityMultiplier,
         1,
         400
         );

      MaxAmmoMultiplier = EditorGUILayout.IntSlider(
         new GUIContent("Num Magazines"),
         (int)MaxAmmoMultiplier,
         1,
         20
         );

      EditorGUILayout.Space();

      EditorGUILayout.LabelField("Description");
      Description = EditorGUILayout.TextArea(
         Description,
         GUILayout.ExpandHeight(true)
         );

      #region checks

      List<ScriptableMod> CreatedItems = Resources.FindObjectsOfTypeAll<ScriptableMod>().ToList();
      helpString = item.GetTypeInfo(item);

      if (string.IsNullOrEmpty(Name))
      {
         helpString = "[ERROR]: Name Cannot be empty\n" + helpString;
         CanSave = false;
      }

      if (CreatedItems.All(x => Name == x.Name))
      {
         helpString = "[ERROR]: Name already exists\n" + helpString;
         CanSave = false;
      }

      if (CreatedItems.All(x => ID == x.ID))
      {
         helpString = "[ERROR]: ID already in use\n" + helpString;
         CanSave = false;
      }

      #endregion checks

      item.ID = ID;
      item.Name = Name;
      item.AccuracyMultiplier = AccuracyMultiplier;
      item.DamageMultiplier = DamageMultiplier;
      item.MultishotMultiplier = MultishotMultiplier;
      item.CriticalChanceMultiplier = CriticalChanceMultiplier;
      item.CriticalDamageMultiplier = CriticalDamageMultiplier;
      item.StatusChanceMultiplier = StatusChanceMultiplier;
      item.StatusDurationMultiplier = StatusDurationMultiplier;
      item.ReloadSpeedMultiplier = ReloadSpeedMultiplier;
      item.MagazineCapacityMultiplier = MagazineCapacityMultiplier;
      item.MaxAmmoMultiplier = MaxAmmoMultiplier;
      item.Description = Description;

      return true;
   }

   private void OnWizardCreate()
   {
      if (CanSave)
      {
         AssetDatabase.CreateAsset(item, "Assets/Resources/Mods/" + Name + ".asset");
         EditorGUIUtility.PingObject(item);
      }
   }

   private ScriptableMod item;
   private bool CanSave = true;

   #region variables

   public int ID = 1;
   public string Name;
   public float AccuracyMultiplier = 1;
   public float DamageMultiplier = 1;
   public float MultishotMultiplier = 1;
   public float CriticalChanceMultiplier = 1;
   public float CriticalDamageMultiplier = 1;
   public float StatusChanceMultiplier = 1;
   public float StatusDurationMultiplier = 1;
   public float ReloadSpeedMultiplier = 1;
   public float MagazineCapacityMultiplier = 1;
   public float MaxAmmoMultiplier = 1;
   public string Description;

   #endregion variables
}
#endif