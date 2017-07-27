using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float jumpStrength = 100.0f;
    [SerializeField]
    GameObject landingSplash;
    bool grounded, landed;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

        // Raycast to check if we are grounded
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.2f), Vector2.down);
        if (hit.collider != null)
        {
            float dist = hit.point.y - transform.position.y;
            if (-dist <= 0.3f)
            {
                grounded = true;
                if (!landed)
                {
                    Instantiate(landingSplash, transform.position, transform.rotation);
                    landed = true;
                }
            }
            else
            {
                grounded = false;
                landed = false;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.AddForce(Vector2.up * jumpStrength);
        }
	}
}
