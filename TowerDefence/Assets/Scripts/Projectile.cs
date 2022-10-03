
using UnityEngine;

public enum proType
{
    rock, arrow, fireball
};

public class Projectile : MonoBehaviour
{
    [SerializeField] private int attackStrenght;

    [SerializeField] private proType projectileType;

    public int AttackStrenght
    {
        get
        {
        return attackStrenght;
        }
    }

    public proType ProjectileType
    {
        get { return projectileType; }
    }
}
