using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstandDamageScript : MonoBehaviour
{
    [SerializeField]
    public int Damage = 1;
    public GameObject Player;
    public PlayerHealth PH; //player health script
    //public EnemyHealthScript EH;
    public int damageRate;
    public int damageRateMax;
    //hp bar mask
    public GameObject hpBarMask;
    public AudioSource ouchSource;
    public AudioSource eiSource;
    public int Health;

    //take damage sound effect
    [SerializeField]
    public GameObject OuchSoundMaker;
    [SerializeField]
    public GameObject OuchSoundSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character(HasAnims)");

        PH = Player.GetComponent<PlayerHealth>();
        //GetComponent<EnemyHealthScript>();

        hpBarMask = GameObject.Find("HealthBarMask");
        Health = PH.Health;
    }

    public class AudioScript : MonoBehaviour
    {
        AudioSource audioSource;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject OuchSound = Instantiate(OuchSoundMaker, OuchSoundSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            damageRate ++;
            if (damageRate > damageRateMax)
            {
                PH.Health -= Damage;
                hpBarMask.GetComponent<HealthBarMaskScript>().MoveHealthMask(Health, 100);
                damageRate = 0;
                Debug.Log("Damage");
            }

            
        }
        if (collision.tag == "Enemy")
        {
            eiSource.Play();
        }

        var enemy = collision.gameObject.GetComponent<EnemyHealthScript>();
        if (enemy)
        {
            enemy.TakeHit(Damage);
            Debug.Log("Enemy Damaged");
        }
    }
}
