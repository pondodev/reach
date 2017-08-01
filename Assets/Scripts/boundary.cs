using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    [SerializeField]
    GameObject death;
    Vector2 spawnPoint;

    public playerController pcScript;

    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Debug.Log("Too many player characters!");
        }
        else
        {
            Debug.Log("Found player!");
            spawnPoint = pcScript.gameObject.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pcScript.deaths += 1;
            if (pcScript.deaths < 10)
            {
                Instantiate(death, pcScript.gameObject.transform.position, pcScript.gameObject.transform.rotation);
                pcScript.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                pcScript.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
                pcScript.gameObject.transform.position = spawnPoint;
            }
            else
            {
                Instantiate(death, pcScript.gameObject.transform.position, pcScript.gameObject.transform.rotation);
                pcScript.endSequence();
            }
        }
    }
}
