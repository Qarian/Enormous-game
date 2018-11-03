using UnityEngine;
using UnityEditor;

public class CustomWindow : EditorWindow {

    bool alwaysShowPlayer;

    [MenuItem("BetterWindows/BetterInspector")]
	public static void ShowWindow()
    {
        GetWindow<CustomWindow>("Better Inspector");
    }

    void OnGUI()
    {
        Object[] obj = Selection.objects;
        #region Player
        alwaysShowPlayer = EditorGUILayout.Toggle("Always Show Player" ,alwaysShowPlayer);

        if (alwaysShowPlayer)
        {
            ShowPlayer();
        }
        else if(obj.Length == 1)
        {
            GameObject go = (GameObject)obj[0];
            if(go.tag == "Player")
            {
                ShowPlayer();
            }
        }
        GUILayout.Space(20f);
        #endregion
    }

    void ShowPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        EditorGUILayout.FloatField("Normal Speed", player.normalSpeed);
        EditorGUILayout.FloatField("Boost Speed", player.boostSpeed);
        EditorGUILayout.FloatField("Rotation Speed", player.rotationSpeed);
        EditorGUILayout.FloatField("acceleration", player.acceleration);
    }

}
