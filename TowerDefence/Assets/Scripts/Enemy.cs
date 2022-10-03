using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;
    [SerializeField] private GameObject[] waypoint;
    [SerializeField] private float navigationUpdate;
    
    private float navigationTime = 0;
    private int target = 0;

    private void Start()
    {
            GameManager.Instance.RegisterEnemy(this);
    }
    private void Update()
    {

        if (waypoint != null)
        {
            navigationTime += Time.deltaTime;
            if (navigationTime > navigationUpdate)
            {
                if (target < waypoint.Length)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoint[target].transform.position, navigationTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, exitPoint.position, navigationTime);

                }
                navigationTime = 0;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint") { target++; }
        else if (collision.tag == "Finish")
        {

           GameManager.Instance.UnregisterEnemy(this);

        }
    }
}