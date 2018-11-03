using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugManager : MonoBehaviour {

    public float[] values;

    #region Singleton
    public static DebugManager singleton;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);

        values = new float[4];
        values[2] = -1f;
    }
    #endregion

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerController pc = FindObjectOfType<PlayerController>();
            if (values[2] == -1f)
            {
                values[0] = pc.normalSpeed;
                values[1] = pc.boostSpeed;
                values[2] = pc.rotationSpeed;
                values[3] = pc.acceleration;
            }
            else
            {
                pc.normalSpeed = values[0];
                pc.boostSpeed = values[1];
                pc.rotationSpeed = values[2];
                pc.acceleration = values[3];
            }
        }
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
