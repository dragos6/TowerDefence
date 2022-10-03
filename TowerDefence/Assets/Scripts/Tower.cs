using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private float timeBetweenAttacks;
    [SerializeField] private float attackRadius;


    private Projectile projectile;
    private Enemy targetEnemy = null;
    private float attackCounter;

    private List<Enemy> GetEnemiesInRange()
    {
        List<Enemy> enemisInRange = new List<Enemy>();
        foreach (Enemy enemy in GameManager.Instance.enemyList)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) <= attackRadius)
            {
                enemisInRange.Add(enemy);
            }
        }
        return enemisInRange;
    }
    private Enemy GetNearestInRange()
    {
        Enemy nearestEnemy = null;
        float smallestDistance = float.PositiveInfinity;
        foreach (Enemy enemy in GetEnemiesInRange())
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) < smallestDistance)
            {
                smallestDistance = Vector2.Distance(transform.position, enemy.transform.position);
                nearestEnemy = enemy;
            }
        }
        return nearestEnemy;

    }
}
