#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using thingGame;

[CustomEditor(typeof(ScriptableItem))]
public class ScriptableItemEditor : Editor
{
   private void OnEnable()
   {
      item = (ScriptableItem)target;
   }

   public override void OnInspectorGUI()
   {
      item.ID = EditorGUILayout.IntField(
         new GUIContent("Unique ID", "the Unique item ID"),
         item.ID
         );

      item.Amount = EditorGUILayout.IntSlider(
         new GUIContent("Amount", "the amount of the item"),
         item.Amount,
         0,
         100
         );

      EditorGUILayout.Space();

      item.name = EditorGUILayout.TextField(
         new GUIContent("Item Name", "the name of the item"),
         item.name
         );

      EditorGUILayout.PrefixLabel(
         new GUIContent("Item Description", "simple description of the item")
         );

      item.Description = EditorGUILayout.TextArea(
         item.Description,
         GUILayout.ExpandWidth(true)
         );
   }

   private ScriptableItem item;
}
#endif