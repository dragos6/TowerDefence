
using UnityEngine;

public class TowerBtn : Singleton<TowerManager> 
{
    [SerializeField] GameObject towerObject;

    public GameObject TowerObject { get { return towerObject; }
    }
}

