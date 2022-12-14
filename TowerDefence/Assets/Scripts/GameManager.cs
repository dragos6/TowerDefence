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

    const float spawnDelay = 1;

    public List<Enemy> enemyList = new List<Enemy>();


    void Start()
    {
        StartCoroutine(Spawner());
    }

    public void RegisterEnemy(Enemy enemy)
    {
        enemyList.Add(enemy);
    }
    public void UnregisterEnemy(Enemy enemy)
    {
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    public void DestroyAllEnemies()
    {
        foreach (Enemy enemy in enemyList)
        {
            Destroy(enemy.gameObject);
        }
        enemyList.Clear();
    }
    IEnumerator Spawner()
    {
        if (enemiesPerSpawn > 0 && enemyList.Count < totalEnemies)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                if (enemyList.Count < maxEnemiesOnScreen)
                {
                    GameObject newEnemy = Instantiate(enemies[1]) as GameObject;
                    newEnemy.transform.position = spawnPoint.transform.position;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
            StartCoroutine(Spawner());
        }
       
    }
}
