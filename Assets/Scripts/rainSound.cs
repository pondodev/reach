using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainSound : MonoBehaviour
{
    float volumeTo;
    float timer = 0.0f;
    [SerializeField]
    float max, min;

    void Start ()
    {
        volumeTo = GetComponent<AudioSource>().volume;
    }

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;

        if (timer >= 1.0f)
        {
            volumeTo = Random.Range(min, max);
            timer = 0.0f;
        }

        GetComponent<AudioSource>().volume = Mathf.Lerp(GetComponent<AudioSource>().volume, volumeTo, 0.01f);
	}
}
