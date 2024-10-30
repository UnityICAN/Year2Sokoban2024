using log4net.Core;
using UnityEditor;
using UnityEngine;

public class LevelLoader : EditorWindow {
    private LevelObject selectedLevel;

    [MenuItem("Window/LevelLoader")]
    public static void OpenWindow() {
        LevelLoader window = GetWindow<LevelLoader>();
        window.titleContent = new GUIContent("Level Loader");
    }

    private void OnGUI() {
        selectedLevel = (LevelObject) EditorGUILayout.ObjectField(selectedLevel, typeof(LevelObject));

        if (GUILayout.Button("Load Level"))
        {
            FindObjectOfType<BoardManager>().LoadLevel(selectedLevel);
        }
    }
}
