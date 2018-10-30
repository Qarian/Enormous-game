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
        int push = 0;
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase != TouchPhase.Ended)
                push = 1;
            Debug.Log("Push!");
        }
            

        float speed = (normalSpeed + Input.GetAxis("Vertical") * boostSpeed + push * boostSpeed) * Time.deltaTime;
        transform.parent.Translate(0, 0, speed);
        transform.Rotate(new Vector3(speed * rotationSpeed, 0, 0));
	}

    private void OnTriggerEnter(Collider other)
    {
        rb.useGravity = true;
        mainCamera.parent = null;
        road.parent = null;
    }
}
