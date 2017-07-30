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
        if (timer > 1.0f)
        {
            timer = 0.0f;
            transform.localPosition = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(-2.5f, 2.5f));
        }
	}
}
