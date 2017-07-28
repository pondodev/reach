using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundary : MonoBehaviour
{
    Vector2 spawnPoint;

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
            Debug.Log("Elvis has left the building");
            GameObject.FindGameObjectsWithTag("Player")[0].transform.position = spawnPoint;
        }
    }
}
