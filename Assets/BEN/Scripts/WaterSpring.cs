using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpring : MonoBehaviour
{

    public Component CircleCollider2DTrigger;
    public Component CircleCollider2DInner;
    public int JointCount;

    // Start is called before the first frame update
    void Start()
    {
        JointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Universal")
        {
            JointCount++;
            if (JointCount <= 3)
            {
                this.gameObject.AddComponent<SpringJoint2D>();
                SpringJoint2D mySJ = this.gameObject.GetComponent<SpringJoint2D>();
                Rigidbody2D otherRB2;
                otherRB2 = collision.gameObject.GetComponent<Rigidbody2D>();
                mySJ.connectedBody = otherRB2;
                mySJ.breakForce = 0.1f;
            }

        }
    }

}
