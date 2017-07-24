﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frameAnimation : MonoBehaviour
{
    [SerializeField]
    Sprite[] frames;
    float timer = 0.0f;
    int frameIndex = 0;

	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        if (timer > 0.25f)
        {
            timer = 0.0f;
            if (frameIndex == frames.Length - 1)
            {
                frameIndex = 0;
            }
            else
            {
                frameIndex++;
            }
            GetComponent<SpriteRenderer>().sprite = frames[frameIndex];
        }
	}
}
