using UnityEngine;
using UnityEngine.UI;

public class InputFieldDebug : MonoBehaviour {

    public Text text;
    public int valueId;

    void Start()
    {
        if (text != null)
            text.text = DebugManager.singleton.values[valueId].ToString();
    }

    public void ChangeValue(int amount)
    {
        DebugManager.singleton.values[valueId] += amount;
        text.text = DebugManager.singleton.values[valueId].ToString();
    }

    public void ChangeScene(int index)
    {
        DebugManager.singleton.ChangeScene(index);
    }
}
