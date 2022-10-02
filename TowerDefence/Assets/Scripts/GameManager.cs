using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    

    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int maxEnemiesOnScreen;
    [SerializeField] private int totalEnemies;
    [SerializeField] private int enemiesPerSpawn;
    [SerializeField] private int enemiesOnScreen = 0;

    const float spawnDelay = 1;



    void Start()
    {
        StartCoroutine(Spawner());


    }
    public void RemoveEnemyFromScreen()
    {
        if (enemiesOnScreen > 0)
        {
            enemiesOnScreen--;
        }
    }
    IEnumerator Spawner()
    {
        if (enemiesPerSpawn > 0 && enemiesOnScreen < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemiesOnScreen < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[1]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                    enemiesOnScreen++;
                }
            }

        }

        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(Spawner());
    }
}
