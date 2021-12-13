using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonShootEnemy : MonoBehaviour
{
    public float range;
    private float distToPlayer;

    [HideInInspector]

    public Transform player;



    void Start()
    {
        
    }

    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if(distToPlayer <= range)
        {
            if(player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)

            {
                //Flip();
            }

            Shoot();
        }

    }
    private void Shoot()
    {

    }

}
