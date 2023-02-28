using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Player
{
    private void Start()
    {
        playerData.HP = 1000;
        playerData.AttackRange = 3f;
        playerData.Damage = 0.1f;
        Init();
    }
}
