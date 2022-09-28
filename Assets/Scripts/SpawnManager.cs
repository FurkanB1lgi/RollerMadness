using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float spawnRate = 5f;
    [SerializeField] private GameObject[] spawnObjects;
    [SerializeField] private Transform[] spawnPositions;

    private float NextSpawnTime = 0f;
    private TimeManager timeManager;
    void Start()
    {
        spawnPositions[0].gameObject.name = "Test";
        timeManager = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > NextSpawnTime && timeManager.gameOver == false && timeManager.gameFinished == false)
        {

            NextSpawnTime += spawnRate;
            Spawn(spawnObjects[RandomObjectNumber()], spawnPositions[RandomSpawnNumber()]);
            print("Spawn");
        }
    }
    private void Spawn(GameObject spawnObject, Transform newTransform)
    {
        Instantiate(spawnObject, newTransform.position, newTransform.rotation);
    }
    private int RandomSpawnNumber()
    {
        return Random.Range(0, spawnPositions.Length);
    }
    private int RandomObjectNumber()
    {
        return Random.Range(0, spawnObjects.Length);
    }
}
