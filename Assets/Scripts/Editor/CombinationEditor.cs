using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Combination))]
public class CombinationEditor : Editor {

    GameObject patternGO;
    Combination combination;

    public override void OnInspectorGUI()
    {
        combination = (Combination)target;

        patternGO = GameObject.Find("Combination Start");
        patternGO = (GameObject)EditorGUILayout.ObjectField(patternGO, typeof(GameObject), true);

        if(GUILayout.Button("Assign combination"))
            MakeNewCombination();

        if (GUILayout.Button("Generate In Editor"))
            GenerateInEditor();

        GUILayout.Space(10f);
        base.OnInspectorGUI();
    }

    void MakeNewCombination()
    {
        Transform pattern = patternGO.transform;
        int length = pattern.childCount - 1;

        if (length > 0)
        {
            combination.elements = new Element[length];

            for (int i = 0; i < length; i++)
            {
                Transform element = pattern.GetChild(i + 1);
                combination.elements[i].positionZ = element.position.z;
                combination.elements[i].rotation = element.rotation;
                combination.elements[i].speed = element.GetComponent<Blockade>().speed;
                combination.elements[i].prefab = element.GetComponent<Blockade>().prefab;
            }
        }
        else
        {
            Debug.LogError("This don't look like combination. Check if prefab is in 'Combination Start' family");
        }
    }

    void GenerateInEditor()
    {
        Generator gen = FindObjectOfType<Generator>();

        Transform combinations = Instantiate(gen.CombinationStartPrefab, Vector3.zero, Quaternion.identity, null).transform;

        for (int i = 0; i < combination.elements.Length; i++)
        {
            Vector3 pos = new Vector3(0, 0, combination.elements[i].positionZ);
            Quaternion rotation = combination.elements[i].rotation;
            Blockade blockade = Instantiate(gen.obstackles[combination.elements[i].prefab], pos, rotation, combinations).GetComponent<Blockade>();
            blockade.speed = combination.elements[i].speed;
        }
    }
}
