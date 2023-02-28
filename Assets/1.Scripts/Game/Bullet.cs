using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    void Start()
    {
        transform.Translate(1,0,0 * 10 * Time.deltaTime);
    }

    
}
