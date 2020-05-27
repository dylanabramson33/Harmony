using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRingable ringable = collision.gameObject.GetComponent<IRingable>();
        if (ringable != null)
        {
            ringable.Ring();
        }
    }


    
}
