#if UNITY_EDITOR
using System.Collections;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(MazeGenerator))]
public class MazeEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		MazeGenerator t = (MazeGenerator)target;
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Создать / Обновить")) t.CreateMap();
		if(GUILayout.Button("Очистить")) t.Clear();
		GUILayout.EndHorizontal();
	}
}
#endif