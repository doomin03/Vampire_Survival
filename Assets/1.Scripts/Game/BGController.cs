using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGController : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("PlayerPos"))
            return;

        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x) ;
        float diffY = Mathf.Abs(playerPos.y - myPos.y) ;

        Vector3 playerDir = GameManager.Instance.player.dis;
        float dirX = playerDir.x < 0 ? -1 : 1 ;
        float dirY = playerDir.y < 0 ? -1 : 1 ;

        if (Mathf.Abs(diffX - diffY) <= 0.0001f)
        {
            transform.Translate(Vector3.up * dirY * 40);
            transform.Translate(Vector3.right * dirX * 40);
        }
        else if (diffX > diffY)
        {
            //Debug.Log($"x:{diffX}y:{diffY}");
            transform.Translate(Vector3.right * dirX * 40);
        }
        else if (diffX < diffY)
        {
            //Debug.Log($"x:{diffX}y:{diffY}");
            transform.Translate(Vector3.up * dirY * 40);
        }


    }
   
}

