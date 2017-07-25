using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    Vector3 refVel = Vector3.zero;
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 1), ref refVel, 0.5f, 20f, Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, player.transform.rotation, 0.01f);
	}
}
