using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelObjectives : MonoBehaviour
{
    //set next level in game
    public int NextLevel;

    public int EnemiesInLevel;
    public GameObject[] enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        EnemiesInLevel = enemy.Length;
    }

    void Update()
    {


        if (EnemiesInLevel <= 0)
        {
            SceneManager.LoadScene(NextLevel);
        }
    }
}



