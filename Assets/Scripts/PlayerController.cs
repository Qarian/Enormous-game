using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float normalSpeed = 0f;
    public float boostSpeed = 20f;

	void Update()
	{
        transform.Translate(0, 0, (normalSpeed + Input.GetAxis("Vertical") * boostSpeed) * Time.deltaTime);
	}
}
