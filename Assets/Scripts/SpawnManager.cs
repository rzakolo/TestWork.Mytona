using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Terrain terrain;
    [SerializeField] private int enemiesNumber;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject playerBasePrefab;
    private Vector3 spawnPosition;
    void Start()
    {
        for (int i = 0; i < enemiesNumber; i++)
        {
            GenerateSpawnPosition();
            Spawn(enemyPrefab);
        }

        GenerateSpawnPosition();
        Spawn(playerBasePrefab);
    }
    private Vector3 GenerateSpawnPosition()
    {
        while (true)
        {
            spawnPosition = new Vector3(Random.Range(0, 500), 1, Random.Range(0, 500));
            if (terrain.SampleHeight(spawnPosition) <= 0)
            {
                return spawnPosition;
            }
        }
    }

    private void Spawn(GameObject prefab)
    {
        prefab.transform.position = spawnPosition;
        Instantiate(prefab);
    }

}
