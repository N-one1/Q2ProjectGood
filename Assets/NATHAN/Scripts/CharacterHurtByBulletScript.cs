using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHurtByBulletScript : MonoBehaviour
{
    public GameObject Player;
    public Animator A;
    private float animWait;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character(HasAnims)");
        A = Player.GetComponent<Animator>();
        A.SetBool("Shot", true);
        //A.SetBool("Shot", false);
        animWait = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (animWait == 0)
        {
            A.SetBool("Shot", false);
            Destroy (this.gameObject);
        }
        else
        {
            animWait--;
        }
    }
}
