using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrackingScript : MonoBehaviour
{
    public Transform player;
    public float score;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x;
        
        if (score < distance)
        {
            score++;
        }
    }
}
