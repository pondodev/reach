using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float jumpStrength = 100.0f;
    float[] overlayAlpha = new float[11] { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
    float refVel = 0.0f;
    [SerializeField]
    GameObject landingSplash;
    [SerializeField]
    LayerMask raycastInclude = -1;
    [SerializeField]
    Image overlay;
    bool grounded, landed;

    public int deaths = 0;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        overlay.color = new Vector4(0, 0, 0, Mathf.SmoothDamp(overlay.color.a, overlayAlpha[deaths], ref refVel, 0.1f));

        transform.Translate(new Vector2((Input.GetAxis("Horizontal") * speed) * Time.deltaTime, 0));

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
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded || Input.GetKeyDown(KeyCode.W) && grounded || Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            // When we jump we want to play the animation and add force upwards
            GetComponent<Animator>().SetBool("grounded", false);
            rb.angularVelocity = 0.0f;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpStrength);
        }
    }

    // Function to be called once the player has reached the end of the game
    public void endSequence()
    {
        GameObject.FindGameObjectsWithTag("endtext")[0].GetComponent<Animator>().SetBool("gameEnded", true);
    }
}
