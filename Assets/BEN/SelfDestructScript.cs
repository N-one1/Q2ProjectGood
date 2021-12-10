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

        if (this.transform.position.x - Player.transform.position.x > 110)
        {
            Destroy(this.gameObject);
        }
    }
}
