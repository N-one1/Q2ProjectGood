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
    public GameObject GameOverScene;
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
        Time.timeScale = 1;
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
            //SceneManager.LoadScene("GameOverScene");
            GameOverScene.SetActive(true);
            Time.timeScale = 0;
        }

        if (Health > (maxHealth + 10))
        {
            HealthDrain(); //1
            HealthDrain(); //2
            HealthDrain(); //3
            HealthDrain(); //4
            HealthDrain(); //5
            HealthDrain(); //6
            HealthDrain(); //7
            HealthDrain(); //8
            HealthDrain(); //9
            HealthDrain(); //10
        }
        else if (Health > maxHealth)
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
