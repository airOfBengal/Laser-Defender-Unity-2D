﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 0.02f;
    Material material;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
