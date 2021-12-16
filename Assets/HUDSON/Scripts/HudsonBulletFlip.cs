using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonBulletFlip : MonoBehaviour
{
    //private Rigidbody2D rb2;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //rb2 = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizValue = Input.GetAxis("Horizontal");

        //rb2.velocity = new Vector2(horizValue * 2, rb2.velocity.y);

        if (horizValue < 0)
        {
            Debug.Log("flip");
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
