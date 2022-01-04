using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private List<Transform> EnemyList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Transform chosenEnemy = EnemyList[Random.Range(0, EnemyList.Count)];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Transform SpawnEnemy(Transform chosenEmemy, Vector3 spawnPosition)
    {
        Transform Instantiate(chosenEnemy, spawnPosition, Quaternion.identity);
    }
}
