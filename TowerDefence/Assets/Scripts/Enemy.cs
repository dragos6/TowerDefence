using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int target = 0;
    public Transform exitPoint;
    public GameObject[] waypoint;
    public float navigationUpdate;

    //private Transform enemy;
    private float navigationTime = 0;

    private void Start()
    {
        //enemy = GetComponent<Transform>();
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
        if (collision.tag == "Checkpoint") {target++; }
        else if(collision.tag =="Finish") 
        {
            GameManager.Instance.RemoveEnemyFromScreen();
            Destroy(gameObject); 

        }
    }
}
