using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Transform mainCamera;
    public Transform road;
    public Rigidbody rb;

    public float normalSpeed = 0f;
    public float boostSpeed = 20f;
    public float rotationSpeed = 10f;

    void Start()
    {
        rb.useGravity = false;
    }

    void Update()
	{
        float push = 0;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase != TouchPhase.Ended)
                push = 1f;
        }
        //push += Input.GetAxis("Vertical");



        float speed = Mathf.Lerp(normalSpeed, boostSpeed, normalSpeed + push * boostSpeed);
        Debug.Log(speed);
        transform.parent.Translate(0, 0, speed * Time.deltaTime);
        transform.Rotate(new Vector3(speed * rotationSpeed, 0, 0));
	}

    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
        mainCamera.parent = null;
        road.parent = null;
    }
}
