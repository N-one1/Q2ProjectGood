using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 10;
    [SerializeField]
    public float StartingHealth = 10;
    [SerializeField]
    public float Heal = 10;

    // Start is called before the first frame update
    void Start()
    {
        Health = StartingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Health == 0 || Health < 0)
        {
            Debug.Log("Dead");
        }
    }

    public void getHealed()
    {
        Health += Heal;
    }
}
