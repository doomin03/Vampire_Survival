using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    Collider2D coll;
    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
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
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0));
                }
                break;
            case "ground":
                if (Mathf.Abs(diffX - diffY) <= 0.0001f)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                }
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

           
        }

        

    }
   
}

