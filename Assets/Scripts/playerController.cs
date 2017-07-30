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
        RaycastHit2D hit1 = Physics2D.Raycast(new Vector2(transform.position.x + 0.2f, transform.position.y), Vector2.down, 0.3f, raycastInclude.value);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.2f, transform.position.y), Vector2.down, 0.3f, raycastInclude.value);
        Debug.DrawRay(new Vector3(transform.position.x + 0.16f, transform.position.y), Vector3.down * 0.25f, Color.red);
        Debug.DrawRay(new Vector3(transform.position.x - 0.16f, transform.position.y), Vector3.down * 0.25f, Color.red);

        if (hit1.collider != null || hit2.collider != null)
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
