using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ringable ringable = collision.gameObject.GetComponent<Ringable>();
        if (ringable)
        {
            ringable.Ring();
        }
    }


    
}
