using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyList;
    private GameObject chosenEnemy;
    public GameObject scoreTracker;
    //private ScoreTrackingScript s;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        //s = scoreTracker.GetComponent<ScoreTrackingScript>();
        float x = transform.position.x;
        float maxX = 500;

        float percent = Mathf.Clamp(x / maxX, -0.5f, 0.9f);
        float dice = Random.Range(0.1f, 1.0f);
        Debug.Log("diceRoll"+dice);
        if(dice < percent)
        {
            SpawnEnemy(chosenEnemy = EnemyList[Random.Range(0, EnemyList.Count)],this.transform.position);
        }



        //Debug.Log(x);
        //chosenEnemy = EnemyList[Random.Range(0, EnemyList.Count)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy(GameObject chosenEmemy, Vector3 spawnPosition)
    {
        GameObject go =  Instantiate(chosenEnemy, spawnPosition, Quaternion.identity);
    }
}
