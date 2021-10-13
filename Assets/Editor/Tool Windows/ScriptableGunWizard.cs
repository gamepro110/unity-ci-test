using UnityEditor;
using UnityEngine;
using thingGame;
using System.Linq;
using System.Collections.Generic;

public class ScriptableGunWizard : ScriptableWizard
{
   [MenuItem("Scriptable/Gun Wizard", priority = 3)]
   public static void OnWizardOpen()
   { DisplayWizard<ScriptableGunWizard>("Gun Wizard", "Create"); }

   private void OnEnable()
   { item = CreateInstance<ScriptableGun>(); }

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

      Accuracy = EditorGUILayout.Slider(
         new GUIContent("Accuracy"),
         Accuracy,
         0,
         1
         );

      Damage = EditorGUILayout.Slider(
         new GUIContent("Damage"),
         Damage,
         1,
         100
         );

      Multishot = EditorGUILayout.Slider(
         new GUIContent("Multishot"),
         Multishot,
         1,
         20
         );

      EditorGUILayout.Space();

      CriticalChance = EditorGUILayout.Slider(
         new GUIContent("Critical Chance"),
         CriticalChance,
         1,
         400
         );

      CriticalDamage = EditorGUILayout.Slider(
         new GUIContent("Critical Damage"),
         CriticalDamage,
         1,
         15
         );

      EditorGUILayout.Space();

      StatusChance = EditorGUILayout.Slider(
         new GUIContent("Status Chance"),
         StatusChance,
         1,
         400
         );

      StatusDuration = EditorGUILayout.IntSlider(
         new GUIContent("Status Duration"),
         (int)StatusDuration,
         1,
         10
         );

      EditorGUILayout.Space();

      ReloadTime = EditorGUILayout.Slider(
         new GUIContent("Reload Time"),
         ReloadTime,
         0,
         10
         );

      MagazineCapacity = EditorGUILayout.IntSlider(
         new GUIContent("Magazine Capacity"),
         MagazineCapacity,
         0,
         400
         );

      MaxAmmo = EditorGUILayout.IntSlider(
         new GUIContent("Magazine Capacity"),
         MaxAmmo,
         1,
         20
         );

      EditorGUILayout.Space();

      EditorGUILayout.LabelField("Description");
      Description = EditorGUILayout.TextArea(Description, GUILayout.ExpandHeight(true));

      #region checks

      List<ScriptableGun> CreatedItems = Resources.FindObjectsOfTypeAll<ScriptableGun>().ToList();
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
      item.Accuracy = Accuracy;
      item.Damage = Damage;
      item.Multishot = Multishot;
      item.CriticalChance = CriticalChance;
      item.CriticalDamage = CriticalDamage;
      item.StatusChance = StatusChance;
      item.StatusDuration = StatusDuration;
      item.ReloadTime = ReloadTime;
      item.MagazineCapacity = MagazineCapacity;
      item.MaxAmmo = MaxAmmo;
      item.Description = Description;

      return true;
   }

   private void OnWizardCreate()
   {
      if (CanSave)
      {
         AssetDatabase.CreateAsset(item, "Assets/Resources/Guns/" + Name + ".asset");
         EditorGUIUtility.PingObject(item);
      }
   }

   private ScriptableGun item;
   private bool CanSave = true;

   #region variables

   private int ID = 0;
   private string Name;
   private float Accuracy = 1;
   private float Damage = 1;
   private float Multishot = 1;
   private float CriticalChance = 1;
   private float CriticalDamage = 1;
   private float StatusChance = 1;
   private float StatusDuration = 1;
   private float ReloadTime = 1;
   private int MagazineCapacity = 1;
   private int MaxAmmo = 1;
   private string Description;

   #endregion variables
}