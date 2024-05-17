using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerupPrefabs;
    public int bossWave = 5; 
    public GameObject bossPrefabs;
 
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        
        Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
        Instantiate(enemyPrefabs[index], GenerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        
        }
    }
    private Vector3 GenerateSpawnPosition ()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefabs, GenerateSpawnPosition(), powerupPrefabs.transform.rotation);
        }
        if (waveNumber == bossWave)
        {
          
          bossWave = bossWave + 5;
          Instantiate(bossPrefabs, GenerateSpawnPosition(), bossPrefabs.transform.rotation);
        }
    }
}
