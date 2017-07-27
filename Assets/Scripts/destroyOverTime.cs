using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOverTime : MonoBehaviour
{
    [SerializeField]
    float lifetime;
	// Use this for initialization
	void Start ()
    {
        Destroy(this.gameObject, lifetime);
	}
}
