#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using thingGame;
using System.Linq;
using System.Collections.Generic;

public class ScriptableItemtWizard : ScriptableWizard
{
   [MenuItem("Scriptable/Item Wizard", priority = 1)]
   private static void OnWizardOpen()
   { DisplayWizard<ScriptableItemtWizard>("Item Wizard", "Create"); }

   private void OnEnable()
   { item = CreateInstance<ScriptableItem>(); }

   protected override bool DrawWizardGUI()
   {
      CanSave = true;
      ID = EditorGUILayout.IntField(
         new GUIContent("ID"),
         ID
         );

      Name = EditorGUILayout.TextField(
         new GUIContent("Name"),
         Name
         );

      Amount = EditorGUILayout.IntSlider(
         new GUIContent("Amount"),
         Amount,
         0,
         20
         );

      EditorGUILayout.LabelField("Description");
      Description = EditorGUILayout.TextArea(Description);

      #region checks

      List<ScriptableItem> CreatedItems = Resources.FindObjectsOfTypeAll<ScriptableItem>().ToList();
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
      item.Amount = Amount;
      item.Description = Description;

      return true;
   }

   private void OnWizardCreate()
   {
      if (CanSave)
      {
         AssetDatabase.CreateAsset(item, "Assets/Resources/Items/" + Name + ".asset");
         EditorGUIUtility.PingObject(item);
      }
   }

   private ScriptableItem item;
   private bool CanSave = true;

   #region variables

   private int ID;
   private string Name;
   private int Amount;
   private string Description;

   #endregion variables
}
#endif