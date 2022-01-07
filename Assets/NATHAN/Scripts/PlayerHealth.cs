using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 10;
    [SerializeField]
    public float StartingHealth = 100;
    [SerializeField]
    public float Heal = 20;
    public GameObject P;
    private float healthDrainTimer;

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
        healthDrainTimer = 0;
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

        if (Health >= 101)
        {
            Health--;
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
    }

    public void HealthDrain()
    {
        Health--;
    }

}
