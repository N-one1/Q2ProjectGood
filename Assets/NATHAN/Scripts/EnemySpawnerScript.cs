using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> EnemyList;
    private GameObject chosenEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        chosenEnemy = EnemyList[Random.Range(0, EnemyList.Count)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform SpawnEnemy(GameObject chosenEmemy, Vector3 spawnPosition)
    {
        
        GameObject go =  Instantiate(chosenEnemy, spawnPosition, Quaternion.identity);
        return go.transform;
    }
}
