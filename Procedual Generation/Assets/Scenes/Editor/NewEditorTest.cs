using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(LevelGeneratorScript))]
public class LevelGeneratorEditor : Editor
{

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector ();
		EditorGUILayout.BeginVertical ("box");
		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.Space();
		EditorGUILayout.SelectableLabel ("Platforms\t5");
		//EditorGUILayout.
		//LevelGeneratorScript levelGenerator = (SCR_)target;
		if (GUILayout.Button ("Build")) {
			//levelGenerator.GenerateLevel ();
		}
		//EditorGUILayout.HelpBox ("This is a MessageBox", MessageType.None, false);
		EditorGUILayout.EndVertical ();
		EditorGUILayout.EndHorizontal();
		//EditorGUILayout.Space();
	}
}
