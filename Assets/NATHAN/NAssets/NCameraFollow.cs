﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1024, 768, Screen.fullScreen);
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
