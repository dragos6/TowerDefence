using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public GameObject spawnPoint;
    public GameObject[] enemies;
    public int maxEnemiesOnScreen;
    public int totalEnemies;
    public int enemiesPerSpawn;
    private int enemiesOnScreen = 0;

    const float spawnDelay = 1;



    private void Awake()
    {
        if (instance == null) { instance = this; }
        else if (instance != this) { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }
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
