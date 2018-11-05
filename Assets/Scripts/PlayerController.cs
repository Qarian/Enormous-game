using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform mainCamera;
    public Transform road;
    public Rigidbody rb;

    public float normalSpeed = 0f;
    public float boostSpeed = 20f;
    public float rotationSpeed = 10f;
    public float acceleration = 10f;

    float speed = 0f;

    void Start()
    {
        rb.useGravity = false;
    }

    void Update()
	{
        SetSpeed();

        transform.parent.Translate(0, 0, speed * Time.deltaTime);
        transform.Rotate(new Vector3(speed * rotationSpeed * Time.deltaTime, 0, 0));
	}

    void SetSpeed()
    {
        float designatedSpeed = normalSpeed;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase != TouchPhase.Ended)
                designatedSpeed = boostSpeed;
        }
        //by dzialalo na komputerze
        designatedSpeed += Input.GetAxisRaw("Vertical") * (-normalSpeed + boostSpeed);

        speed += (designatedSpeed - speed) * acceleration * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CombinationStart")
        {
            NextCombination();
            Destroy(other.gameObject);
        }
            
        else
        {
            rb.useGravity = true;
            mainCamera.parent = null;
            road.parent = null;
            enabled = false;
        }
    }

    void NextCombination()
    {
        Generator.singleton.NewCombination();
    }

}
