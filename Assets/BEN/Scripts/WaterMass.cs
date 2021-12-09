using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMass : MonoBehaviour
{
    Rigidbody2D rb2;

    
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2.mass = rb2.velocity.magnitude / 2;
    }
}
