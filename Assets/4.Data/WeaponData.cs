using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponData",menuName ="Weapon/Data")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private Weapon weapon;
    public Weapon Weapon { get { return weapon; } }
    [SerializeField]
    private Bullet bullet;
    public Bullet Bullet { get { return bullet; } }
    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } }
    [SerializeField]
    private float attackRange;
    public float AttackRange { get { return attackRange; } }
}
