using UnityEngine;

[CreateAssetMenu(fileName = "new Combination", menuName = "New/Combination")]
public class Combination : ScriptableObject {

    public float freeSpace = 5f;
    [Space]
    public Element[] elements;
}

[System.Serializable]
public struct Element
{
    public int prefab;
    public float positionZ;
    public float speed;
    public Quaternion rotation;
}
