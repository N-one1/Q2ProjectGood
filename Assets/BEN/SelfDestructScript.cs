using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character(HasAnims)");
    }

    // Update is called once per frame
    void Update()
    {


        //if ((this.transform.position.x - Player.transform.position.x > 110) && (this.transform.position.x < Player.transform.position.x))
        if (Mathf.Abs(this.transform.position.x - Player.transform.position.x) > 110 && (this.transform.position.x < Player.transform.position.x))
        {
            //Debug.Log("Destroy old platform");
            Destroy(this.gameObject);
        }
    }
}
