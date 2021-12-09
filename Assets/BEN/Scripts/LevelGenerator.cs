using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;

    

    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject Player;

    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;
        SpawnLevelPart(); //spawn something using the private void SpawnLevelPart() at beggining/start
    }

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART) //if the player has moved enough forward
        {
            SpawnLevelPart();
            int startingSpawnLevelParts = 1;
            for (int i = 0; i < startingSpawnLevelParts; i++)
            {
                SpawnLevelPart();
            }
        }
    }

    
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)]; //randomizer? maybe?
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition); //attach new part to end of last one
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
       Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

}