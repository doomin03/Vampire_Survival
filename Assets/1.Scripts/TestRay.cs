using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = GameManager.Instance.player.transform.position;
        Vector2 myPos = transform.position;
        Vector2 dir = target - myPos;

        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir.normalized *2f,2f);
        Debug.DrawRay(transform.position, dir.normalized * 2);

        foreach(var targets in hits)
        {
            if (targets.collider.GetComponent<Player>())
            {
                Debug.Log("Player");
            }
        }
    }
}
