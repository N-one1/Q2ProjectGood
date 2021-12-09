using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstandDamageScript : MonoBehaviour
{
    [SerializeField]
    public float Damage = 1;
    public PlayerHealth PH;
    //public EnemyHealthScript EH;
    public int damageRate;
    public int damageRateMax;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<PlayerHealth>();
        //GetComponent<EnemyHealthScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            damageRate ++;
            if (damageRate > damageRateMax)
            {
                PH.Health -= Damage;
                damageRate = 0;
                Debug.Log("Damage");
            }

            
        }

        var enemy = collision.gameObject.GetComponent<EnemyHealthScript>();
        if (enemy)
        {
            enemy.TakeHit(Damage);
            Debug.Log("Enemy Damaged");
        }
    }
}
