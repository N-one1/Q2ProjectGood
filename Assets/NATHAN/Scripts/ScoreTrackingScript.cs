﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackingScript : MonoBehaviour
{
    public Transform player;
    public float score;
    private float distance;
    public Text scoreText;

    public GameObject Player;
    public PlayerHealth PH;
    public float hp;

    //health text
    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Character(HasAnims)");

        PH = Player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x;
        
        if (score < distance)
        {
            score++;
        }

        hp = PH.Health;

        scoreText.text = "Score: " + score;
        healthText.text = "Sugar: " + hp;
    }
}
