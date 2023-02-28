using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private Transform PlayerTrans;
    private void LateUpdate()
    {
        CameraMove();
    }
    void CameraMove()
    {
        transform.position = Vector2.Lerp(transform.position, PlayerTrans.position, 2f);
        
        transform.Translate(0, 0, -10);

    }
}
