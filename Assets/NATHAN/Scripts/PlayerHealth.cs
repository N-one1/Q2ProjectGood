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
    private float maxHealth = 100;
    //health bar
    public GameObject hpBarMask;

    //score
    public GameObject scoreTracker;
    public float s;

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
        healthDrainTimer = 0;

        hpBarMask = GameObject.Find("HealthBarMask");

        scoreTracker = GameObject.Find("ScoreTracker");
        s = scoreTracker.GetComponent<ScoreTrackingScript>().score;
    }

    // Update is called once per frame
    void Update()
    {
        s = scoreTracker.GetComponent<ScoreTrackingScript>().score;
        //if (score/10.0f > 100)
        //{
        //    maxHealth = (score / 10.0f);
        //}
        maxHealth = Mathf.Clamp(s , 100, 100);

        if(Health == 0 || Health < 0)
        {
            Debug.Log("Dead");
            Debug.Log("Switch Scene:");
            SceneManager.LoadScene("GameOverScene");
        }

        if (Health > maxHealth)
        {
            HealthDrain();
            Debug.Log(maxHealth);
        }

        if ((P.GetComponent<Rigidbody2D>().velocity.x+ P.GetComponent<Rigidbody2D>().velocity.y) <= 1)
        {
            healthDrainTimer++;
        }
        if (healthDrainTimer >= 15)
        {
            HealthDrain();
            healthDrainTimer -= 15;
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
