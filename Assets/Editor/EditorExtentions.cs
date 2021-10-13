#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public static class EditorExtentions
{
   public static void FloatField(this Editor editor, ref float value, string title, string tooltip = "")
   {
      value = EditorGUILayout.FloatField(
         new GUIContent(
            title,
            tooltip
            ),
         value
         );
   }

   public static void IntSlider(this Editor editor, ref int value, int min, int max, string title, string tooltip = "")
   {
      value = EditorGUILayout.IntSlider(
         new GUIContent(
            title,
            tooltip
            ),
         value,
         min,
         max
         );
   }

   public static void IntSlider(this Editor editor, ref float value, int min, int max, string title, string tooltip = "")
   {
      value = EditorGUILayout.IntSlider(
         new GUIContent(
            title,
            tooltip
            ),
         (int)value,
         min,
         max
         );
   }

   public static void FloatSlider(this Editor editor, ref float value, float min, float max, string title, string tooltip = "")
   {
      value = EditorGUILayout.Slider(
         new GUIContent(
            title,
            tooltip
            ),
         value,
         min,
         max
         );
   }

   public static void TextField(this Editor editor, ref string value, string title, string tooltip = "")
   {
      value = EditorGUILayout.TextField(
         new GUIContent(
            title,
            tooltip
            ),
         value
         );
   }

   public static void TextArea(this Editor editor, ref string value, string title, float minTextAreaHeight = 50)
   {
      EditorGUILayout.HelpBox(
         title,
         MessageType.None
         );
      value = EditorGUILayout.TextArea(value, GUILayout.MinHeight(minTextAreaHeight));
   }

   public static void HelpBox(this Editor editor, string title, MessageType type = MessageType.None)
   {
      EditorGUILayout.Space();
      EditorGUILayout.HelpBox(
         title,
         type
         );
   }

   public static string GetTypeInfo<T>(this object obj, T thing)
   {
      string returnString = "";
      List<object> values = thing.GetType().GetFields().Select(field => field.GetValue(obj)).ToList();
      List<string> members = typeof(T).GetFields().Select(field => field.Name).ToList();
      Dictionary<string, object> info = new Dictionary<string, object>();

      for (int i = 0; i < members.Count; i++)
      { info.Add(members[i], values[i]); }

      info
         .AsEnumerable()
         .ToList()
         .ForEach(
         x => returnString += string.Format(
            "{0}:\t\t\t\t{1}\n",
            x.Key,
            x.Value
            )
         );
      returnString.Remove(returnString.LastIndexOf('\n'));
      return returnString;
   }
}
#endif