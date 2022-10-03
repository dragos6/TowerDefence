
using UnityEngine;

public class TowerBtn : Singleton<TowerManager> 
{
    [SerializeField] GameObject towerObject;
    [SerializeField] Sprite dragSprite;

    public GameObject TowerObject { get { return towerObject; }
    }
    public Sprite DragSprite { get { return dragSprite; } }
}

