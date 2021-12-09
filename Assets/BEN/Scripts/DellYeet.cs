using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DellYeet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("DEEEEELLLLLYYYYEEEETTTT");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Colliding with " + collision.gameObject.name);
        //if(collision.gameObject.tag == "Universal")
        //{
        Destroy(collision.gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
