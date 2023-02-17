using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farmer : Player
{
    private void Start()
    {
        Init();
    }

    private void LateUpdate()
    {
        CameraMove();
    }

    public override void CameraMove()
    {
        base.CameraMove(); 
    }
}
