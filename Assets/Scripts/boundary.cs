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
            spawnPoint = GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            pcScript.deaths += 1;
            if (pcScript.deaths < 10)
            {
                Instantiate(death, GameObject.FindGameObjectsWithTag("Player")[0].transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.rotation);
                GameObject.FindGameObjectsWithTag("Player")[0].transform.position = spawnPoint;
            }
            else
            {
                Instantiate(death, GameObject.FindGameObjectsWithTag("Player")[0].transform.position, GameObject.FindGameObjectsWithTag("Player")[0].transform.rotation);
                pcScript.endSequence();
            }
        }
    }
}
