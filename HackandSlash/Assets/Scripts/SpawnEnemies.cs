using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public float spawnTimer;

    [SerializeField]
    float Spawnenemy;

    public GameObject[] spawnPoints;
   

    public GameObject enemyToSpawn;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if(spawnTimer > Spawnenemy)
        {
            SpawnEnemy();
            spawnTimer = 0;
        }
    }

    void SpawnEnemy()
    {

        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));


        GameObject spawnEnemies = spawnPoints [Random.Range(0, spawnPoints.Length)];



        Instantiate(enemyToSpawn, pos, transform.rotation);
    }
}
