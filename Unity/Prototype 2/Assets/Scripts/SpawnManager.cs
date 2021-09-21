using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 20;
    private float spawnPosZ = 20;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Randomly generate animal index and spawn position
            var spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            int animalIndex = Random.Range(0, animalPrefabs.Length);
            ;d
            Instantiate(animalPrefabs[animalIndex], spawnPos,
                animalPrefabs[animalIndex].transform.rotation);
        }
    }
}
