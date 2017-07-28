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
    [SerializeField]
    LayerMask raycastInclude = -1;
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, raycastInclude.value);
        Debug.DrawRay(transform.position, Vector3.down * 0.3f, Color.red);

        if (hit.collider != null)
        {
            grounded = true;
            if (!landed)
            {
                // Start land animation and instantiate splash
                GetComponent<Animator>().SetBool("grounded", true);
                GetComponent<Animator>().Play("landing");
                Instantiate(landingSplash, transform.position, transform.rotation);
                landed = true;
            }
        }
        else
        {
            // If we are no longer grounded, make sure we know that
            grounded = false;
            landed = false;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.W) && grounded)
        {
            // When we jump we want to play the animation and add force upwards
            GetComponent<Animator>().SetBool("grounded", false);
            rb.angularVelocity = 0.0f;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpStrength);
        }
	}
}
