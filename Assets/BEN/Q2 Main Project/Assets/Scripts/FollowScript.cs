using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject Plateform;
    

    public float Playerx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Playerx = Player.transform.position.x;
        if(Playerx - 30f > Plateform.transform.position.x)
        {
            Plateform.transform.Translate(new Vector2(1f, 0));
        }
    }
}
