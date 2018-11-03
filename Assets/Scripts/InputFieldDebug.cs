using UnityEngine;
using UnityEngine.UI;

public class InputFieldDebug : MonoBehaviour {

    public InputField input;
    public int valueId;

    void Start()
    {
        if (input != null)
            input.text = DebugManager.singleton.values[valueId].ToString();
    }

    public void ChangeValue(string text)
    {
        float tmp;
        if(float.TryParse(text, out tmp))
        DebugManager.singleton.values[valueId] = tmp;
    }

    public void ChangeScene(int index)
    {
        DebugManager.singleton.ChangeScene(index);
    }
}
