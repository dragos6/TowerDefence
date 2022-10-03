using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class TowerManager : MonoBehaviour
{

    private TowerBtn towerBtnPressed;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider.tag == "BuildSite" && towerBtnPressed!= null)
            {
                hit.collider.tag = "BuildSiteFull";
                PlaceTower(hit);
            }
          
        }
        if (spriteRenderer.enabled)
        {
            FollowMouse();
        } 
    }

    private void FollowMouse()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    public void PlaceTower(RaycastHit2D hit)
    {
        if (!EventSystem.current.IsPointerOverGameObject() && towerBtnPressed != null)
        {
            GameObject newTower = Instantiate(towerBtnPressed.TowerObject);
            newTower.transform.position = hit.transform.position;
            disableDragSprite();
        }
    }

    public void SelectedTower(TowerBtn towerSelected)
    {
        enableDragSprite(towerSelected.DragSprite) ;
        towerBtnPressed = towerSelected;
        Debug.Log("Pressed " + towerBtnPressed.gameObject);
    }

    public void enableDragSprite(Sprite sprite)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = sprite;
    }

    public void disableDragSprite()
    {
        spriteRenderer.enabled = false;
    }
}
