using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{
    ObjectType objectInHand;
    bool holdingObject;


    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !holdingObject)
        {
            IInteractable interactable = collision.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interaction();    
            }
        }

        else if (Input.GetKeyDown(KeyCode.E) && holdingObject)
        {
            IPlaceable placeable = collision.GetComponent<IPlaceable>();
            if (placeable != null)
            {
                DropEvents.current.DropObject(objectInHand, placeable.ReturnObjectType());
            }
           
        }
    }
   
    void Start()
    {
        GrabEvents.current.onObjectGrabbed += AnimateGrab;
        GrabEvents.current.onObjectGrabbed += HoldObject;
        DropEvents.current.onObjectDropped += ReleaseObject;

    }

    void HoldObject(ObjectType objectType)
    {
        holdingObject = true;
        objectInHand = objectType;
        Debug.Log(objectInHand);
    }

    void ReleaseObject(ObjectType objectType)
    {
        holdingObject = false;
    }

    
    void AnimateGrab(ObjectType grabbedObject)
    {
        
    }
}
