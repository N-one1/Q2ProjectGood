using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudsonCivAi : MonoBehaviour
{
    public float walkSpeed, range, timeBTWShots, shootSpeed;
    private float distToPlayer;

    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn, canShoot;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform shootPos;
    private Transform player;
    public GameObject bullet;
    public GameObject Player;
    int randomInt;

    public LayerMask ground; //helps stop air jumping



    void Start()
    {
        Player = GameObject.Find("Character(HasAnims)");
        player = Player.GetComponent<Transform>();
        mustPatrol = true;
        canShoot = true;
        
    }


    void Update()
    {
        //Random # Generator
        float randomInt = Random.Range(0, 120);

        if((randomInt <= 15)&&(IsGrounded() == true))
        {
            Debug.Log("jumping ai");
            rb.AddForce(Vector2.up * 500);
        }

        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
               // transform.GlocalPosition.(1, 0, 0);
            }

            mustPatrol = false;
            rb.velocity = new Vector2(-walkSpeed * Time.fixedDeltaTime, rb.velocity.y);

            if (canShoot)
            {
                //   StartCoroutine(Shoot());
            }
        }
        else
        {
            mustPatrol = true;
        }

    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            bool mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }
    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    IEnumerator Shoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(timeBTWShots);
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
        Debug.Log("Shoot");
        canShoot = true;
        if (transform.position.x - player.position.x > 0f)
        {
            Debug.Log("bullet flip");
            newBullet.GetComponent<SpriteRenderer>().flipX = true;
        }



    }
    public bool IsGrounded()
    {
        bool grounded = Physics2D.BoxCast(transform.position + new Vector3(0f, 0f, 0f), new Vector3(0.5f, 1f, 0f), 0, Vector2.down, 0.7f, ground);
        return grounded;
    }
}
