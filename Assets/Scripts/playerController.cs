using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public bool grounded = true;

    Rigidbody2D rb;
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float jumpStrength = 100.0f;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pressing space");
            rb.AddForce(new Vector2(0, jumpStrength));
        }*/
	}
}
