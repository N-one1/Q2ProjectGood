using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpeed : MonoBehaviour
{

    public GameObject Molecule;

    Rigidbody2D rb2;

    

    // Start is called before the first frame update
    void Start()
    {
        rb2 = Molecule.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(0.8f, Mathf.Clamp(0.3f + rb2.velocity.magnitude/10, 0.3f, 0.8f), 1);
     
        //-rb2.velocity.magnitude / 20
    }
}
