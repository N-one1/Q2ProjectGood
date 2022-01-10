using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 10;
    [SerializeField]
    public int StartingHealth = 100;
    [SerializeField]
    public int Heal = 20;
    public GameObject P;
    private float healthDrainTimer;
    //health bar
    public GameObject hpBarMask;

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
        healthDrainTimer = 0;

        hpBarMask = GameObject.Find("HealthBarMask");
    }

    // Update is called once per frame
    void Update()
    {
        if(Health == 0 || Health < 0)
        {
            Debug.Log("Dead");
            Debug.Log("Switch Scene:");
            SceneManager.LoadScene("CreditsScene");
        }

        if (Health > 100)
        {
            HealthDrain();
        }

        if ((P.GetComponent<Rigidbody2D>().velocity.x+ P.GetComponent<Rigidbody2D>().velocity.y) <= 1)
        {
            healthDrainTimer++;
        }
        if (healthDrainTimer >= 10)
        {
            HealthDrain();
            healthDrainTimer -= 10;
        }
    }



    public void getHealed()
    {
        Health += Heal;
        hpBarMask.GetComponent<HealthBarMaskScript>().MoveHealthMask(Health, 100);
    }

    public void HealthDrain()
    {
        Health--;
        hpBarMask.GetComponent<HealthBarMaskScript>().MoveHealthMask(Health, 100);
    }

}
