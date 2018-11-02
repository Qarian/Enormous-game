using UnityEngine;

public class Generator : MonoBehaviour {

    public GameObject[] obstackles;
    public GameObject CombinationStartPrefab;

    [Space]
    public Color[] colors;
    public bool randomColors = false;
    public int combinationsForColor = 10;
    int colorId;
    int leftCombinationsForColor;

    [Space]
    public Combination[] levels;
    public float startPosition = 0f;
    [SerializeField]
    int combinationsLength = 3;

    public bool GenerateOnStart = true;

    Transform[] combinations;
    int nextCombination = 0;

    #region Singleton
    public static Generator singleton;

    void Awake()
    {
        singleton = this;
    }
    #endregion

    void Start()
    {
        colorId = colors.Length - 1;
        NewColor();

        combinations = new Transform[combinationsLength];
        if (GenerateOnStart)
        {
            for (int i = 0; i < combinationsLength - 1; i++)
            {
                NewCombination();
            }
        }
    }

    public void NewCombination()
    {
        if (combinations[nextCombination] != null)
            Destroy(combinations[nextCombination].gameObject);

        GenerateNewCombination(nextCombination);

        nextCombination = (nextCombination + 1) % combinationsLength;
    }

    void GenerateNewCombination(int number)
    {
        combinations[number] = Instantiate(CombinationStartPrefab, Vector3.zero, Quaternion.identity, transform).transform;

        Color color = GetColor();

        int id = Random.Range(0, levels.Length);
        
        for (int i = 0; i < levels[id].elements.Length; i++)
        {
            Vector3 pos = new Vector3(0, 0, levels[id].elements[i].positionZ);
            Quaternion rotation = levels[id].elements[i].rotation;
            Blockade blockade = Instantiate(obstackles[levels[id].elements[i].prefab], pos, rotation, combinations[number]).GetComponent<Blockade>();
            blockade.speed = levels[id].elements[i].speed;
            blockade.gameObject.GetComponent<Renderer>().material.color = color;
        }
        float newDistance = levels[id].elements[levels[id].elements.Length - 1].positionZ;
        combinations[number].Translate(0, 0, startPosition);
        startPosition += newDistance + levels[id].freeSpace;
    }

    Color GetColor()
    {
        Color ret = colors[colorId];
        leftCombinationsForColor -= 1;
        if (leftCombinationsForColor < 1)
            NewColor();
        return ret;
    }

    void NewColor()
    {
        if (randomColors)
        {
            int tmp;
            do
            {
                tmp = Random.Range(0, colors.Length);
            } while (tmp == colorId);
            colorId = tmp;
        }
        else
        {
            colorId = (colorId + 1) % colors.Length;
        }

        leftCombinationsForColor = combinationsForColor;
    }
}
