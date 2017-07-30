using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camFocus : MonoBehaviour
{
    float timer = 0.0f;

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0.0f;
            transform.localPosition = new Vector2(Random.Range(-2.0f, 2.0f), Random.Range(-2.0f, 2.0f));
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-2.5f, 2.5f));
        }
	}
}
