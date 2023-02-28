using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    private void Start()
    {
        enemyData.HP = 100;
        enemyData.AttackDistance = 1;
        enemyData.Speed = 10;
        enemyData.Damege = 100;
        enemyData.AttackSpeed = 1;
        Init();
    }
}
